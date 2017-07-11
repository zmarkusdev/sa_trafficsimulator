using System;
using Datamodel;

namespace DataAccessLayer
{
    /// <summary>
    /// IPostionDataAccess
    /// </summary>
    public interface IPostionDataAccess : IDataAccess<Position> { }

    /// <summary>
    /// Implementation of IPostionDataAccess
    /// </summary>
    public class PositionDataAccess : AbstractDataAccess<Position>, IPostionDataAccess
    {
    }
}
