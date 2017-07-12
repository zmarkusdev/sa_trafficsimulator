using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datamodel
{
    /// <summary>
    /// A dynamic edge will be generated, if an agent wants to overtake another agent on the street.
    /// They need to be flexible in the positions, because they will be outside of the default edges.
    /// </summary>
    public class DynamicEdge : AbstractEdge
    {
        /// <summary>
        /// x-coordinate of the start position.
        /// </summary>
        public int StartX { get; set; }

        /// <summary>
        /// y-coordinate of the start position
        /// </summary>
        public int StartY { get; set; }

        /// <summary>
        /// x-coordinate of the end position
        /// </summary>
        public int EndX { get; set; }

        /// <summary>
        /// y-coordinate of the end position
        /// </summary>
        public int EndY { get; set; }

        /// <summary>
        /// Id of the starting edge
        /// </summary>
        public int SourceEdgeId { get; set; }

        /// <summary>
        /// Id of the destination edge, the agent wants to drive to
        /// </summary>
        public int DestinationEdgeId { get; set; }

        /// <summary>
        /// Run length, where the agent plans to land after the overtake
        /// </summary>
        public int DestinationRunLength { get; set; }
    }
}
