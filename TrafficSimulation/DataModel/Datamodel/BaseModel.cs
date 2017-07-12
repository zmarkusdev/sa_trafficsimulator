using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datamodel
{
    /// <summary>
    /// The base model for every model, that needs an id
    /// </summary>
    public abstract class BaseModel
    {
        /// <summary>
        /// Unique identifier for the current model object
        /// </summary>
        public int Id { get; set; }
    }
}
