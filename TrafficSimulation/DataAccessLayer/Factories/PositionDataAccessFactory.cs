namespace DataAccessLayer
{
    // decouple IPostionDataAccess Interface from Implementation
    public abstract class PositionDataAccessFactory
    {
        static IPostionDataAccess instance;

        public static IPostionDataAccess CreateRepository()
        {
            if (instance == null)
            {
                instance = new PositionDataAccess();
                instance.LoadfromFile("position");
            }
            return instance;
        }
    }
}
