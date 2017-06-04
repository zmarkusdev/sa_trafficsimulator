using DataManager;
using DataManager.MappingModels;
using Datamodel;
using Log;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using VehicleDeactivatorLibrary;
using VehicleHandoverLibrary;

namespace PhysicEngine
{
    public class SimPhysicEngine : IPhysicEngine
    {
        private readonly IDataManager dataManager_;
        private const int timerInterval = 1000 / 60; // 30 fps

        bool shouldStop = false;
        Thread physicsThread;

        readonly ILog log_;

        public SimPhysicEngine(IDataManager dataManager, ILog log)
        {
            dataManager_ = dataManager;
            log_ = log;
        }

        public void Start()
        {
            shouldStop = false;
            physicsThread = new Thread(RunPhysics);
            physicsThread.Start();

            // Message receiver for vehicle deactivation messages
            var messageReceiver = new MessageReceiver();
            messageReceiver.ReceiveEventHandler += MessageReceiver_ReceiveEventHandler;

            // Vehicle receiver for remote vehicle receiving
            var vehicleReceiver = new VehicleReceiver(Groups.GROUP03);
            vehicleReceiver.ReceiveEventHandler += VehicleReceiver_ReceiveEventHandler;

        }

        private void VehicleReceiver_ReceiveEventHandler(object sender, VehicleEventArgs e)
        {
            // Get remote starting positions
            var entryPoints = dataManager_.AllPositions.Where(p => p.IsRemoteEntryPoint).ToList();
            var rnd = new Random();            
            var entryPoint = entryPoints[rnd.Next(entryPoints.Count)];

            // Agent should be spawned, prepare new agent
            var agent = new SimAgent
            {
                IsActive = true,
                CurrentVelocity = 0,
                EdgeId = entryPoint.SuccessorEdgeIds.FirstOrDefault(), // TODO: hardcoded...
                RunLength = 0,
                RunLengthExact = 0,
                CurrentAccelerationExact = 0,
                CurrentVelocityExact = 0,
                VehicleWidth = (int)e.Vehicle.Width,
                // Roll the maximum allowed acceleration
                Acceleration = (int)e.Vehicle.MaxAcceleration,
                // Roll the maximum allowed deceleration
                Deceleration = (int)e.Vehicle.MaxDeceleration,
                // Roll the maximum allowed velocity
                MaxVelocity = (int)e.Vehicle.MaxVelocity,
                // Roll vehicle length
                VehicleLength = (int)e.Vehicle.Length,
                Type = AgentType.Car01
            };

            dataManager_.CreateAgent(agent);
        }

        private void MessageReceiver_ReceiveEventHandler(object sender, MessageEventArgs e)
        {
            var agentId = e.Message.AgentId;

            // Get agent
            SimAgent curAgent;
            curAgent = dataManager_.Agents.FirstOrDefault(a => a.Id == agentId);

            // Update agent
            if(curAgent != null)
            {
                // Toggle active state
                curAgent.IsActive = !curAgent.IsActive;
                dataManager_.UpdateAgent(curAgent);
            }
        }

        public void Stop()
        {
            shouldStop = true;
            // Wait for thread termination
            while (physicsThread.IsAlive) Thread.Sleep(100);
        }

        private void RunPhysics()
        {
            while(!shouldStop)
            {
                try
                {                
                    // NOTE: all velocities are given as m/s, accellerations as m/s^2 and lengths as m
                    List<SimAgent> copiedAgents;
                    copiedAgents = dataManager_.Agents.ToList();
                    //copiedAgents.AddRange(dataManager_.Agents);

                    // Get agents
                    foreach (var agent in copiedAgents)
                    {
                        if (agent == null) return;
                    
                        // Get current edge from agent route, fallback is edge the agent is standing on
                        AbstractEdge curEdge;
                        curEdge = dataManager_.Edges.FirstOrDefault(edge => edge.Id == agent.EdgeId);
                    
                        var curAgent = agent.Clone() as SimAgent;

                        if (curEdge == null) continue; // Skip if no position is found...
                    
                        if (!GetCurrentQueuePosition(curAgent, curEdge)) continue;

                        // Check valid accelerations
                        CheckValidAccelerations(curAgent);

                        // If agent is dead, decelerate till velocity is zero
                        if (!curAgent.IsActive) curAgent.CurrentAccelerationExact = -curAgent.Deceleration;

                        // Calculate new velocity based on accelleration or decelleration
                        curAgent.CurrentVelocityExact = curAgent.CurrentVelocityExact + curAgent.CurrentAccelerationExact * timerInterval / 1000.0;

                        // check valid velocities of agent
                        CheckValidVelocities(curAgent);

                        // Calculate new position based on velocity and position
                        if (CalculateNewPositionOfAgent(curAgent, curEdge))
                        {
                            // Save the exact values rounded as integers into the datamodel fields
                            curAgent.CurrentVelocity = (int)Math.Round(curAgent.CurrentVelocityExact);
                            curAgent.RunLength = (int)Math.Floor(curAgent.RunLengthExact);
                            curAgent.RunLength = curAgent.RunLength < 0 ? 0 : curAgent.RunLength;
                            dataManager_.UpdateAgent(curAgent);                        
                        }
                    }
                    Thread.Sleep(timerInterval);
                }
                catch (Exception e)
                {
                    log_.Debug(e.Message);
                }
            }
        }

