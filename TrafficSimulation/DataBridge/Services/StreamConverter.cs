using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace DataAccessLayer.Controller
{
    public class StreamConverter
    {
        private static StreamConverter instance;
        private JavaScriptSerializer javaScriptSerializer;

        private StreamConverter()
        {
            this.javaScriptSerializer = new JavaScriptSerializer();
        }

        public static StreamConverter getInstance()
        {
            if (instance == null)
            {
                instance = new StreamConverter();
            }
            return instance;
        }

        public string convertToJson<T>(T obj)
        {
            return javaScriptSerializer.Serialize(obj);
        }

        public string convertListToJson<T>(IEnumerable<T> list)
        {
            return javaScriptSerializer.Serialize(list);
        }

        public T convertFromJson<T>(String str)
        {
            return javaScriptSerializer.Deserialize<T>(str);
        }
    }
}
