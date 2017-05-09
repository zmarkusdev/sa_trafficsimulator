namespace DataAccessLayer
{
    // decouple IPostionDataAccess Interface from Implementation
    public abstract class PositionDataAccessFactory
    {
        public static IPostionDataAccess CreateRepository()
        {
            return new PositionDataAccess();
        }
    }
}
