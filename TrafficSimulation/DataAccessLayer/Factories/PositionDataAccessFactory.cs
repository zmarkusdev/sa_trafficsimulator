namespace DataAccessLayer
{

    /// <summary>
    /// decouple IPostionDataAccess Interface from Implementation
    /// </summary>
    public abstract class PositionDataAccessFactory
    {
        static IPostionDataAccess instance;

        /// <summary>
        /// Creates new Repository if no one exists.
        /// </summary>
        /// <returns>New repository or already existing instance</returns>
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
