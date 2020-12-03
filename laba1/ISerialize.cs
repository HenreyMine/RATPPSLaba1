using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba1
{
    interface ISerialize
    {
        string Serialize<T>(T serializeObject);
        T Deserialize<T>(string serializedString);
    }
}
