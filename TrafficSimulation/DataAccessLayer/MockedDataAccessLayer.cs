using Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccessLayer
{
    class MockedDataAccessLayer : IDataAccessLayerRepository
    {
        Map map = null;
        List<Position> positions = null;
        List<Edge> edges = null;
        List<DynamicEdge> dynamicEdges = null;
        List<Agent> agents = null;
        List<Rule> rules = null;

        private static MockedDataAccessLayer dalInstance = null;
        private MockedDataAccessLayer() { }
        public static MockedDataAccessLayer getInstance()
        {
            if (dalInstance == null)
            {
                dalInstance = new MockedDataAccessLayer();
                dalInstance.Init();
            }
            return dalInstance;
        }

        public void Init()
        {
        }

        public void LoadfromFile()
        {
            throw new NotImplementedException();
        }
    }
}
