﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccessLayer;
using System.Collections.Generic;
using Datamodel;

namespace DataAccessLayerTest
{
    [TestClass]
    public class dataAccessLayertest
    {
        [TestMethod]
        public void DataAccessLayerReadFromFile()
        {

            IPostionDataAccess positionDataAccess = PositionDataAccessFactory.CreateRepository();
            IEdgeDataAccess edgeDataAccess = EdgeDataAccessFactory.CreateRepository();
            IAgentDataAccess agentDataAccess = AgentDataAccessFactory.CreateRepository();
            IRuleDataAccess ruleDataAccess = RuleDataAccessFactory.CreateRepository();

            positionDataAccess.LoadfromFile("position");
            edgeDataAccess.LoadfromFile("edge");
            agentDataAccess.LoadfromFile("agent");
            ruleDataAccess.LoadfromFile("rule");

            //List<Position> xx = positionDataAccess.ReadAll();
            //Edge xy = edgeDataAccess.ReadbyId(4);
            //Rule xz = ruleDataAccess.ReadbyId(1);
            Assert.IsTrue(true);
        }


        [TestMethod]
        public void createCrosswayFile()
        {

            ICrosswayDataAccess crosswayDataAccess = CrosswayDataAccessFactory.CreateRepository();

            Crossway crossway1 = new Crossway();
            Crossway crossway2 = new Crossway();

            CrosswayDirection crosswaydirection1 = new CrosswayDirection();
            CrosswayDirection crosswaydirection2 = new CrosswayDirection();

            List<int> concurGreen1 = new List<int>();
            concurGreen1.Add(1);
            concurGreen1.Add(2);

            List<int> concurGreen2 = new List<int>();
            concurGreen2.Add(3);
            concurGreen2.Add(4);

            crosswaydirection1.concurrentGreen = concurGreen1;
            crosswaydirection1.hightime = 25;

            crosswaydirection2.concurrentGreen = concurGreen2;
            crosswaydirection2.hightime = 25;


            crossway1.greenphase.Add(crosswaydirection1);
            crossway1.greenphase.Add(crosswaydirection2);

            crossway1 = crosswayDataAccess.Create(crossway1);
            
            crosswayDataAccess.SavetoFile("testtest");

            Assert.IsTrue(true);
        }


        [TestMethod]
        public void DataAccessPositionInit()
        {

            IPostionDataAccess positionDataAccess = PositionDataAccessFactory.CreateRepository();

            Position posi1 = new Position();
            posi1.Id = 1;
            posi1.MaxVelocity = 50;
            posi1 = positionDataAccess.Create(posi1);

            //List<Position> xx = positionDataAccess.ReadAll();
            //Assert.AreEqual(xx.Count, 1);

            Position posi2 = new Position();
            posi2.Id = 2;
            posi2.MaxVelocity = 60;
            posi2 = positionDataAccess.Create(posi2);

            //xx = positionDataAccess.ReadAll();
            //Assert.AreEqual(xx.Count, 2);

            Position posi3 = new Position();
            posi3.Id = 3;
            posi3.MaxVelocity = 90;
            posi3 = positionDataAccess.Create(posi3);

            //xx = positionDataAccess.ReadAll();
            //Assert.AreEqual(xx.Count, 3);

            posi3.MaxVelocity = 99;

            positionDataAccess.Update(posi3);

            Position posigotfromList = positionDataAccess.ReadbyId(3);
            Assert.AreEqual(posigotfromList.MaxVelocity, 99);

            positionDataAccess.Delete(posi2);
            posigotfromList = positionDataAccess.ReadbyId(posi2.Id);
            Assert.AreEqual(posigotfromList, null);

            //xx = positionDataAccess.ReadAll();
            //Assert.AreEqual(xx.Count, 2);

            Assert.IsTrue(true);
        }
    }
}
