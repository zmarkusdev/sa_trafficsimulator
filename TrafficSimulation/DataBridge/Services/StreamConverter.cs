using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Web.Script.Serialization;

namespace DataAccessLayer.Controller
{
    /// <summary>
    /// Converter to serialize to JSON-Objects.
    /// </summary>
    public class StreamConverter
    {
        private static StreamConverter instance;
        //private JavaScriptSerializer javaScriptSerializer;

        private StreamConverter()
        {
            //this.javaScriptSerializer = new JavaScriptSerializer();
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
            throw new NotImplementedException();
            //return javaScriptSerializer.Serialize(obj);
        }

        public string convertListToJson<T>(IEnumerable<T> list)
        {
            throw new NotImplementedException();
            //return javaScriptSerializer.Serialize(list);
        }

        public T convertFromJson<T>(String str)
        {
            throw new NotImplementedException();
            //return javaScriptSerializer.Deserialize<T>(str);
        }
    }
}
