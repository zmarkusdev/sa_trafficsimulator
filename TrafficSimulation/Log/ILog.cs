using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log
{
    /// <summary>
    /// Interface for the logging of the simulation components
    /// </summary>
    public interface ILog
    {
        /// <summary>
        /// Logs a new debug message
        /// </summary>
        /// <param name="message">Message that should be output</param>
        void Debug(string message);
    }
}
