using Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.MappingModels
{
    /// <summary>
    /// Simulation specific rule object
    /// </summary>
    public class SimRule : Rule
    {
        /// <summary>
        /// Positions to check if the rule for rule fulfillment (e.g. positions to check for a stop sign)
        /// </summary>
        public List<SimPosition> CheckPositions { get; set; } 

        /// <summary>
        /// Position the rule is assigned to
        /// </summary>
        public SimPosition Position { get; set; } 
    }
}
