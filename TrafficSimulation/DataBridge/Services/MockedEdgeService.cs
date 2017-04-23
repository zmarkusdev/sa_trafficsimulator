using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Datamodel;

namespace Repositories
{
    class MockedEdgeService : IEdgeRepository
    {
        List<Edge> edges = new List<Edge>();
        int freeEdgeId = 1;

        public Edge Create(Edge edge)
        {
            edge.Id = getuniqueEdgeId();
            edges.Add(edge);
            return (edge);
        }

        public void Delete(Edge edge)
        {
            return;
        }

        public Edge GetEdge(int edgeId)
        {
            Edge edge = new Edge();
            edge.Id = edgeId;
            edges.Add(edge);
            return (edge);
        }

        public Edge Update(Edge edge)
        {
            return (edge);
        }

        //************************* meine **********************************
        private int getuniqueEdgeId()
        {
            return (freeEdgeId++);
        }
        private Edge createDummyedge()
        {
            Edge edge = new Edge();
            edge.Id = getuniqueEdgeId();
            edge.StartPositionId = 0;
            edge.EndPositionId = 0;
            edge.CurveLength = 22;
            edge.Neighbors = new List<Edge>();

            return edge;
        }

        public IEnumerable<Edge> GetAll()
        {
#warning @walter and max, this method is needed for simulation initialization, thanks :-)
            throw new NotImplementedException();
        }
    }
}
