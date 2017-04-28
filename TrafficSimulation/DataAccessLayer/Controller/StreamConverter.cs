using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace DataAccessLayer.Controller
{
    class StreamConverter
    {

        public static string convertToJson(Object obj)
        {
            return new JavaScriptSerializer().Serialize(obj);
        }

        public static Object convertFromJson(String str)
        {
            return new JavaScriptSerializer().Deserialize(str);
        }
    }
}
