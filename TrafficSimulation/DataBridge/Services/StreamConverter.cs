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

        /// <summary>
        /// Get instance of StreamConverter
        /// </summary>
        /// <returns>StreamConverter</returns>
        public static StreamConverter getInstance()
        {
            if (instance == null)
            {
                instance = new StreamConverter();
            }
            return instance;
        }

        /// <summary>
        /// Converts given object to string.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns>Serialized object</returns>
        public string convertToJson<T>(T obj)
        {
            throw new NotImplementedException();
            //return javaScriptSerializer.Serialize(obj);
        }

        /// <summary>
        /// Converts given List to string
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns>Serialized list</returns>
        public string convertListToJson<T>(IEnumerable<T> list)
        {
            throw new NotImplementedException();
            //return javaScriptSerializer.Serialize(list);
        }

        /// <summary>
        /// Converts Json to given object.
        /// </summary>
        /// <typeparam name="T">Object to cast</typeparam>
        /// <param name="str"></param>
        /// <returns>Deserialized object</returns>
        public T convertFromJson<T>(String str)
        {
            throw new NotImplementedException();
            //return javaScriptSerializer.Deserialize<T>(str);
        }
    }
}
