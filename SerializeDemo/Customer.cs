using System;
using System.Xml.Serialization;

namespace SerializeDemo
{
    [Serializable]
    [XmlRoot("root")]
    public class Customer
    {
        [XmlElement("lastname")]
        public string Lastname { get; set; }
        [XmlElement("firstname")]
        public string Firstname { get; set; }
        [XmlElement("age")]
        public int Age { get; set; }
        [XmlElement("credit")]
        public double Credit { get; set; }
    }
}
