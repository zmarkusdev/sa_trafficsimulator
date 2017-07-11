using System;

namespace DataAccessLayer
{
    // Todo: achte auf die Threadsicherheit!!

    /// <summary>
    /// DataAccessCommon, the core administrative things of our database
    /// </summary>
    public class DataAccessCommon
    {
        private int uniqueId = 0;
        private string datafileprefix = "datafile_";
        private string datafileextension = ".txt";

        private static DataAccessCommon instance = null;
        private DataAccessCommon() { }

        /// <summary>
        /// Get instance.
        /// </summary>
        /// <returns>DataAccessCommon</returns>
        public static DataAccessCommon getInstance()
        {
            if (instance == null)
                instance = new DataAccessCommon();
            return instance;
        }

        /// <summary>
        /// Get unique id.
        /// </summary>
        /// <returns>Unique id</returns>
        [Obsolete("getuniqueId is deprecated, please use AbstractDataAccess instead.")]
        public int getuniqueId()
        {
            return uniqueId++;
        }

        /// <summary>
        /// Get prefix of filename.
        /// </summary>
        /// <returns>FilenamePrefix</returns>
        [Obsolete("getuniqueId is deprecated, please use AbstractDataAccess instead.")]
        public string getfilenamePrefix()
        {
            return datafileprefix;
        }

        /// <summary>
        /// Get suffix of filename.
        /// </summary>
        /// <returns>FilenameSuffix</returns>
        [Obsolete("getuniqueId is deprecated, please use AbstractDataAccess instead.")]
        public string getfilenameExtension()
        {
            return datafileextension;
        }
    }
}
