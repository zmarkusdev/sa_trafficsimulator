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
        /// Deletes the given agent in the data access component
        /// </summary>
        /// <param name="deleteAgent">The agent that should be created</param>
        void DeleteAgent(SimAgent deleteAgent);

        /// <summary>
        /// Check edge and successor edges for possible agents in the given range, returns list
        /// of agents in the range.
        /// Doesn't check for a specific route on edge overflow!
        /// </summary>
        /// <param name="edgeId">Id of the starting edge</param>
        /// <param name="startRunLength">Start point on the edge in meters</param>
        /// <param name="range">Range in meters to look for agents, successor edges should be included if overflowing</param>
        /// <returns>List of SimAgents contained in the given range</returns>
        IReadOnlyList<SimAgent> GetAgentsInRange(int edgeId, int startRunLength, int range);

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

        /// <summary>
        /// Agent simulation configurations for spawning new agents in the simulation
        /// </summary>
        IReadOnlyList<AgentSimConfiguration> AgentSimConfigurations { get; }

        /// <summary>
        /// Returns all successors for a given edge.
        /// </summary>
        /// <param name="edge">The edge you want to know the successors for</param>
        /// <returns>Read-only list of successor edges</returns>
        IReadOnlyList<Edge> GetSuccessorEdges(int edgeId);

        /// <summary>
        /// Returns an edge for an ID
        /// </summary>
        /// <param name="edge">The edge you want to know return</param>
        /// <returns>Edge object</returns>
        Edge GetEdgeForId(int edgeId);

    }
}
