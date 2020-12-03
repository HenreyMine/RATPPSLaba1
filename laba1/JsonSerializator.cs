using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.Script.Serialization;

namespace laba1
{
    public class JsonSerializator : ISerialize
    {
        private JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();

        public T Deserialize<T>(string serializedString)
        {
            return javaScriptSerializer.Deserialize<T>(serializedString);
        }

        public string Serialize<T>(T serializeObject)
        {
            return javaScriptSerializer.Serialize(serializeObject);
        }
    }
}
