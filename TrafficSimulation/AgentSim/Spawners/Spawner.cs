using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datamodel;
using Repositories;

namespace AgentSim.Spawners
{
    internal class Spawner : ISpawner
    {
        private IEnumerable<Position> possibleStartPositions_;

        public Spawner(IPositionRepository positionRepository)
        {
            possibleStartPositions_ = positionRepository.GetStartPositions();
        }

        public IEnumerable<Agent> SpawnAgents(IEnumerable<AgentSimConfiguration> simConfiguration)
        {
            throw new NotImplementedException();
        }
    }
}
