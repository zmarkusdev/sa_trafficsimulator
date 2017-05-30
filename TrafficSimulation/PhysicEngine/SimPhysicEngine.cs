using DataManager;
using DataManager.MappingModels;
using Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using VehicleDeactivatorLibrary;

namespace PhysicEngine
{
    public class SimPhysicEngine : IPhysicEngine
    {
        private readonly IDataManager dataManager_;
        private Timer physicsTimer;
        private const int timerInterval = 1000 / 25; // 100 fps

        public SimPhysicEngine(IDataManager dataManager)
        {
            dataManager_ = dataManager;
        }

        public void Start()
        {
            physicsTimer = new Timer();
            physicsTimer.Elapsed += new ElapsedEventHandler(TimerTick);
            physicsTimer.Interval = timerInterval;
            physicsTimer.Enabled = true;

            var messageReceiver = new MessageReceiver();
            messageReceiver.ReceiveEventHandler += MessageReceiver_ReceiveEventHandler;

        }

        private void MessageReceiver_ReceiveEventHandler(object sender, MessageEventArgs e)
        {
            var agentId = e.Message.AgentId;

            // Get agent
            SimAgent curAgent;
            lock (dataManager_) curAgent = dataManager_.Agents.FirstOrDefault(a => a.Id == agentId);

            // Update agent
            if(curAgent != null)
            {
                curAgent.IsActive = false;
                lock (dataManager_) dataManager_.UpdateAgent(curAgent);
            }
        }

        public void Stop()
        {
            physicsTimer.Enabled = false;
        }

        private void TimerTick(object source, ElapsedEventArgs e)
        {
            //Console.WriteLine("Physic engine tick!");

            // NOTE: all velocities are given as m/s, accellerations as m/s^2 and lengths as m
            List<SimAgent> copiedAgents;
            lock (dataManager_) copiedAgents = dataManager_.Agents.ToList();
            //copiedAgents.AddRange(dataManager_.Agents);

            // Get agents
            Parallel.ForEach(copiedAgents, (agent) => {
                if (agent == null) return;

                // Get current edge from agent route, fallback is edge the agent is standing on
                AbstractEdge curEdge;
                lock(dataManager_) curEdge = dataManager_.Edges.FirstOrDefault(edge => edge.Id == agent.EdgeId);

                var curAgent = agent.Clone() as SimAgent;

                if (curEdge == null) return; // Skip if no position is found...

                if (!GetCurrentQueuePosition(curAgent, curEdge)) return;

                // Check valid accelerations
                CheckValidAccelerations(curAgent);

                // If agent is dead, decelerate till velocity is zero
                if (!curAgent.IsActive) curAgent.CurrentAccelerationExact = -curAgent.Deceleration;

                // Calculate new velocity based on accelleration or decelleration
                curAgent.CurrentVelocityExact = curAgent.CurrentVelocityExact + curAgent.CurrentAccelerationExact * timerInterval / 1000;

                // check valid velocities of agent
                CheckValidVelocities(curAgent);

                // Calculate new position based on velocity and position
                if (CalculateNewPositionOfAgent(curAgent, curEdge))
                {
                    // Save the exact values rounded as integers into the datamodel fields
                    curAgent.CurrentVelocity = (int)Math.Round(curAgent.CurrentVelocityExact);
                    curAgent.RunLength = (int)Math.Round(curAgent.RunLengthExact);
                    curAgent.RunLength = curAgent.RunLength < 0 ? 0 : curAgent.RunLength;
                    dataManager_.UpdateAgent(curAgent);
                }
            });            
        }

        bool GetCurrentQueuePosition(SimAgent curAgent, AbstractEdge curEdge)
        {
            // Get current queue position
            lock (curAgent)
            {
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
            double runLengthIncrement = curAgent.CurrentVelocityExact * timerInterval / 1000;

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
                    // TODO: Let agent die
                    lock (dataManager_) dataManager_.DeleteAgent(curAgent);
                    return false;
                }                
            }

            curAgent.RunLengthExact = curAgent.RunLengthExact + runLengthIncrement;
            return true;
        }
    }
}
