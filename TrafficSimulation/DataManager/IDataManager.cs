using DataManager.MappingModels;
using Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager
{
    /// <summary>
    /// Data manager interface for local memory management of the simulation components.
    /// </summary>
    public interface IDataManager
    {
        /// <summary>
        /// Prepare dependencies to data access and build object graph
        /// </summary>
        void Initialize();

        /// <summary>
        /// Start synchronization (dynamic rules should be fetched here periodically)
        /// </summary>
        void Start();

        /// <summary>
        /// Stops the synchronization
        /// </summary>
        void Stop();

        /// <summary>
        /// Updates the given agent in the data access component
        /// </summary>
        /// <param name="updateAgent">The agent that needs to be updated</param>
        void UpdateAgent(SimAgent updateAgent);

        /// <summary>
        /// Creates the given agent in the data access component
        /// </summary>
        /// <param name="createAgent">The agent that should be created</param>
        void CreateAgent(SimAgent createAgent);

        /// <summary>
        /// All currently active agents in the simulation
        /// </summary>
        IReadOnlyList<SimAgent> Agents { get; }

        /// <summary>
        /// All rules of the map
        /// </summary>
        IReadOnlyList<Rule> Rules { get; }

        /// <summary>
        /// Start positions of the map
        /// </summary>
        IReadOnlyList<Position> StartPositions { get; }

        /// <summary>
        /// End positions of the map
        /// </summary>
        IReadOnlyList<Position> EndPositions { get; }

        /// <summary>
        /// All positions of the map
        /// </summary>
        IReadOnlyList<Position> AllPositions { get; }

        /// <summary>
        /// All edges on the map
        /// </summary>
        IReadOnlyList<Edge> Edges { get; }
    }
}
