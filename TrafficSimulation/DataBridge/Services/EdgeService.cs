using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datamodel;
using DataBridge.Communication;

namespace DataBridge.Services
{
    /// <summary>
    /// Implementation of the IEdgeRepository.
    /// </summary>
    class EdgeService : IEdgeRepository
    {
        public Edge Create(Edge edge)
        {
            return DataAccessClient.Instance.Channel.CreateEdge(edge);
        }

        public void Delete(Edge edge)
        {
            DataAccessClient.Instance.Channel.DeleteEdge(edge);
        }

        public IEnumerable<Edge> GetAll()
        {
            return DataAccessClient.Instance.Channel.GetAllEdges();
        }

        public Edge GetEdge(int edgeId)
        {
            return DataAccessClient.Instance.Channel.GetEdge(edgeId);
        }

        public Edge Update(Edge edge)
        {
            return DataAccessClient.Instance.Channel.UpdateEdge(edge);
        }
    }
}
