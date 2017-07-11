using System;
using Datamodel;

namespace DataAccessLayer
{
    /// <summary>
    /// IEdgeDataAccess
    /// </summary>
    public interface IEdgeDataAccess : IDataAccess<Edge> { }

    class EdgeDataAccess : AbstractDataAccess<Edge>, IEdgeDataAccess
    {
    }
}
