using Microsoft.VisualStudio.TestTools.UnitTesting;
using Datamodel;
using Repositories;
using System.Collections.Generic;
using System.Linq;
using System;
using DataAccessLayer;

namespace UnitTestProject1
{
    [TestClass]
    public class DataBridgeTest
    {
        IMapRepository mapRepository = MapRepositoryFactory.CreateRepository();
        IPositionRepository positionRepository = PositionRepositoryFactory.CreateRepository();
        IEdgeRepository edgeRepository = EdgeRepositoryFactory.CreateRepository();
        IAgentRepository agentRepository = AgentRepositoryFactory.CreateRepository();


        [TestMethod]
        public void getMapTest()
        {
            Map map = mapRepository.GetMap();
            Assert.AreNotEqual(map.Width, 0);
            Assert.AreNotEqual(map.Height, 0);
            Assert.AreNotEqual(map.BackgroundImageBase64.Length, 0);
        }
        [TestMethod]
        public void createPosition()
        {
            Position position1 = new Position();
            position1.Id = 99;
            position1 = positionRepository.Create(position1);
            Assert.AreEqual(position1.Id, 99);
        }
        [TestMethod]
        public void createEdge()
        {
            Edge edge1 = new Edge();
            edge1 = edgeRepository.Create(edge1);
            Edge edge2 = new Edge();
            edge2 = edgeRepository.Create(edge2);
            Assert.AreNotEqual(edge1.Id, edge2.Id);
        }
        [TestMethod]
        public void getAllEdges()
        {
            Edge edge1 = new Edge();
            edge1 = edgeRepository.Create(edge1);
            Edge edge2 = new Edge();
            edge2 = edgeRepository.Create(edge2);
            IEnumerable<Edge> listeEdges = edgeRepository.GetAll();
            Assert.AreNotEqual(listeEdges.Count(), 0);
        }
        [TestMethod]
        public void deleteEdge()
        {
            IEnumerable<Edge> edges = edgeRepository.GetAll();
            int vorher = edges.Count();
            Edge edge1 = new Edge();
            edge1 = edgeRepository.Create(edge1);
            Edge edge2 = new Edge();
            edge2 = edgeRepository.Create(edge2);
            edges = edgeRepository.GetAll();
            Assert.AreEqual(vorher + 2, edges.Count());
            edgeRepository.Delete(edge1);
            edgeRepository.Delete(edge2);
            edges = edgeRepository.GetAll();
            Assert.AreEqual(vorher, edges.Count());
        }

        [TestMethod]
        public void betterMockedPositionServis()
        {
            IPositionRepository positionRepo = PositionRepositoryFactory.CreateRepository();
            // hier ist alles geladen, oder auch nicht.
            Position posiDel = positionRepo.GetPosition(1);
            positionRepo.Delete(posiDel);
            positionRepo.Delete(posiDel);

            positionRepo.Update(posiDel);


            Assert.IsTrue(true);
        }



        [TestMethod]
        public void createSmallVillage()
        {
            DataAccessCommon commons = DataAccessCommon.getInstance();

            IPostionDataAccess positionDataAccess = PositionDataAccessFactory.CreateRepository(); // new PositionDataAccess();
            IEdgeDataAccess edgeDataAccess = EdgeDataAccessFactory.CreateRepository();
            IAgentDataAccess agentDataAccess = AgentDataAccessFactory.CreateRepository();
            IRuleDataAccess ruleDataAccess = RuleDataAccessFactory.CreateRepository();

            positionDataAccess.LoadfromFile("position");
            edgeDataAccess.LoadfromFile("edge");
            agentDataAccess.LoadfromFile("agent");

            Position readPosi = positionDataAccess.ReadbyId(3);
            Agent readAgent = agentDataAccess.ReadbyId(99);
            Rule readRule = ruleDataAccess.ReadbyId(2);
        }
    }
}
