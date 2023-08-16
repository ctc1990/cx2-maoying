using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace CLEANXCEL2._2.Controllers.Security
{
    class Format_Conversion
    {
        private static readonly string node = "Root";

        public static string Object2XML(object data)
        {
            return JSON2XML(Object2JSON(data));
        }

        public static T XML2Object<T>(string data)
        {
            return JSON2Object<T>(XML2JSON(data));
        }

        private static string Object2JSON(object data)
        {
            return JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented);
        }

        private static T JSON2Object<T>(string json)
        {
            JObject jobject = JObject.Parse(json);
            return JsonConvert.DeserializeObject<T>(jobject[node].ToString());
        }

        private static string JSON2XML(string json)
        {
            return JsonConvert.DeserializeXNode(json, node).ToString();
        }

        private static string XML2JSON(string xml)
        {
            XmlDocument xmlDocument = new XmlDocument();

            xmlDocument.LoadXml(xml);

            return JsonConvert.SerializeXmlNode(xmlDocument);
        }

        public static bool OBJECT2XML<T>(object data, string filepath)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

            using (var writer = XmlWriter.Create(filepath))
            {
                xmlSerializer.Serialize(writer, data);
                return true;
            }
        }

        public static T XML2OBJECT<T>(string xml, string filepath)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var reader = XmlReader.Create(filepath))
            {
                return (T)serializer.Deserialize(reader);
            }
        }
    }
}
