using System;

namespace WpfClient
{
    [Serializable()]
    public class UserData
    {
        [System.Xml.Serialization.XmlElement("Address")]
        public string Address { get; set; } = "127.0.0.1";
        [System.Xml.Serialization.XmlElement("Port")]
        public int Port { get; set; } = 32100;
        [System.Xml.Serialization.XmlElement("Name")]
        public string Name { get; set; } = "Name";
    }
}
