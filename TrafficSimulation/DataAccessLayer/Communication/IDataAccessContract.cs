using Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Communication
{
    /// <summary>
    /// Interface for the WCF-Pipes-Contract.
    /// </summary>
    [ServiceContract(SessionMode = SessionMode.Required)]
    public interface IDataAccessContract
    {
        #region Agent

        /// <summary>
        /// Creates a new agent.
        /// </summary>
        /// <param name="agent">Agent to create</param>
        /// <returns>Created agent</returns>
        [OperationContract]
        Datamodel.Agent CreateAgent(Agent agent);

        /// <summary>
        /// Deletes an agent.
        /// </summary>
        /// <param name="agent">Agent to delete</param>
        [OperationContract]
        void DeleteAgent(Agent agent);

        /// <summary>
        /// Searches and returns agent with given id.
        /// </summary>
        /// <param name="agentId">Id of the agent</param>
        /// <returns>Found agent or null</returns>
        [OperationContract]
        Datamodel.Agent GetAgent(int agentId);

        /// <summary>
        /// Agents by positionIds.
        /// </summary>
        /// <param name="positionIds">Id of the position</param>
        /// <returns>agents or null</returns>
        [OperationContract]
        IEnumerable<Agent> GetAgentsForPositionIds(int positionIds);

        /// <summary>
        /// Get all agents.
        /// </summary>
        /// <returns>all agents or null</returns>
        [OperationContract]
        IEnumerable<Agent> GetAllAgents();

        /// <summary>
        /// Updates the given agent.
        /// </summary>
        /// <param name="agent">agent to update</param>
        /// <returns>updated agent</returns>
        [OperationContract]
        Datamodel.Agent UpdateAgent(Agent agent);

        /// <summary>
        /// Updates several agents.
        /// </summary>
        /// <param name="agent">List of agents</param>
        [OperationContract]
        void BulkUpdate(IEnumerable<Agent> agent);

        #endregion

        #region AgentSimConfiguration

        /// <summary>
        /// Get all AgentSimConfigurations.
        /// </summary>
        /// <returns>List of AgentSimConfigurations or null</returns>
        [OperationContract]
        IEnumerable<AgentSimConfiguration> GetAllAgentSimConfigurations();

        #endregion

        #region Edge

        /// <summary>
        /// Stores the given edge.
        /// </summary>
        /// <param name="edge">edge to save</param>
        /// <returns>Saved edge</returns>
        [OperationContract]
        Datamodel.Edge CreateEdge(Edge edge);

        /// <summary>
        /// Deletes given edge.
        /// </summary>
        /// <param name="edge">Edge to delete</param>
        [OperationContract]
        void DeleteEdge(Edge edge);

        /// <summary>
        /// Searches edge with given id.
        /// </summary>
        /// <param name="edgeId">Id of the searched edge</param>
        /// <returns>Edge or null</returns>
        [OperationContract]
        Edge GetEdge(int edgeId);

        /// <summary>
        /// Updates given edge.
        /// </summary>
        /// <param name="edge">Edge to update</param>
        /// <returns>Updated edge</returns>
        [OperationContract]
        Edge UpdateEdge(Edge edge);

        /// <summary>
        /// Get all edges.
        /// </summary>
        /// <returns>All edges or null</returns>
        [OperationContract]
        IEnumerable<Edge> GetAllEdges();

        #endregion

        #region Map

        /// <summary>
        /// Get the map.
        /// </summary>
        /// <returns>Map or null</returns>
        [OperationContract]
        Datamodel.Map GetMap();

        #endregion

        #region Position

        /// <summary>
        /// Saves position.
        /// </summary>
        /// <param name="position">Position to save</param>
        /// <returns>Saved position</returns>
        [OperationContract]
        Datamodel.Position CreatePosition(Position position);

        /// <summary>
        /// Deletes position.
        /// </summary>
        /// <param name="position">Position to delete</param>
        [OperationContract]
        void DeletePosition(Position position);

        /// <summary>
        /// Get position by its id.
        /// </summary>
        /// <param name="positionId">Id of position</param>
        /// <returns>Position or null</returns>
        [OperationContract]
        Datamodel.Position GetPosition(int positionId);

        /// <summary>
        /// Get predeccessors of specific position.
        /// </summary>
        /// <param name="numSteps">Number of predeccessors</param>
        /// <param name="startPositionId">Id of position</param>
        /// <returns>List of positions or null</returns>
        [OperationContract]
        IEnumerable<Position> GetPredeccessors(int numSteps, int startPositionId);

        /// <summary>
        /// Get successors of specific position.
        /// </summary>
        /// <param name="numSteps">Number of successors</param>
        /// <param name="startPositionId">Id of position</param>
        /// <returns>List of positions or null</returns>
        [OperationContract]
        IEnumerable<Position> GetSuccessors(int numSteps, int startPositionId);

        /// <summary>
        /// Get start positions.
        /// </summary>
        /// <returns>List of start positions or null</returns>
        [OperationContract]
        IEnumerable<Position> GetStartPositions();

        /// <summary>
        /// Get end positions.
        /// </summary>
        /// <returns>List of end positions or null</returns>
        [OperationContract]
        IEnumerable<Position> GetEndPositions();

        /// <summary>
        /// Get all positions.
        /// </summary>
        /// <returns>List of all positions or null</returns>
        [OperationContract]
        IEnumerable<Position> GetAllPositions();

        /// <summary>
        /// Updates given position.
        /// </summary>
        /// <param name="position">Position to update</param>
        /// <returns>Updated position</returns>
        [OperationContract]
        Datamodel.Position UpdatePosition(Position position);

        #endregion

        #region Rule

        /// <summary>
        /// Saves given rule.
        /// </summary>
        /// <param name="rule">Rule to save</param>
        /// <returns>Saved rule</returns>
        [OperationContract]
        Datamodel.Rule CreateRule(Rule rule);

        /// <summary>
        /// Deletes given rule.
        /// </summary>
        /// <param name="rule">Rule to delete</param>
        [OperationContract]
        void DeleteRule(Rule rule);

        /// <summary>
        /// Get all rules.
        /// </summary>
        /// <returns>List of all rules or null</returns>
        [OperationContract]
        IEnumerable<Rule> GetAllRules();

        /// <summary>
        /// Get all dynamic rules.
        /// </summary>
        /// <returns>List of all dynamic rules or null</returns>
        [OperationContract]
        IEnumerable<Rule> GetDynamicRules();

        /// <summary>
        /// Get rule by id.
        /// </summary>
        /// <param name="ruleId">Id of rule</param>
        /// <returns>Rule or null</returns>
        [OperationContract]
        Datamodel.Rule GetRule(int ruleId);

        /// <summary>
        /// Get all static rules.
        /// </summary>
        /// <returns>List of all static rules or null</returns>
        [OperationContract]
        IEnumerable<Rule> GetStaticRules();

        /// <summary>
        /// Update rule.
        /// </summary>
        /// <param name="rule">Rule to update</param>
        /// <returns>Updated rule</returns>
        [OperationContract]
        Datamodel.Rule UpdateRule(Rule rule);

        #endregion

        #region Crossway
        /// <summary>
        /// Saves new crossway.
        /// </summary>
        /// <param name="crossway">Crossway to save</param>
        /// <returns>Saved crossway</returns>
        [OperationContract]
        Datamodel.Crossway CreateCrossway(Crossway crossway);

        /// <summary>
        /// Deletes crossway.
        /// </summary>
        /// <param name="crossway">Crossway to delete</param>
        [OperationContract]
        void DeleteCrossway(Crossway crossway);

        /// <summary>
        /// Get all crossways.
        /// </summary>
        /// <returns>List of all crossways or null</returns>
        [OperationContract]
        IEnumerable<Crossway> GetAllCrossways();

        /// <summary>
        /// Get crossqay by id.
        /// </summary>
        /// <param name="crosswayId">Id of crossway</param>
        /// <returns>Crossway or null</returns>
        [OperationContract]
        Datamodel.Crossway GetCrossway(int crosswayId);

        /// <summary>
        /// Updates given crossway.
        /// </summary>
        /// <param name="crossway">crossway to update</param>
        /// <returns>Updated crossway</returns>
        [OperationContract]
        Datamodel.Crossway UpdateCrossway(Crossway crossway);

        #endregion

        #region isAliveChecker

        /// <summary>
        /// Watchdogmethod for DataAccessService.
        /// </summary>
        /// <returns>true if alive</returns>
        [OperationContract]
        bool isAlive();

        #endregion

    }
}
