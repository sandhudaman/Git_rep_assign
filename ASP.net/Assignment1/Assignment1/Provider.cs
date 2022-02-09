using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Assignment1Serializer
{
    public class Provider:Person
    {
        public string Specialty { get; set; }
    }
}
