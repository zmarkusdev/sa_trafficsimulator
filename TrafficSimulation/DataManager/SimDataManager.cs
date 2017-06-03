using DataManager.MappingModels;
using Datamodel;
using Repositories;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataManager
{
    /// <summary>
    /// SimDataManager class for handling the memory of the simulation components.
    /// Implementation as singleton, before usage, the method "Initialize" must be called
    /// prior to using the other methods of the manager.
    /// Example instantiation:
    /// IDataManager dataManager = SimDataManager.Instance;
    /// dataManager.Initialize();
    /// dataManager.Start();
    /// </summary>
    public class SimDataManager : IDataManager
    {
        private bool shouldStop_;
        private Thread syncThread_;

        // Data access dependencies
        private readonly IAgentRepository agentRepository_;
        private readonly IRuleRepository ruleRepository_;
        private readonly IPositionRepository positionRepository_;
        private readonly IEdgeRepository edgeRepository_;
        private readonly IAgentSimConfigurationRepository agentSimConfigurationRepository_;

        // Synchronization queues
        private ConcurrentQueue<SimAgent> agentUpdateQueue_;

        // Data containers
        private List<SimAgent> agents_;
        private List<Rule> staticRules_;
        private List<Rule> dynamicRules_;
        private List<Position> startPositions_;
        private List<Position> endPositions_;
        private List<Position> positions_;
        private List<Edge> edges_;
        private List<AgentSimConfiguration> agentSimConfigurations_;

        /// <summary>
        /// All currently active agents in the simulation
        /// </summary>
        public IReadOnlyList<SimAgent> Agents
        {
            get
            {
                lock(agents_) return agents_.AsReadOnly();
            }
        } 

        /// <summary>
        /// All rules of the map
        /// </summary>
        public IReadOnlyList<Rule> Rules
        {
            get
            {
                var allRules = new List<Rule>();
                allRules.AddRange(staticRules_);
                allRules.AddRange(dynamicRules_);
                return allRules.AsReadOnly();
            }
        }

        /// <summary>
        /// Start positions of the map
        /// </summary>
        public IReadOnlyList<Position> StartPositions => startPositions_.AsReadOnly();

        /// <summary>
        /// End positions of the map
        /// </summary>
        public IReadOnlyList<Position> EndPositions => endPositions_.AsReadOnly();

        /// <summary>
        /// All positions of the map
        /// </summary>
        public IReadOnlyList<Position> AllPositions => positions_.AsReadOnly();

        /// <summary>
        /// All edges on the map
        /// </summary>
        public IReadOnlyList<Edge> Edges => edges_.AsReadOnly();

        /// <summary>
        /// Singleton instance of the SimDataManager
        /// </summary>
        public static readonly SimDataManager Instance = new SimDataManager();

        /// <summary>
        /// Agent simulation configurations for spawning new agents in the simulation
        /// </summary>
        public IReadOnlyList<AgentSimConfiguration> AgentSimConfigurations => agentSimConfigurations_.AsReadOnly();

        private SimDataManager()
        {
            // Get data access dependencies
            agentRepository_ = AgentRepositoryFactory.CreateRepository();
            ruleRepository_ = RuleRepositoryFactory.CreateRepository();
            positionRepository_ = PositionRepositoryFactory.CreateRepository();
            edgeRepository_ = EdgeRepositoryFactory.CreateRepository();
            agentSimConfigurationRepository_ = AgentSimConfigurationRepositoryFactory.CreateRepository();

            // Initialize synchronization queues
            agentUpdateQueue_ = new ConcurrentQueue<SimAgent>();

            // Initialize data containers
            agents_ = new List<SimAgent>();
            staticRules_ = new List<Rule>();
            dynamicRules_ = new List<Rule>();
            startPositions_ = new List<Position>();
            endPositions_ = new List<Position>();
            positions_ = new List<Position>();
            edges_ = new List<Edge>();
            agentSimConfigurations_ = new List<AgentSimConfiguration>();
        }

        /// <summary>
        /// Loads data objects from the data access component and maps them to their corresponding sim variants.
        /// </summary>
        public void Initialize()
        {
            // Get agent data
            IEnumerable<Agent> existingAgents = agentRepository_.GetAllAgents();
            foreach (var existingAgent in existingAgents)
            {
                var simAgent = new SimAgent(existingAgent);
                agents_.Add(simAgent);
            }

            // Get rule data
            IEnumerable<Rule> rules = ruleRepository_.GetAllRules();
            foreach (var rule in rules)
            {
                if (rule.IsDynamicRule)
                    dynamicRules_.Add(rule);
                else
                    staticRules_.Add(rule);
            }

            // Get start positions
            IEnumerable<Position> startPositions = positionRepository_.GetStartPositions();
            startPositions.ToList().ForEach(startPositions_.Add);

            // Get end positions
            IEnumerable<Position> endPositions = positionRepository_.GetEndPositions();
            endPositions.ToList().ForEach(endPositions_.Add);

            // Get positions
            IEnumerable<Position> positions = positionRepository_.GetAll();
            positions.ToList().ForEach(positions_.Add);

            // Get edges
            IEnumerable<Edge> edges = edgeRepository_.GetAll();
            edges.ToList().ForEach(edges_.Add);

            // Get agent sim configurations
            IEnumerable<AgentSimConfiguration> agentSimConfigurations = agentSimConfigurationRepository_.GetAll();
            agentSimConfigurations.ToList().ForEach(agentSimConfigurations_.Add);
        }

        /// <summary>
        /// Start the synchronization thread for data synchronization to the data access component in the background
        /// </summary>
        public void Start()
        {
            shouldStop_ = false;

            syncThread_ = new Thread(RunSync);
            syncThread_.Start();
        }

        /// <summary>
        /// Stops the synchronization thread.
        /// </summary>
        public void Stop()
        {
            shouldStop_ = true;
            // Wait until the sync thread is terminated
            while (syncThread_.IsAlive) Thread.Sleep(100);
        }

        /// <summary>
        /// Runs the data access synchronization
        /// </summary>
        private void RunSync()
        {
            while (!shouldStop_)
            {
                var agentsToUpdate = agentUpdateQueue_.Select(a => a.ToAgent());
                if (agentsToUpdate.Any())
                {
                    agentRepository_.BulkUpdate(agentsToUpdate);
                    agentUpdateQueue_ = new ConcurrentQueue<SimAgent>();
                }
                
                // Update dynamic rules
                //IEnumerable<Rule> remoteDynamicRules = ruleRepository_.GetDynamicRules();
                //foreach (var rule in remoteDynamicRules)
                //{
                //    // Check if dynamic rule already exists
                //    Rule localRule = dynamicRules_.FirstOrDefault(r => r.Id == rule.Id);
                //    if (localRule != null)
                //    {
                //        // Update
                //        dynamicRules_.Remove(localRule);
                //        dynamicRules_.Add(rule);
                //    }
                //    else
                //        // Create
                //        dynamicRules_.Add(rule);
                //}

                Thread.Sleep(1000 / 30);
            }
        }

        /// <summary>
        /// Adds the given sim agent object to the update queue
        /// </summary>
        /// <param name="updateAgent">The agent that needs to be updated</param>
        public void UpdateAgent(SimAgent updateAgent)
        {            
            // Update agent in the current agent list
            lock (this)
            {
                // Dequeue all previous updates
                agentUpdateQueue_ = new ConcurrentQueue<SimAgent>(agentUpdateQueue_.Where(a => a.Id != updateAgent.Id));

                // Queue new update
                agentUpdateQueue_.Enqueue(updateAgent);

                // Get current agent
                var currentAgent = agents_.FirstOrDefault(a => a.Id == updateAgent.Id);

                // Delete it from the list
                agents_.Remove(currentAgent);

                // Add updated agent to the list again
                agents_.Add(updateAgent);
            }
        }

        /// <summary>
        /// Creates the given agent in the data access component
        /// </summary>
        /// <param name="createAgent">The agent that should be created</param>
        public void CreateAgent(SimAgent createAgent)
        {
            lock (this)
            {
                var result = agentRepository_.Create(createAgent.ToAgent());
                createAgent.Id = result.Id;

                // Add create agent to the local list of agents
                agents_.Add(createAgent);
            }
        }

        /// <summary>
        /// Deletes the given agent in the data access component
        /// </summary>
        /// <param name="deleteAgent">The agent that should be created</param>
        public void DeleteAgent(SimAgent deleteAgent)
        {           
            lock(this)
            {
                agentUpdateQueue_ = new ConcurrentQueue<SimAgent>(agentUpdateQueue_.Where(a => a.Id != deleteAgent.Id));

                agentRepository_.Delete(deleteAgent.ToAgent());

                // Remove agent from local list of agents
                SimAgent realDeleteAgent = agents_.First(a => a.Id == deleteAgent.Id);
                agents_.Remove(realDeleteAgent);
            }
        }

        /// <summary>
        /// Check edge and successor edges for possible agents in the given range, returns list
        /// of agents in the range.
        /// Doesn't check for a specific route on edge overflow!
        /// </summary>
        /// <param name="edgeId">Id of the starting edge</param>
        /// <param name="startRunLength">Start point on the edge in meters</param>
        /// <param name="range">Range in meters to look for agents, successor edges should be included if overflowing</param>
        /// <returns>List of SimAgents contained in the given range</returns>
        public IReadOnlyList<SimAgent> GetAgentsInRange(int edgeId, int startRunLength, int range)
        {
            lock(this)
            {
                // Prepare result list
                var results = new List<SimAgent>();

                // Get edge by id
                var edge = edges_.FirstOrDefault(e => e.Id == edgeId);
                if (edge == null)
                    return results.AsReadOnly();

                // Check if params are valid
                if (startRunLength > edge.CurveLength)
                    throw new ArgumentException("Start run length is longer than the edge length");

                // Get agents greater startrunlength and smaller startrunlength 
                List<SimAgent> agents;
                lock (Agents) agents = Agents.Where(a => a.EdgeId == edge.Id &&
                    a.RunLength - a.VehicleLength >= startRunLength &&
                    a.RunLength - a.VehicleLength < startRunLength + range).ToList();

                // Add selected agents to the result
                results.AddRange(agents);

                // Check if range exceeds current edge length
                if (startRunLength + range > edge.CurveLength)
                {
                    // Get end point
                    var endPoint = positions_.FirstOrDefault(p => p.Id == edge.EndPositionId);
                    if (endPoint != null)
                    {
                        foreach (var successorEdgeId in endPoint.SuccessorEdgeIds)
                            results.AddRange(GetAgentsInRange(successorEdgeId, 0, startRunLength + range - edge.CurveLength));
                    }
                }

                return results;
            }
        }


        /// <summary>
        /// Returns all successors for a given edge.
        /// </summary>
        /// <param name="edgeId">The edge you want to know the successors for</param>
        /// <returns>Read-only list of successor edges</returns>
        public IReadOnlyList<Edge> GetSuccessorEdges(int edgeId)
        {
            Edge edge = edges_.FirstOrDefault(e => e.Id == edgeId);
            return edges_.FindAll(p => p.StartPositionId == edge.EndPositionId && p.Id != edgeId);
        }

        /// <summary>
        /// Returns an edge for an ID
        /// </summary>
        /// <param name="edge">The edge you want to know return</param>
        /// <returns>Edge object</returns>
        public Edge GetEdgeForId(int edgeId)
        {
            return edges_.Find(p => p.Id == edgeId);
        }

    }
}
