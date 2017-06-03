using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    // decouple IRuleDataAccess Interface from Implementation
    public class CrosswayDataAccessFactory
    {
        static ICrosswayDataAccess instance;

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
