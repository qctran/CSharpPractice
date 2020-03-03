using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SerializeDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = Helper.CreateData();
            BinarySerializationDemo(data);
            XmlSerializationDemo(data);
        }

        private static void XmlSerializationDemo(List<Customer> data)
        {
            XmlSerialization(data);
            //var output = XmlDeserialization();
        }

        //private static object XmlDeserialization()
        //{
        //    XmlSerializer serializer = new XmlSerializer(typeof(Customer));
        //    using (TextReader reader = new StreamReader(".\\serializeXml.xml"))
        //    {

        //    }
        //}

        private static void XmlSerialization(List<Customer> data)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Customer));
            using (TextWriter writer = new StreamWriter(".\\serializeXml.xml"))
            {
                foreach (var customer in data)
                {
                    serializer.Serialize(writer, customer);
                }
            }
        }

        private static void BinarySerializationDemo(List<Customer> data)
        {
            Serialize(data);
            var deserializeData = Deserialized();
        }

        private const string FILENAME = ".\\serializedemo.txt";
        private static object Deserialized()
        {
            IFormatter formatter = new BinaryFormatter();
            using (Stream sr = new FileStream(FILENAME, FileMode.Open, FileAccess.Read))
            {
                var data = formatter.Deserialize(sr);
                return data;
            }
        }

        private static void Serialize(List<Customer> data)
        {
            IFormatter formatter = new BinaryFormatter();
            using (Stream sw = new FileStream(FILENAME, FileMode.Append, FileAccess.Write))
            {
                formatter.Serialize(sw, data);
            }
        }
    }
}
