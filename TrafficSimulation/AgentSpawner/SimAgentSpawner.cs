using DataManager;
using System;

namespace AgentSpawner
{
    public class SimAgentSpawner : IAgentSpawner
    {
        private readonly IDataManager dataManager_;

        public SimAgentSpawner(IDataManager dataManager)
        {
            dataManager_ = dataManager;
        }

        public void Start()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }
}
