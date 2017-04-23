using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Datamodel;

namespace Repositories
{
    public interface IEdgeRepository
    {
        Datamodel.Edge Create(Edge edge);
        void Delete(Edge edge);
        Edge GetEdge(int edgeId);
        Edge Update(Edge edge);

        IEnumerable<Edge> GetAll();
    }
}
