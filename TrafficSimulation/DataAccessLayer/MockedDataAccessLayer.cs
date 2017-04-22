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
        List<DynamicEdge> dynamicEdges= null;
        List<Agent> agents = null;
        List<Rule> rules = null;

        public void Init()
        {
            map = new Map();
            positions = new List<Position>();
            edges = new List<Edge>();
            dynamicEdges = new List<DynamicEdge>();
            agents = new List<Agent>();
            rules = new List<Rule>();
        }

        public void LoadfromFile()
        {
            throw new NotImplementedException();
        }
    }
}
