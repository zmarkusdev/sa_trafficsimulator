using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO.Pipes;
using Datamodel;
using DataAccessLayer.Controller;
using DataModel.Pipe;
using System.Text;
using System.Threading;
using System.Collections.Generic;
using DataBridge.Controller;
using DataAccessLayer;
using DataAccessLayer.Services;

namespace DataAccessLayerTest
{
    [TestClass]
    public class ControllerTest
    {
        private JsonStreamConverter converter = JsonStreamConverter.getInstance();

        [TestMethod]
        public void TestSingleObject()
        {
            IPipeService agentService = (IPipeService) AgentDataAccessFactory.CreateRepository();
                var controllerThread = new Thread(() => new PipeServer(PipeUtil.AGENT(), agentService));
                controllerThread.Start();
                Agent agent = new Agent();
                agent.Id = 123;
                agent.Type = AgentType.Car01;
                agent.Acceleration = 1;
                agent.CurrentVelocity = 1;
                agent.Deceleration = 1;
                agent.MaxVelocity = 1;
                agent.EdgeId = 1;
                agent.RunLength = 0;
                agent.VehicleLength = 0;
                agent.VehicleWidth = 0;
                PipeClient client = new PipeClient(PipeUtil.AGENT());
                PipeDTO dto = new PipeDTO(Guid.NewGuid(), PipeCommand.GET_BY_ID, "123");
                PipeDTO returnedDTO = client.writeQueryWithReturnValue(dto);
                string serialised = converter.convertToJson<Agent>(agent);
                byte[] messageBytes = Encoding.UTF8.GetBytes(serialised);
        }

        [TestMethod]
        public void TestListOfObjects()
        {
            /*
            using (NamedPipeClientStream namedPipeClient = new NamedPipeClientStream(PipeUtil.AGENT()))
            {
                var controllerThread = new Thread(() => new AgentController());
                controllerThread.Start();
                List<Agent> agents = new List<Agent>();
                for (int i = 0; i < 10; i++)
                {
                    Agent agent = new Agent();
                    agent.Id = i;
                    agent.Type = AgentType.Car01;
                    agent.Acceleration = i;
                    agent.CurrentVelocity = i;
                    agent.Deceleration = i;
                    agent.MaxVelocity = i;
                    agent.EdgeId = i;
                    agent.RunLength = i;
                    agent.VehicleLength = i;
                    agent.VehicleWidth = i;
                    agents.Add(agent);
                }

                string serialised = converter.convertToJson<List<Agent>>(agents);
                namedPipeClient.Connect();
                byte[] messageBytes = Encoding.UTF8.GetBytes(serialised);
                namedPipeClient.Write(messageBytes, 0, messageBytes.Length);
            }
            */
        }
    }
}
