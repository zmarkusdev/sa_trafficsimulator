using DataAccessLayer.Controller;
using Datamodel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Test
{
    [TestClass]
    public class StreamConverterTest
    {
        [TestMethod]
        public void testConvertObject()
        {
            StreamConverter converter = StreamConverter.getInstance();

            Agent agent = new Agent();
            agent.Id = 2;
            agent.Acceleration = 10;
            agent.CurrentVelocity = 45;
            agent.Deceleration = 3;
            agent.MaxVelocity = 120;
            agent.EdgeId = 2;

            String agentString = converter.convertToJson<Agent>(agent);

            Console.WriteLine(agentString);

            Agent convertedAgent = converter.convertFromJson<Agent>(agentString);

            Assert.AreEqual(agent.Id, convertedAgent.Id);
            Assert.AreEqual(agent.Acceleration, convertedAgent.Acceleration);
            Assert.AreEqual(agent.CurrentVelocity, convertedAgent.CurrentVelocity);
            Assert.AreEqual(agent.Deceleration, convertedAgent.Deceleration);
            Assert.AreEqual(agent.MaxVelocity, convertedAgent.MaxVelocity);
            Assert.AreEqual(agent.EdgeId, convertedAgent.EdgeId);
        }

        [TestMethod]
        public void testConvertList()
        {
            StreamConverter converter = StreamConverter.getInstance();

            List<Agent> agents = new List<Agent>();

            for (int i = 0; i < 10; i++)
            {
                Agent agent = new Agent();
                agent.Id = i;
                agent.Acceleration = i;
                agent.CurrentVelocity = i;
                agent.Deceleration = i;
                agent.MaxVelocity = i;
                agent.EdgeId = i;

                agents.Add(agent);
            }

            String agentsString = converter.convertListToJson<Agent>(agents);

            Console.WriteLine(agentsString);

            List<Agent> convertedAgents = converter.convertFromJson<List<Agent>>(agentsString);

            for (int i = 0; i < 10; i++)
            {
                Agent convertedAgent = convertedAgents.First();
                Agent agent = agents.First();

                Assert.AreEqual(agent.Id, convertedAgent.Id);
                Assert.AreEqual(agent.Acceleration, convertedAgent.Acceleration);
                Assert.AreEqual(agent.CurrentVelocity, convertedAgent.CurrentVelocity);
                Assert.AreEqual(agent.Deceleration, convertedAgent.Deceleration);
                Assert.AreEqual(agent.MaxVelocity, convertedAgent.MaxVelocity);
                Assert.AreEqual(agent.EdgeId, convertedAgent.EdgeId);

                convertedAgents.Remove(convertedAgent);
                agents.Remove(agent);
            }

        }
    }
}
