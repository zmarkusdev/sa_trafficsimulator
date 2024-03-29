﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datamodel;
using System.ServiceModel;
using DataAccessLayer;

namespace DataAccessLayer.Communication
{
    /// <summary>
    /// Implementation of IDataAccessContract.
    /// </summary>
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession, ConcurrencyMode = ConcurrencyMode.Multiple)]
    class DataAccessService : IDataAccessContract
    {
        private IAgentDataAccess agentDataAccess;
        private IEdgeDataAccess edgeDataAccess;
        private IPostionDataAccess positionDataAccess;
        private IRuleDataAccess ruleDataAccess;
        private ICrosswayDataAccess crosswayDataAccess;

        /// <summary>
        /// Default constructor with init of all repositories.
        /// </summary>
        public DataAccessService()
        {
            agentDataAccess = AgentDataAccessFactory.CreateRepository();
            edgeDataAccess = EdgeDataAccessFactory.CreateRepository();
            positionDataAccess = PositionDataAccessFactory.CreateRepository();
            ruleDataAccess = RuleDataAccessFactory.CreateRepository();
            crosswayDataAccess = CrosswayDataAccessFactory.CreateRepository();
        }

        #region Agent

        public Agent CreateAgent(Agent agent)
        {
            return agentDataAccess.Create(agent);
        }

        public void DeleteAgent(Agent agent)
        {
            agentDataAccess.Delete(agent);
        }

        public Agent GetAgent(int agentId)
        {
            return agentDataAccess.ReadbyId(agentId);
        }

        public IEnumerable<Agent> GetAgentsForPositionIds(int positionIds)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<Agent> GetAllAgents()
        {
            var agents = agentDataAccess.ReadAll();
            return agents;
        }

        public Agent UpdateAgent(Agent agent)
        {
            agentDataAccess.Update(agent);
            return agent;
        }

        public void BulkUpdate(IEnumerable<Agent> agents)
        {
            foreach (var agent in agents)
                UpdateAgent(agent);
        }

        #endregion

        #region AgentSimConfiguration

        public IEnumerable<AgentSimConfiguration> GetAllAgentSimConfigurations()
        {
            // Example Configuration
            Random rnd = new Random();
            List<AgentSimConfiguration> agentSimConfigs = new List<AgentSimConfiguration>();

            AgentSimConfiguration agentSimConfig = new AgentSimConfiguration();
            agentSimConfig.Acceleration = 150;
            agentSimConfig.AccelerationSpread = 0;
            agentSimConfig.Deceleration = 250;
            agentSimConfig.DecelerationSpread = 0;
            agentSimConfig.SpawnPropability = 100;// rnd.Next(100);
            agentSimConfig.Velocity = 200;
            agentSimConfig.VelocitySpread = 50;
            agentSimConfig.AgentType = AgentType.Car01;
            agentSimConfig.VehicleLength = 30;
            
            agentSimConfig.VehicleLengthSpread = 0;
            agentSimConfigs.Add(agentSimConfig);

            return agentSimConfigs;
            //throw new NotImplementedException();
        }

        #endregion

        #region Edge
        public Edge CreateEdge(Edge edge)
        {
            return edgeDataAccess.Create(edge);
        }

        public void DeleteEdge(Edge edge)
        {
            edgeDataAccess.Delete(edge);
        }

        public Edge GetEdge(int edgeId)
        {
            return edgeDataAccess.ReadbyId(edgeId);
        }

        public Edge UpdateEdge(Edge edge)
        {
            edgeDataAccess.Update(edge);
            return edge;
        }

        public IEnumerable<Edge> GetAllEdges()
        {
            return edgeDataAccess.ReadAll();
        }

        #endregion

        #region Map

        public Map GetMap()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Position

        public Position CreatePosition(Position position)
        {
            return positionDataAccess.Create(position);
        }

        public void DeletePosition(Position position)
        {
            positionDataAccess.Delete(position);
        }

        public Position GetPosition(int positionId)
        {
            return positionDataAccess.ReadbyId(positionId);
        }

        public IEnumerable<Position> GetPredeccessors(int numSteps, int startPositionId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Position> GetSuccessors(int numSteps, int startPositionId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Position> GetStartPositions()
        {
            return positionDataAccess.ReadAll().Where(p => !p.PredecessorEdgeIds.Any());
        }

        public IEnumerable<Position> GetEndPositions()
        {
            return positionDataAccess.ReadAll().Where(p => !p.SuccessorEdgeIds.Any());
        }

        public IEnumerable<Position> GetAllPositions()
        {
            return positionDataAccess.ReadAll();
        }

        public Position UpdatePosition(Position position)
        {
            positionDataAccess.Update(position);
            return position;
        }

        #endregion

        #region Rule

        public Rule CreateRule(Rule rule)
        {
            return ruleDataAccess.Create(rule);
        }

        public void DeleteRule(Rule rule)
        {
            ruleDataAccess.Delete(rule);
        }

        public IEnumerable<Rule> GetAllRules()
        {
            return ruleDataAccess.ReadAll();
        }

        public IEnumerable<Rule> GetDynamicRules()
        {
            return ruleDataAccess.ReadAll().Where(cur => cur.IsDynamicRule);
        }

        public Rule GetRule(int ruleId)
        {
            return ruleDataAccess.ReadbyId(ruleId);
        }

        public IEnumerable<Rule> GetStaticRules()
        {
            return ruleDataAccess.ReadAll().Where(cur => !cur.IsDynamicRule);
        }

        public Rule UpdateRule(Rule rule)
        {
            ruleDataAccess.Update(rule);
            return rule;
        }

        #endregion

        #region Crossway

        public Crossway CreateCrossway(Crossway crossway)
        {
            return crosswayDataAccess.Create(crossway);
        }

        public void DeleteCrossway(Crossway crossway)
        {
            crosswayDataAccess.Delete(crossway);
        }

        public IEnumerable<Crossway> GetAllCrossways()
        {
            return crosswayDataAccess.ReadAll();
        }

        public Crossway GetCrossway(int crosswayId)
        {
            return crosswayDataAccess.ReadbyId(crosswayId);
        }

        public Crossway UpdateCrossway(Crossway crossway)
        {
            crosswayDataAccess.Update(crossway);
            return crossway;
        }

        #endregion

        #region alive
        public bool isAlive()
        {
            return true;
        }
        #endregion
    }
}
