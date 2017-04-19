using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentSim.Spawners
{
    /// <summary>
    /// Spawner factory responsible for creating instances of the latest valid version of the ISpawner interface
    /// </summary>
    internal static class SpawnerFactory
    {
        /// <summary>
        /// Creates the instance of the latest valid version of the ISpawner interface
        /// </summary>
        /// <param name="positionRepository">PositionRepository dependency of the ISpawner implementations</param>
        /// <returns>Latest valid version of the ISpawner interface</returns>
        internal static ISpawner CreateSpawner(IPositionRepository positionRepository)
        {
            return new Spawner(positionRepository);
        }
    }
}
