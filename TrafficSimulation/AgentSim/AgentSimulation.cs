using DataManager;
using DataManager.MappingModels;
using Datamodel;
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
        private const int timerInterval = 1000 / 60; // 30 fps
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
            lock(dataManager_) allEdges_ = dataManager_.Edges;

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
            lock(dataManager_) agents.AddRange(dataManager_.Agents);

            // TODO: Get dynamic rules

            // Iterate over all agents and update their behaviour
            foreach(var agent in agents)
            {
                if (agent == null) return;

                var curAgent = agent.Clone() as SimAgent;
                //Console.WriteLine("Calculating behaviour of agent #" + agent.Id);

                // Check, if the agent has a defined route, otherwise calculate it.
                calculateRouteIfNeccessary(curAgent);

                // Update the behaviour (acceleration etc.)
                updateBehaviour(curAgent);

                // Update the agent
                dataManager_.UpdateAgent(curAgent);
            }
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

            //Console.WriteLine("Calculated new route for agent #" + agent.Id);
        }

        /// <summary>
        /// Adapts the behaviour of the passed agent. For example adapts the current acceleration.
        /// </summary>
        /// <param name="agent">Agent for whom you want to recalculate the behaviour</param>
        private void updateBehaviour(SimAgent agent)
        {
            agent.CurrentAccelerationExact = agent.Acceleration; // Default: fully accelerate
            const double SAFE_DISTANCE = 10.0; // meters
            const double MAX_SPEED = 200; // Max allowed speed
            double targetVelocity = MAX_SPEED;
            double brakingDistance = getBrakingDistance(agent.CurrentVelocityExact, agent.Deceleration) + agent.VehicleLength + SAFE_DISTANCE;

            // ############# START: Check Static Rules #############
            IReadOnlyList<Rule> staticRulesForCurrentEdge = dataManager_.GetStaticRulesForEdgeId(agent.EdgeId);
            foreach(Rule rule in staticRulesForCurrentEdge)
            {
                switch(rule.RuleType)
                {
                    case RuleType.Geschwindigkeit:
                        // Get maximum allowed speed
                        targetVelocity = rule.MaxVelocity > MAX_SPEED ? MAX_SPEED : rule.MaxVelocity;
                        break;
                    case RuleType.Vorrang:
                        // Get edge length
                        Edge edge = dataManager_.GetEdgeForId(agent.EdgeId);
                        int edgeLength = edge.CurveLength;
                        int agentCurrentRunLength = agent.RunLength;
                        int restLength = edgeLength - agentCurrentRunLength;
                        Console.WriteLine("restLength: " + restLength + ", brakingDistance: " + brakingDistance);
                        if(restLength <= brakingDistance)
                        {
                            targetVelocity = 0;
                            Console.WriteLine("STOPPING");
                        }
                        break;
                    case RuleType.Stopp:
                        Console.WriteLine("TODO: RuleType.Ampel");
                        break;
                    case RuleType.Ampel:
                        Console.WriteLine("TODO: RuleType.Ampel");
                        break;
                }
            }
            // ############# END: Check Speed Limit #############


            // ############# START: Static Rule Checking #############
            // Get all edges we have to check for other vehicles
            //int[]edgesToCheck = staticRule.CheckPositionIds.ToArray<int>();
            //Console.WriteLine("edgesToCheck: " + edgesToCheck.Count());
            //foreach(int checkEdgeId in edgesToCheck)
            //{
                // Check, if a vehicle is on the edge
                //targetVelocity = 0;
                //IReadOnlyList<SimAgent> enemyAgents = dataManager_.GetAgentsInRange(checkEdgeId, 0, 50);
                //if
            //}
            // ############# END: Static Rule Checking #############


            // ############# START: Safety Distance to other vehicles #############
            // Check, if there's an obstacle in the braking distance
            IReadOnlyList<SimAgent> agentsInBrakingDistance = dataManager_.GetAgentsInRange(agent.EdgeId, agent.RunLength, (int)brakingDistance);
            foreach(SimAgent otherAgent in agentsInBrakingDistance)
            {
                // Ignore self
                if(otherAgent.Id == agent.Id)
                {
                    continue;
                }

                // Get delta velocity
                double deltaV = agent.CurrentVelocityExact - otherAgent.CurrentVelocityExact;

                // If the other agent is faster than we are, we ignore him
                if (deltaV <= 0)
                {
                    continue;
                }

                // Our target velocity is the one of the other agent
                if (otherAgent.CurrentVelocityExact < targetVelocity)
                {
                    targetVelocity = otherAgent.CurrentVelocityExact;
                }
            }
            // ############# END: Safety Distance to other vehicles #############

            // Accelerate
            if (targetVelocity > agent.CurrentVelocityExact)
            {
                agent.CurrentAccelerationExact = agent.Acceleration;
            }
            // Decelerate
            else
            {
                agent.CurrentAccelerationExact = -agent.Deceleration;
            }

        }


        /// <summary>
        /// Returns the braking distance in pixel.
        /// </summary>
        /// <param name="velocity">The current velocity in pixel/s</param>
        /// <param name="deceleration">Deceleration in pixel^2/s</param>
        /// <returns></returns>
        private double getBrakingDistance(double velocity, double deceleration)
        {
            // s= v^2 / 2a
            return (velocity * velocity) / (2 * deceleration);
        }

    }
}
