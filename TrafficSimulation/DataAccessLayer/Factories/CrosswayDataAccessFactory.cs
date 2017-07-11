using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    /// <summary>
    /// decouple ICrosswayDataAccess Interface from Implementation
    /// </summary>
    public class CrosswayDataAccessFactory
    {
        static ICrosswayDataAccess instance;

        /// <summary>
        /// Creates new Repository if no one exists.
        /// </summary>
        /// <returns>New repository or already existing instance</returns>
        public static ICrosswayDataAccess CreateRepository()
        {
            if (instance == null)
            {
                instance = new CrosswayDataAccess();
                instance.LoadfromFile("crossway");
            }
            return instance;
        }
    }
}
