using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccessLayer;
namespace DataAccessLayerTest
{
    [TestClass]
    public class dataAccessLayertest
    {
        [TestMethod]
        public void DataAccessLayerInit()
        {

            IPostionDataAccess positionDataAccess = PositionDataAccessFactory.CreateRepository();
            IEdgeDataAccess edgeDataAccess = EdgeDataAccessFactory.CreateRepository();
            IAgentDataAccess agentDataAccess = AgentDataAccessFactory.CreateRepository();
            IRuleDataAccess ruleDataAccess = RuleDataAccessFactory.CreateRepository();

            positionDataAccess.LoadfromFile("position");
            edgeDataAccess.LoadfromFile("edge");
            agentDataAccess.LoadfromFile("agent");
            ruleDataAccess.LoadfromFile("rule");
            
            Assert.IsTrue(true);
        }
    }
}
