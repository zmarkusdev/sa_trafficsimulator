using DataAccessLayer;
using Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    // edges do not need much more than the baseclass offers
    class EdgeDataAccess : AbstractDataAccess<Edge>
    {
        DataAccessCommon dataAccessCommon = DataAccessCommon.getInstance();

        public override Edge Create(Edge edge)
        {
            if (edge.Id == 0)
                edge.Id = dataAccessCommon.getuniqueId();
            edge = base.Create(edge);

            return (edge);
        }
    }
}
