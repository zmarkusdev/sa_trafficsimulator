using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleDeactivatorLibrary
{
    public class Message
    {
        // ID of the agent
        public int AgentId { get; set; }

        public String toJSON()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static Message fromJSON(String json)
        {
            return JsonConvert.DeserializeObject<Message>(json);
        }

        override
        public String ToString()
        {
            return "Message: " + this.toJSON();
        }
    }
}
