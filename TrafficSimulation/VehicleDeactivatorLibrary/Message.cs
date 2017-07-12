using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleDeactivatorLibrary
{

    /// <summary>
    /// Class that creates converts the message into a json for sending it
    /// </summary>
    public class Message
    {
        /// <summary>
        /// ID of the agent
        /// </summary>
        public int AgentId { get; set; }

        /// <summary>
        /// Convert the message into a json
        /// </summary>
        /// <returns>a json converted string</returns>
        public String toJSON()
        {
            return JsonConvert.SerializeObject(this);
        }

        /// <summary>
        /// Convert a json into a string
        /// </summary>
        /// <param name="json">json to convert into a string</param>
        /// <returns>Message in String format</returns>
        public static Message fromJSON(String json)
        {
            return JsonConvert.DeserializeObject<Message>(json);
        }

        /// <summary>
        /// return the message 
        /// </summary>
        /// <returns>message in json format</returns>
        override public String ToString()
        {
            return "Message: " + this.toJSON();
        }
    }
}
