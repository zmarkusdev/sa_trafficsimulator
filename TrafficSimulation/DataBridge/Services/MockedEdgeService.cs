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

        public MockedEdgeService()
        {
            createSmallVillage();
        }

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
        private void createSmallVillage()
        {
            Edge edge1 = new Edge();
            Edge edge2 = new Edge();
            Edge edge3 = new Edge();
            Edge edge4 = new Edge();
            Edge edge5 = new Edge();

            edge1.Id = 1;
            edge1.StartPositionId = 1;
            edge1.EndPositionId = 2;
            edge1.CurveLength = 160;
            edge1 = Create(edge1);

            edge2.Id = 2;
            edge2.StartPositionId = 2;
            edge2.EndPositionId = 3;
            edge2.CurveLength = (int)Math.Round(Math.Sqrt(8) * 10);
            edge2 = Create(edge2);

            edge3.Id = 3;
            edge3.StartPositionId = 3;
            edge3.EndPositionId = 4;
            edge3.CurveLength = 300;
            edge3 = Create(edge3);
            
            edge4.Id = 4;
            edge4.StartPositionId = 2;
            edge4.EndPositionId = 5;
            edge4.CurveLength = (int)Math.Round(Math.Sqrt(8) * 10);
            edge4 = Create(edge4);
            
            edge5.Id = 5;
            edge5.StartPositionId = 5;
            edge5.EndPositionId = 6;
            edge5.CurveLength = 100;
            edge5 = Create(edge5); 
        }


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
