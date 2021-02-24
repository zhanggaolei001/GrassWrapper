using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace GrassWrapper.Trans
{ 
    public class Message
    {
        [XmlElement("source")]
        public string Source { get; set; }
        [XmlElement("translation")]

        public string Translation { get; set; }
    } 
    public class Context
    {
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("message")]
        public List<Message> Message { get; set; }
    }
    [XmlRoot("TS")]
    public class TS
    {
        [XmlAttribute("language")]
        public string Language { get; set; } 
        [XmlAttribute("version")]
        public string Version { get; set; }
        [XmlElement("context")]
        public List<Context> Context { get; set; }
    } 
}
