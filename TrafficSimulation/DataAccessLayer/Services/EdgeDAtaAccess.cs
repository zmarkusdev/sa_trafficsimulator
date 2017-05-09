using System;
using Datamodel;
using DataModel.Pipe;

namespace DataAccessLayer
{
    public interface IEdgeDataAccess : IDataAccess<Edge> { }

    class EdgeDataAccess : AbstractDataAccess<Edge>, IEdgeDataAccess
    {
        public override void executeCommand(PipeDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
