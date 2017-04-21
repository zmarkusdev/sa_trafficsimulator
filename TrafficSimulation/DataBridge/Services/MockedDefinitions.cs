using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBridge.Services
{
    class MockedDefinitions
    {
        static MockedDefinitions instance = null;
        private MockedDefinitions() { }
        static public MockedDefinitions getInstance()
        {
            if (instance == null)
                instance = new MockedDefinitions();
            return instance;
        }
        // lokale Anpassungen!
        private String backGroundMapfilename = "C:\\Users\\maximilian\\Githubs\\ADS\\TrafficSimulation\\DataBridge\\Resources\\backGroundMap.jpg";
        public string getbackGroundMapfilename() { return backGroundMapfilename; }
    }
}
