using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Datamodel;
using Repositories;

namespace UnitTestProject1
{
    [TestClass]
    public class DataBridgeTest
    {
        IMapRepository mapRepository = MapRepositoryFactory.CreateRepository();
        IPositionRepository positionRepository = PositionRepositoryFactory.CreateRepository();
        [TestMethod]
        public void getMapTest()
        {
            
            Map map = mapRepository.GetMap();
            Assert.AreNotEqual(map.Width, 0); // 1920
            Assert.AreNotEqual(map.Height, 0); // 1080
            Assert.AreNotEqual(map.BackgroundImageBase64.Length, 0);
            
        }
        [TestMethod]
        public void createPosition()
        {
            Position position1 = new Position();
            position1 = positionRepository.Create(position1);
            Assert.AreNotEqual(position1.Id, 0);
        }
    }
}
