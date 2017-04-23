using DataBridge.Repositories;
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

        // Synchronization queues
        private ConcurrentQueue<SimAgent> agentUpdateQueue_;        

        // Data containers
        private List<SimAgent> agents_;
        private List<SimRule> staticRules_;
        private List<SimRule> dynamicRules_;
        private List<SimPosition> startPositions_;
        private List<SimPosition> endPositions_;
        private List<SimPosition> positions_;
        private List<SimEdge> edges_;

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
            edgeRepository_ = EdgeRepositoryFactory.CreateRepository();

            // Initialize synchronization queues
            agentUpdateQueue_ = new ConcurrentQueue<SimAgent>();

            // Initialize data containers
            agents_ = new List<SimAgent>();
            staticRules_ = new List<SimRule>();
            dynamicRules_ = new List<SimRule>();
            startPositions_ = new List<SimPosition>();
            endPositions_ = new List<SimPosition>();
            positions_ = new List<SimPosition>();
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
                agents_.Add(simAgent);
            }

            // Get rule data
            IEnumerable<Rule> rules = ruleRepository_.GetAllRules();
            foreach(var rule in rules)
            {
                if (rule.IsDynamicRule)
                    dynamicRules_.Add(rule as SimRule);
                else
                    staticRules_.Add(rule as SimRule);
            }

            // Get start positions
            IEnumerable<Position> startPositions = positionRepository_.GetStartPositions();
            startPositions.ToList().ForEach(x => startPositions_.Add(x as SimPosition));

            // Get end positions
            IEnumerable<Position> endPositions = positionRepository_.GetEndPositions();
            endPositions.ToList().ForEach(x => endPositions_.Add(x as SimPosition));

            // Get positions
            IEnumerable<Position> positions = positionRepository_.GetAll();
            positions.ToList().ForEach(x => positions_.Add(x as SimPosition));

            // Get edges
            IEnumerable<Edge> edges = edgeRepository_.GetAll();
            edges.ToList().ForEach(x => edges_.Add(x as SimEdge));

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
                    agentRepository_.Update(updateAgent);

                // Update dynamic rules
                IEnumerable<Rule> remoteDynamicRules = ruleRepository_.GetDynamicRules();
                foreach(var rule in remoteDynamicRules)
                {
                    // Check if dynamic rule already exists
                    SimRule localRule = dynamicRules_.FirstOrDefault(r => r.Id == rule.Id);                    
                    if (localRule != null)
                    {
                        // Update
                        dynamicRules_.Remove(localRule);
                        dynamicRules_.Add(rule as SimRule);
                    }
                    else
                        // Create
                        dynamicRules_.Add(rule as SimRule);
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
