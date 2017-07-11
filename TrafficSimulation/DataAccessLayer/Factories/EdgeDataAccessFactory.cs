namespace DataAccessLayer
{
    /// <summary>
    /// decouple IEdgeDataAccess Interface from Implementation
    /// </summary>
    public class EdgeDataAccessFactory
    {
        static IEdgeDataAccess instance;

        /// <summary>
        /// Creates new Repository if no one exists.
        /// </summary>
        /// <returns>New repository or already existing instance</returns>
        public static IEdgeDataAccess CreateRepository()
        {
            if (instance == null)
            {
                instance = new EdgeDataAccess();
                instance.LoadfromFile("edge");
            }
            return instance;
        }
    }
}
