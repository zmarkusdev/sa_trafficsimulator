using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBridge.Datamodel
{
    public class Edge : AbstractEdge
    {
        public int StartPositionId { get; set; }

        public int EndPositionId { get; set; }

        public IEnumerable<Edge> Neighbors { get; set; } 

    }
}
