using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Datamodel;
using Repositories;

namespace UnitTestProject1
{
    [TestClass]
    public class DataBridgeTest
    {
        [TestMethod]
        public void getMapTest()
        {
            IMapRepository mapRepo = MapRepositoryFactory.CreateRepository();
            Map map = mapRepo.GetMap();
            Assert.AreNotEqual(map.Width, 0); // 1920
            Assert.AreNotEqual(map.Height, 0) // 1080
            Assert.AreNotEqual(map.BackgroundImageBase64.Length, 0);
            
        }
        [TestMethod]
        public void createPoint()
        {

            Assert.IsTrue(true);
        }
    }
}
