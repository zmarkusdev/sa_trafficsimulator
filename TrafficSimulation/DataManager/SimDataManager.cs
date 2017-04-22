using DataBridge.Datamodel;
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

        // Synchronization queues
        private ConcurrentQueue<SimAgent> agentUpdateQueue_;        

        // Data containers
        private ConcurrentDictionary<int, SimAgent> agents_;
        private ConcurrentDictionary<int, Rule> staticRules_;
        private ConcurrentDictionary<int, Rule> dynamicRules_;
        private ConcurrentDictionary<int, Position> startPositions_;
        private ConcurrentDictionary<int, Position> endPositions_;
        private ConcurrentDictionary<int, Position> positions_;

        /// <summary>
        /// Singleton instance of the SimDataManager
        /// </summary>
        public static readonly SimDataManager Instance = new SimDataManager();

        private SimDataManager()
        {
            // Get data access dependencies
            agentRepository_ = AgentRepositoryFactory.CreateRepository();
            ruleRepository_ = RuleRepositoryFactory.CreateRepository();
            positionRepository_ = PositionRepositoryFactory.CreateRepository();

            // Initialize synchronization queues
            agentUpdateQueue_ = new ConcurrentQueue<SimAgent>();

            // Initialize data containers
            agents_ = new ConcurrentDictionary<int, SimAgent>();
            staticRules_ = new ConcurrentDictionary<int, Rule>();
            dynamicRules_ = new ConcurrentDictionary<int, Rule>();
            startPositions_ = new ConcurrentDictionary<int, Position>();
            endPositions_ = new ConcurrentDictionary<int, Position>();
            positions_ = new ConcurrentDictionary<int, Position>();
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
                var simAgent = existingAgent as SimAgent;
                simAgent.Route = new Queue<AbstractEdge>();
                agents_.TryAdd(simAgent.Id ,simAgent);
            }

            // Get rule data
            IEnumerable<Rule> rules = ruleRepository_.GetAllRules();
            foreach(var rule in rules)
            {
                if (rule.IsDynamicRule)
                    dynamicRules_.TryAdd(rule.Id, rule);
                else
                    staticRules_.TryAdd(rule.Id, rule);
            }

            // Get start positions
            IEnumerable<Position> startPositions = positionRepository_.GetStartPositions();
            foreach (var position in startPositions)
                startPositions_.TryAdd(position.Id, position);

            // Get end positions
            IEnumerable<Position> endPositions = positionRepository_.GetEndPositions();
            foreach (var position in endPositions)
                endPositions_.TryAdd(position.Id, position);

            // Get positions
            IEnumerable<Position> positions = positionRepository_.GetAll();
            foreach (var position in positions)
                positions_.TryAdd(position.Id, position);

            throw new NotImplementedException();
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
        }

        /// <summary>
        /// Runs the data access synchronization
        /// </summary>
        private void RunSync()
        {
            while(!shouldStop_)
            {
                Console.WriteLine("Executing data synchronization");

                // Update agents from the udpate queue
                SimAgent updateAgent;
                while(agentUpdateQueue_.TryDequeue(out updateAgent))
                {
                    agentRepository_.Update(updateAgent);
                }

                // Update dynamic rules
                IEnumerable<Rule> remoteDynamicRules = ruleRepository_.GetDynamicRules();
                foreach(var rule in remoteDynamicRules)
                {
                    // Check if dynamic rule already exists
                    Rule localRule;                    
                    if (dynamicRules_.TryGetValue(rule.Id, out localRule))
                    {
                        // Update
                        dynamicRules_.TryUpdate(rule.Id, rule, localRule);
                    }
                    else
                    {
                        // Create
                        dynamicRules_.TryAdd(rule.Id, rule);
                    }
                }

                Thread.Sleep(100);
            }
        }

        /// <summary>
        /// Adds the given sim agent object to the update queue
        /// </summary>
        /// <param name="updateAgent">The agent that needs to be updated</param>
        public void Update(SimAgent updateAgent)
        {
            agentUpdateQueue_.Enqueue(updateAgent);
        }
    }
}
