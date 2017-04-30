using Datamodel;

namespace DataAccessLayer
{
    public abstract class PositionDataAccessFactory
    {
        public static AbstractDataAccess<Position> CreateRepository()
        {
            return new PositionDataAccess();
        }
    }
}
