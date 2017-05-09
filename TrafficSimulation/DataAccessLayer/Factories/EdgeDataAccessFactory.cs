namespace DataAccessLayer
{
    // decouple IEdgeDataAccess Interface from Implementation
    public class EdgeDataAccessFactory
    {
        public static IEdgeDataAccess CreateRepository()
        {
            return new EdgeDataAccess();
        }
    }
}
