using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Assignment1Serializer
{
    [XmlRoot]
    [XmlType]
    public class Identifier
    {   
        public string Authority { get; set; }   

        public Guid EntityId { get; set; }

        public string Value { get; set; }


    }
}
