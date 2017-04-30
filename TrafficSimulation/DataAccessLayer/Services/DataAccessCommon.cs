using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    // Todo: achte auf die Threadsicherheit!!
    // the core administrative things of our database
    public class DataAccessCommon
    {
        private int uniqueId = 0;
        private string datafileprefix = "datafile_";
        private string datafileextension = ".txt";

        private static DataAccessCommon instance = null;
        private DataAccessCommon() { }

        public static DataAccessCommon getInstance()
        {
            if (instance == null)
                instance = new DataAccessCommon();
            return instance;
        }

        public int getuniqueId()
        {
            return uniqueId++;
        }

        public string getfilenamePrefix()
        {
            return datafileprefix;
        }

        public string getfilenameExtension()
        {
            return datafileextension;
        }
    }
}
