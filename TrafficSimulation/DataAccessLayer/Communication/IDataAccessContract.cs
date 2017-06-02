using Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Communication
{
    [ServiceContract]
    public interface IDataAccessContract
    {
        #region Agent

        [OperationContract]
        Datamodel.Agent CreateAgent(Agent agent);

        [OperationContract]
        void DeleteAgent(Agent agent);

        [OperationContract]
        Datamodel.Agent GetAgent(int agentId);

        [OperationContract]
        IEnumerable<Agent> GetAgentsForPositionIds(int positionIds);

        [OperationContract]
        IEnumerable<Agent> GetAllAgents();

        [OperationContract]
        Datamodel.Agent UpdateAgent(Agent agent);

        #endregion

        #region AgentSimConfiguration

        [OperationContract]
        IEnumerable<AgentSimConfiguration> GetAllAgentSimConfigurations();

        #endregion

        #region Edge

        [OperationContract]
        Datamodel.Edge CreateEdge(Edge edge);

        [OperationContract]
        void DeleteEdge(Edge edge);

        [OperationContract]
        Edge GetEdge(int edgeId);

        [OperationContract]
        Edge UpdateEdge(Edge edge);

        [OperationContract]
        IEnumerable<Edge> GetAllEdges();

        #endregion

        #region Map

        [OperationContract]
        Datamodel.Map GetMap();

        #endregion

        #region Position

        [OperationContract]
        Datamodel.Position CreatePosition(Position position);

        [OperationContract]
        void DeletePosition(Position position);

        [OperationContract]
        Datamodel.Position GetPosition(int positionId);

        [OperationContract]
        IEnumerable<Position> GetPredeccessors(int numSteps, int startPositionId);

        [OperationContract]
        IEnumerable<Position> GetSuccessors(int numSteps, int startPositionId);

        [OperationContract]
        IEnumerable<Position> GetStartPositions();

        [OperationContract]
        IEnumerable<Position> GetEndPositions();

        [OperationContract]
        IEnumerable<Position> GetAllPositions();

        [OperationContract]
        Datamodel.Position UpdatePosition(Position position);

        #endregion

        #region Rule

        [OperationContract]
        Datamodel.Rule CreateRule(Rule rule);

        [OperationContract]
        void DeleteRule(Rule rule);

        [OperationContract]
        IEnumerable<Rule> GetAllRules();

        [OperationContract]
        IEnumerable<Rule> GetDynamicRules();

        [OperationContract]
        Datamodel.Rule GetRule(int ruleId);

        [OperationContract]
        IEnumerable<Rule> GetStaticRules();

        [OperationContract]
        Datamodel.Rule UpdateRule(Rule rule);

        #endregion

        #region isAliveChecker

        [OperationContract]
        bool isAlive();

        #endregion


    }
}
