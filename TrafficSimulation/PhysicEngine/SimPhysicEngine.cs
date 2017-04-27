using DataManager;
using DataManager.MappingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace PhysicEngine
{
    public class SimPhysicEngine : IPhysicEngine
    {
        private readonly IDataManager dataManager_;
        private Timer physicsTimer;
        private const int timerInterval = 1000 / 100; // 100 fps

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
            
        }

        public void Stop()
        {
            physicsTimer.Enabled = false;
        }

        private void TimerTick(object source, ElapsedEventArgs e)
        {
            //Console.WriteLine("Physic engine tick!");

            // NOTE: all velocities are given as m/s, accellerations as m/s^2 and lengths as m

            List<SimAgent> copiedAgents = new List<SimAgent>();
            copiedAgents.AddRange(dataManager_.Agents);

            // Get agents
            Parallel.ForEach(copiedAgents, (agent) => {
                // Get current edge from agent route, fallback is edge the agent is standing on
                var curEdge = dataManager_.Edges.FirstOrDefault(edge => edge.Id == agent.EdgeId);

                var curAgent = agent.Clone() as SimAgent;

                if (curEdge == null)
                    return; // Skip if no position is found...

                // Calculate new velocity based on accelleration or decelleration
                curAgent.CurrentVelocityExact = curAgent.CurrentVelocityExact + curAgent.CurrentAccelerationExact * timerInterval / 1000;

                // Calculate new position based on velocity and position
                curAgent.RunLengthExact = curAgent.RunLengthExact + curAgent.CurrentVelocityExact * timerInterval / 1000;

                // Save the exact values rounded as integers into the datamodel fields
                curAgent.CurrentVelocity = (int)Math.Round(curAgent.CurrentVelocityExact);
                curAgent.RunLength = (int)Math.Round(curAgent.RunLengthExact);
                dataManager_.UpdateAgent(curAgent);

                if(curAgent.RunLengthExact > curEdge.CurveLength)
                {
                    //Console.WriteLine($"Edge Overflow detected, cur length is {curAgent.RunLengthExact:N2}");
                }
            });            
        }
    }
}
