﻿using DataManager.MappingModels;
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
        /// Get a list of agents that are in the given range on the edge but in reverse order (use case is overtake)
        /// </summary>
        /// <param name="edgeId"></param>
        /// <param name="startRunLength"></param>
        /// <param name="range"></param>
        /// <returns></returns>
        IReadOnlyList<SimAgent> GetAgentsInRangeReverse(int edgeId, int startRunLength, int range);

        /// <summary>
        /// Creates a new dynamic edge in the data access layer
        /// </summary>
        /// <param name="edge">Edge that should be created</param>
        void CreateDynamicEdge(DynamicEdge edge);

        /// <summary>
        /// Deletes a dynamic edge in the data access layer
        /// </summary>
        /// <param name="edge">Edge that should be deleted</param>
        void DeleteDynamicEdge(DynamicEdge edge);

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
        /// <param name="edgeId">The id of the edge you want to know the successors for</param>
        /// <returns>Read-only list of successor edges</returns>
        IReadOnlyList<Edge> GetSuccessorEdges(int edgeId);

        /// <summary>
        /// Returns an edge for an ID
        /// </summary>
        /// <param name="edgeId">The edge you want to know return</param>
        /// <returns>Edge object</returns>
        Edge GetEdgeForId(int edgeId);

        /// <summary>
        /// Returns the static rule for an edgeId
        /// </summary>
        /// <param name="edgeId">Edge ID we want the static rule for</param>
        /// <returns>Static Rule for the given edgeId</returns>
        IReadOnlyList<Rule> GetStaticRulesForEdgeId(int edgeId);

        /// <summary>
        /// Returns rules (static + dynamic) for an edgeId
        /// </summary>
        /// <param name="edgeId">Edge ID we want the rules for</param>
        /// <returns>Rules for the given edgeId</returns>
        IReadOnlyList<Rule> GetAllRulesForEdgeId(int edgeId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="positionId"></param>
        /// <returns></returns>
        IReadOnlyList<Rule> GetAllRulesForPositionId(int positionId);

    }
}
