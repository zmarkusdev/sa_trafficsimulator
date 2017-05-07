using System;
using System.Web.Script.Serialization;

namespace DataAccessLayer.Controller
{
    public class JsonStreamConverter
    {
        private static JsonStreamConverter instance;
        private JavaScriptSerializer javaScriptSerializer;

        private JsonStreamConverter()
        {
            this.javaScriptSerializer = new JavaScriptSerializer();
        }

        public static JsonStreamConverter getInstance()
        {
            if (instance == null)
            {
                instance = new JsonStreamConverter();
            }
            return instance;
        }

        public string convertToJson<T>(T obj)
        {
            return javaScriptSerializer.Serialize(obj);
        }

        public T convertFromJson<T>(string str)
        {
            return javaScriptSerializer.Deserialize<T>(str.Replace("\0", String.Empty));
        }
    }
}
