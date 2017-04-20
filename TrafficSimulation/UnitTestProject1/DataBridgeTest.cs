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
            Assert.AreEqual(map.Width, 1920);
            Assert.AreEqual(map.Height, 1080);
            //char [] text = "background.png oder Image Objekt.".ToCharArray();
            //Assert.AreEqual(map.BackgroundImageBase64, text);

        }
    }
}
