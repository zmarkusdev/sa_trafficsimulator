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
            IDataAccessLayerRepository dataAccessLayer = DataAccessLayerRepositoryFactory.CreateRepository();
            dataAccessLayer.Init();
            Assert.IsTrue(true);
        }
    }
}
