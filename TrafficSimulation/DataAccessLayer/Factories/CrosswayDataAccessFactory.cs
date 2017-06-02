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
        public static ICrosswayDataAccess CreateRepository()
        {
            return new CrosswayDataAccess();
        }
    }
}
