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
            if (edges != null)
                edges.RemoveAll(i => i.Id == edge.Id);
        }

        public Edge GetEdge(int edgeId)
        {
            if (edges != null)
                foreach (Edge edge in edges)
                {
                    if (edge.Id == edgeId)
                        return edge;
                }
            return null;
        }

        public Edge Update(Edge edge)
        {
            if (edges != null)
                foreach (Edge currentEdge in edges)
                {
                    if (currentEdge.Id == edge.Id)
                    {
                        currentEdge.CurveLength = edge.CurveLength;
                        currentEdge.EndPositionId = edge.EndPositionId;
                        currentEdge.Neighbors = edge.Neighbors;
                        currentEdge.StartPositionId = edge.StartPositionId;
                        return currentEdge;
                    }
                }
            return Create(edge);
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
            return edges;
        }
    }
}
