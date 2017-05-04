using Datamodel;

namespace DataAccessLayer
{
    public abstract class PositionDataAccessFactory
    {
        public static IPostionDataAccess CreateRepository()
        {
            return new PositionDataAccess();
        }
    }
}
