using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Assignment1Serializer
{
    [XmlRoot]
    [XmlType]
    public class Address
    {
        public string AddressLine { get; set; }

        public string City { get; set; }

        public int Country { get; set; }

        public Guid EntityId { get; set; }

        public string PostalCode { get; set; }

        public string Province { get; set; }

    }
}
