using Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.MappingModels
{
    /// <summary>
    /// Simulation specific edge object
    /// </summary>
    public class SimEdge : Edge
    {
        /// <summary>
        /// Starting position object of this edge
        /// </summary>
        public SimPosition StartPosition { get; set; }

        /// <summary>
        /// End position object of this edge
        /// </summary>
        public SimPosition EndPosition { get; set; }

        /// <summary>
        /// Neighboring edges for changing to another edge
        /// </summary>
        public List<SimEdge> SimNeighbors { get; set; }
    }
}
