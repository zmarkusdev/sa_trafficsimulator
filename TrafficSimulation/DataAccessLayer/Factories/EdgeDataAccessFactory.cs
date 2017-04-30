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
        public static AbstractDataAccess<Edge> CreateRepository()
        {
            return new EdgeDataAccess();
        }
    }
}
