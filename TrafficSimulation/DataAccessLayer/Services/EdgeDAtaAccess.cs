using DataAccessLayer;
using Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IEdgeDataAccess : IDataAccess<Edge> { }

    class EdgeDataAccess : AbstractDataAccess<Edge>, IEdgeDataAccess
    {
    }
}
