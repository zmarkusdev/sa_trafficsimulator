using Datamodel;

namespace DataAccessLayer
{
    public interface IEdgeDataAccess : IDataAccess<Edge> { }

    class EdgeDataAccess : AbstractDataAccess<Edge>, IEdgeDataAccess
    {
    }
}
