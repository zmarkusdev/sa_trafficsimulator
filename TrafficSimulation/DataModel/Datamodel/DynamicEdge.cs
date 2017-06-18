using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datamodel
{
    public class DynamicEdge : AbstractEdge
    {
        public int StartX { get; set; }

        public int StartY { get; set; }

        public int EndX { get; set; }

        public int EndY { get; set; }

        public int SourceEdgeId { get; set; }

        public int DestinationEdgeId { get; set; }

        public int DestinationRunLength { get; set; }
    }
}
