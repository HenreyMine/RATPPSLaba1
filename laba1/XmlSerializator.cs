using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace laba1
{
    public class XmlSerializator : ISerialize
    {
        public T Deserialize<T>(string serializedString)
        {
            var xmlSerializer = new XmlSerializer(typeof(T));
            var stringReader = new StringReader(serializedString);
            return (T)xmlSerializer.Deserialize(stringReader);
        }

        public string Serialize<T>(T serializeObject)
        {
            var xmlSerializerNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            var xmlSerializer = new XmlSerializer(typeof(T));
            var xmlWriteSettings = new XmlWriterSettings();
            var stringWriter = new StringWriter();
            xmlWriteSettings.OmitXmlDeclaration = true;
            var xmlWriter = XmlWriter.Create(stringWriter, xmlWriteSettings);
            xmlSerializer.Serialize(xmlWriter, serializeObject, xmlSerializerNamespaces);
            return stringWriter.ToString();
        }
    }
}
