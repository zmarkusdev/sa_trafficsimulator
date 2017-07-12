using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleDeactivatorLibrary
{

    /// <summary>
    /// Helper class for Event arguments
    /// </summary>
    public class MessageEventArgs : EventArgs
    {
        /// <summary>
        /// Message
        /// </summary>
        public Message Message { get; }

        /// <summary>
        /// Message save function
        /// </summary>
        /// <param name="message"></param>
        public MessageEventArgs(Message message)
        {
            this.Message = message;
        }
    }
}
