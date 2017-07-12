using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datamodel
{
    /// <summary>
    /// Abstract edge base class for dynamic and static edge that contain informations
    /// about the graph edges of the map.
    /// </summary>
    public abstract class AbstractEdge : BaseModel
    {
        /// <summary>
        /// Length of the edge in meters
        /// </summary>
        public int CurveLength { get; set; }
    }
}
