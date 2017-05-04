using Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class EdgeDataAccessFactory
    {
        public static IEdgeDataAccess CreateRepository()
        {
            return new EdgeDataAccess();
        }
    }
}