        bool GetCurrentQueuePosition(SimAgent curAgent, AbstractEdge curEdge)
        {
            // Get current queue position            
            AbstractEdge ae;
            do
            {
                // If no route of the agent is given, skip the agent
                if (curAgent.Route.Count <= 0)
                    return false;

                ae = curAgent.Route.Dequeue();
            } while (ae.Id != curEdge.Id);

            return true;            
        }

        void CheckValidAccelerations(SimAgent curAgent)
        {
            // Check valid accelerations
            curAgent.CurrentAccelerationExact = curAgent.CurrentAccelerationExact < curAgent.Deceleration ? curAgent.Deceleration : curAgent.CurrentAccelerationExact;
            curAgent.CurrentAccelerationExact = curAgent.CurrentAccelerationExact > curAgent.Acceleration ? curAgent.Acceleration : curAgent.CurrentAccelerationExact;
        }

        void CheckValidVelocities(SimAgent curAgent)
        {
            // check valid velocities of agent
            curAgent.CurrentVelocityExact = curAgent.CurrentVelocityExact < 0 ? 0 : curAgent.CurrentVelocityExact;
            curAgent.CurrentVelocityExact = curAgent.CurrentVelocityExact > curAgent.MaxVelocity ? curAgent.MaxVelocity : curAgent.CurrentVelocityExact;
        }

        /// <summary>
        /// Calculates the new position of the agent or dispawns it, if it goes out of bounce.
        /// </summary>
        /// <param name="curAgent">Agent of which the new position should be calculated</param>
        /// <param name="curEdge">Current edge on which the agent is</param>
        /// <returns>True if agent is still in bounce, false if otherwise</returns>
        bool CalculateNewPositionOfAgent(SimAgent curAgent, AbstractEdge curEdge)
        {
            // Calculate new position based on velocity and position
            double runLengthIncrement = curAgent.CurrentVelocityExact * timerInterval / 1000.0;

            // Calculate new edge position of the cur agent
            while (curAgent.RunLengthExact + runLengthIncrement > curEdge.CurveLength)
            {
                // Calculate remaining run length increment
                runLengthIncrement = runLengthIncrement - (curEdge.CurveLength - curAgent.RunLengthExact);

                // Always set run length position of agent to zero after edge overflow
                curAgent.RunLengthExact = 0;

                // Set new agent position
                if(curAgent.Route.Count > 0)
                {
                    curEdge = curAgent.Route.Dequeue();
                    curAgent.EdgeId = curEdge.Id;
                }
                else
                {                    
                    // Check if last position of agent route was a remote exit position
                    var position = dataManager_.AllPositions.FirstOrDefault(p => p.PredecessorEdgeIds.Any(e => e == curAgent.EdgeId));
                    var transfer = position?.Transfer ?? RemoteAgentTransfer.none;
                    if(transfer != RemoteAgentTransfer.none)
                    {
                        // Transfer to another application
                        VehicleSender sender;
                        switch (transfer)
                        {
                            case RemoteAgentTransfer.none:
                                return false;
                            case RemoteAgentTransfer.Group1:
                                sender = new VehicleSender(Groups.GROUP01);
                                break;
                            case RemoteAgentTransfer.Group2:
                                sender = new VehicleSender(Groups.GROUP02);
                                break;
                            case RemoteAgentTransfer.Group3:
                                sender = new VehicleSender(Groups.GROUP03);
                                break;
                            default:
                                return false;
                        }

                        // Define vehicle
                        var vehicle = new Vehicle()
                        {
                            Length = curAgent.VehicleLength,
                            Width = curAgent.VehicleWidth,
                            MaxAcceleration = curAgent.Acceleration,
                            MaxDeceleration = curAgent.Deceleration,
                            MaxVelocity = curAgent.MaxVelocity,
                            Type = VehicleType.CAR
                        };

                        // Push vehicle
                        sender.PushVehicle(vehicle);
                    }

                    // Let agent die
                    dataManager_.DeleteAgent(curAgent);

                    return false;
                }                
            }

            curAgent.RunLengthExact = curAgent.RunLengthExact + runLengthIncrement;
            return true;
        }
    }
}
