using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Services
{
    // Todo: achte auf die Threadsicherheit!!
    class DataAccessCommon
    {
        private int uniqueId = 0;
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
    }
}
