using Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.MappingModels
{
    /// <summary>
    /// Simulation specific position class
    /// </summary>
    public class SimPosition : Position
    {
        /// <summary>
        /// Predecessor edges connected before this position
        /// </summary>
        public List<SimEdge> PredecessorEdges { get; set; }

        /// <summary>
        /// Successor edges connected after this position
        /// </summary>
        public List<SimEdge> SuccessorEdges { get; set; }

        /// <summary>
        /// Rules connected to this position
        /// </summary>
        public List<SimRule> Rules { get; set; }
    }
}
