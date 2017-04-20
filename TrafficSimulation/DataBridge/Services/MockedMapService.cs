using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datamodel;

namespace DataBridge.Services
{
    class MockedMapService : IMapRepository
    {
        Map map = null;
        List<Position> test = null;
        public MockedMapService()
        {
            // eine Map 
            map = new Map();
            string imagedata = "background.png oder Image Objekt.";
            map.BackgroundImageBase64 = imagedata.ToCharArray();
            map.Height = 1080;
            map.Width = 1920;

            // Positions 

        }
        public Map GetMap()
        {
            return map;
        }
    }
}
