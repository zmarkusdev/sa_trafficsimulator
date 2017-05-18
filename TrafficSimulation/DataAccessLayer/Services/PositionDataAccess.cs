using System;
using Datamodel;

namespace DataAccessLayer
{
    public interface IPostionDataAccess : IDataAccess<Position> { }

    public class PositionDataAccess : AbstractDataAccess<Position>, IPostionDataAccess
    {
    }
}
