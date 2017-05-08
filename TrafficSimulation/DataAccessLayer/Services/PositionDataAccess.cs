using System;
using Datamodel;
using DataModel.Pipe;

namespace DataAccessLayer
{
    public interface IPostionDataAccess : IDataAccess<Position> { }

    public class PositionDataAccess : AbstractDataAccess<Position>, IPostionDataAccess
    {
        public override void executeCommand(PipeDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
