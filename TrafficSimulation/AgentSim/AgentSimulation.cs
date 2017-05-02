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
        private const int timerInterval = 1000 / 100; // 100 fps
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
                var curAgent = agent.Clone() as SimAgent;
                //Console.WriteLine("Calculating behaviour of agent #" + agent.Id);

                // Check, if the agent has a defined route, otherwise calculate it.
                calculateRouteIfNeccessary(curAgent);

                // Update the behaviour (acceleration etc.)
                updateBehaviour(curAgent);

                // Update the agent
                dataManager_.UpdateAgent(curAgent);
            });
        }


        /// <summary>
        /// Checks, if a route exists for the passed agent.
        /// Calculates a new route, if it is missing.
        /// </summary>
        /// <param name="agent">Agent the route should be calculated for</param>
        private void calculateRouteIfNeccessary(SimAgent agent)
        {
            // Check, if a route already exists
            if(!(agent.Route == null || agent.Route.Count <= 0))
            {
                return;
            }

            // Instantiate new queue (just to be sure)
            agent.Route = new Queue<Datamodel.AbstractEdge>();

            // Add current edge (the starting edge so to say)
            agent.Route.Enqueue(dataManager_.GetEdgeForId(agent.EdgeId));

            // Get a list of all possible successor edges
            IReadOnlyList<Datamodel.Edge> successors = dataManager_.GetSuccessorEdges(agent.EdgeId);
            if (successors.Count <= 0)
                return;

            while (successors != null && successors.Count > 0) {
                // Randomly choose a successor edge
                Random rnd = new Random();
                int randomPosition = rnd.Next(successors.Count);
                Datamodel.Edge nextEdge = successors[randomPosition];
                agent.Route.Enqueue(nextEdge);

                // Fetch successors for the next edge
                successors = dataManager_.GetSuccessorEdges(nextEdge.Id);
            }

            Console.WriteLine("Calculated new route for agent #" + agent.Id);
        }

        /// <summary>
        /// Adapts the behaviour of the passed agent. For example adapts the current acceleration.
        /// </summary>
        /// <param name="agent">Agent for whom you want to recalculate the behaviour</param>
        private void updateBehaviour(SimAgent agent)
        {
            double SAFE_DISTANCE = 5; // meters

            // Calculate braking distance for the current velocity + add the safe distance
            double brakingDistance = getBrakingDistance(agent.CurrentVelocityExact, agent.Deceleration);
            brakingDistance += SAFE_DISTANCE + agent.VehicleLength;

            // Check, if there's an obstacle in the braking distance
            IReadOnlyList<SimAgent> agentsInBrakingDistance = dataManager_.GetAgentsInRange(agent.EdgeId, agent.RunLength, (int)brakingDistance);
            if(agentsInBrakingDistance.Count > 0)
            {
                // Brake!
                agent.CurrentAccelerationExact = agent.Deceleration;
            } else
            {
                // Go!
                agent.CurrentAccelerationExact = agent.Acceleration;
            }

            Console.WriteLine("Updated behaviour of agent #" + agent.Id);
        }


        /// <summary>
        /// Returns the braking distance in meters.
        /// </summary>
        /// <param name="velocity">The current velocity in m/s</param>
        /// <param name="deceleration">Deceleration in m^2/s</param>
        /// <returns></returns>
        private double getBrakingDistance(double velocity, double deceleration)
        {
            // s= v^2 / 2a
            return (velocity * velocity) / (2 * deceleration);
        }

    }
}
