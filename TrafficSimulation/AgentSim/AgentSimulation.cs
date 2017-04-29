using DataManager;
using DataManager.MappingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace AgentSim
{
    /// <summary>
    /// Implementation for the IAgentSim interface for spawning agents and calling their Behaviours
    /// </summary>
    public class AgentSimulation : IAgentSim
    {
        private readonly IDataManager dataManager_;
        private Timer physicsTimer;
        private const int timerInterval = 1000 / 1; // 100 fps
        private IReadOnlyList<Datamodel.Edge> allEdges_;
        // TODO: property for staticRules_

        /// <summary>
        /// Dependency constructor for the AgentSim class.
        /// </summary>
        public AgentSimulation(IDataManager dataManager)
        {
            dataManager_ = dataManager;
        }

        /// <summary>
        /// Starts the agent simulation timer
        /// </summary>
        public void Start()
        {
            // TODO: Fetch staticRules_ once here
            allEdges_ = dataManager_.Edges;

            // Setup Timer
            physicsTimer = new Timer();
            physicsTimer.Elapsed += new ElapsedEventHandler(TimerTick);
            physicsTimer.Interval = timerInterval;
            physicsTimer.Enabled = true;
        }

        /// <summary>
        /// Stops the agent simulation thread
        /// </summary>
        public void Stop()
        {
            physicsTimer.Enabled = false;
        }

        private void TimerTick(object source, ElapsedEventArgs e)
        {
            // NOTE: all velocities are given as m/s, accellerations as m/s^2 and lengths as m

            // Get all agents
            List<SimAgent> agents = new List<SimAgent>();
            agents.AddRange(dataManager_.Agents);

            // TODO: Get dynamic rules

            // Iterate over all agents and update their behaviour
            Parallel.ForEach(agents, (agent) => {
                // Console.WriteLine("updating behaviour");

                // Check, if the agent has a defined route, otherwise calculate it.
                calculateRouteIfNeccessary(agent);



            });
        }

        /// <summary>
        /// Checks, if a route exists for the passed agent.
        /// Calculates a new route, if it is missing.
        /// </summary>
        /// <param name="agent">Agent the route should be calculated for</param>
        private void calculateRouteIfNeccessary(SimAgent agent)
        {
            var route = agent.Route;

            // Check, if a route already exists
            if(!(route == null || route.Count <= 0))
            {
                return;
            }

            // Instantiate new route (just to be sure)
            route = new Queue<Datamodel.AbstractEdge>();

            // Get a list of all possible successor edges
            IReadOnlyList<Datamodel.Edge> successors = dataManager_.GetSuccessorEdges(agent.EdgeId);
            while (successors != null && successors.Count > 0) {
                // Randomly choose a successor edge
                Datamodel.Edge nextEdge = successors[0];
                route.Enqueue(nextEdge);

                // Fetch successors for the next edge
                successors = dataManager_.GetSuccessorEdges(nextEdge.Id);
            }

            Console.WriteLine("Calculated a new route");

        }

    }
}
