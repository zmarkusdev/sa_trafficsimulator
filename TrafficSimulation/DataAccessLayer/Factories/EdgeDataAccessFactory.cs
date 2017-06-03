namespace DataAccessLayer
{
    // decouple IEdgeDataAccess Interface from Implementation
    public class EdgeDataAccessFactory
    {
        static IEdgeDataAccess instance;

        public static IEdgeDataAccess CreateRepository()
        {
            if (instance == null)
                instance = new EdgeDataAccess();
            return instance;
        }
    }
}
