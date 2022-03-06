using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Assignment1Serializer
{
    [XmlRoot]
    [XmlType]
    public class Entity
    {
        /// <summary>
        /// 
        /// </summary>
        public List<Address> Addresses { get; set; }


        public Guid Id { get; set; }


        public List<Identifier> Identifiers {get;set;}

    }
}
