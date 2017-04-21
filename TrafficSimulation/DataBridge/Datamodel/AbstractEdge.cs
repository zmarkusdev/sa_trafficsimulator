using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBridge.Datamodel
{
    public abstract class AbstractEdge
    {
        public int Id { get; set; }

        public int CurveLength { get; set; }
    }
}
