﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datamodel;

namespace DataBridge.Services
{

    class MockedAgentService : Repositories.IAgentRepository
    {
        private Agent agent1;
        private Agent agent2;

        public MockedAgentService()
        {
            agent1 = createAgent1();
            agent2 = createAgent2();
        }

        public Agent Create(Agent agent)
        {
            Agent newAgent = new Agent();
            newAgent.Id = 123;
            newAgent.Type = agent.Type;
            newAgent.Acceleration = agent.Acceleration;
            newAgent.CurrentVelocity = agent.CurrentVelocity;
            newAgent.Deceleration = agent.Deceleration;
            newAgent.MaxVelocity = agent.MaxVelocity;
            newAgent.EdgeId = agent.EdgeId;
            return newAgent;
        }

        public void Delete(Agent agent)
        {
            return;
        }

        public Agent GetAgent(int agentId)
        {
            Agent newAgent = new Agent();
            newAgent.Id = agentId;
            newAgent.Acceleration = 5;
            newAgent.CurrentVelocity = 120;
            newAgent.Deceleration = 0;
            newAgent.MaxVelocity = 423;
            newAgent.EdgeId = 1;
            return newAgent;
        }

        public IEnumerable<Agent> GetAgentsForPositionIds(int positionIds)
        {
            List<Agent> agents = new List<Agent>();
            agents.Add(agent1);
            agents.Add(agent2);

            return agents;
        }

        public IEnumerable<Agent> GetAllAgents()
        {
            List<Agent> agents = new List<Agent>();
            agents.Add(agent1);
            agents.Add(agent2);

            return agents;
        }

        public Agent Update(Agent agent)
        {
            agent1 = agent;
            return agent1;
        }

        private Agent createAgent1()
        {
            Agent agent1 = new Agent();
            agent1.Id = 1;
            agent1.Acceleration = 5;
            agent1.CurrentVelocity = 120;
            agent1.Deceleration = 0;
            agent1.MaxVelocity = 423;
            agent1.EdgeId = 1;
            return agent1;
        }

        private Agent createAgent2()
        {
            Agent agent2 = new Agent();
            agent2.Id = 2;
            agent2.Acceleration = 10;
            agent2.CurrentVelocity = 45;
            agent2.Deceleration = 3;
            agent2.MaxVelocity = 120;
            agent2.EdgeId = 2;
            return agent2;
        }
    }
}