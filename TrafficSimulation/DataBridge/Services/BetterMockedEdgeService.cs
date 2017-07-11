using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datamodel;
using DataAccessLayer;

namespace DataBridge
{
    /// <summary>
    /// Implementation of the IEdgeRepository.
    /// </summary>
    class BetterMockedEdgeService : IEdgeRepository
    {
        IEdgeDataAccess edgeDataAccess = EdgeDataAccessFactory.CreateRepository();

        public BetterMockedEdgeService()
        {
            edgeDataAccess.LoadfromFile("edge");
        }

        public Edge Create(Edge edge)
        {
            return edgeDataAccess.Create(edge);
        }

        public void Delete(Edge edge)
        {
            edgeDataAccess.Delete(edge);
        }

        public IEnumerable<Edge> GetAll()
        {
            return edgeDataAccess.ReadAll();
        }

        public Edge GetEdge(int edgeId)
        {
            return edgeDataAccess.ReadbyId(edgeId);
        }

        public Edge Update(Edge edge)
        {
            edgeDataAccess.Update(edge);
            return edge;
        }
    }
}
