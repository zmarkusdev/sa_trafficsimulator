using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datamodel
{
    /// <summary>
    /// Default edge used for general map layout in the graph, connects the positions.
    /// </summary>
    public class Edge : AbstractEdge
    {
        /// <summary>
        /// Id of the position the edge starts at
        /// </summary>
        public int StartPositionId { get; set; }

        /// <summary>
        /// Id of the position the edge ends at
        /// </summary>
        public int EndPositionId { get; set; }

        /// <summary>
        /// List of neighbour edges of the current edge
        /// </summary>
        public IEnumerable<Edge> Neighbors { get; set; } 

    }
}
