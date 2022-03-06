using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Assignment1Serializer
{
    [XmlRoot]
    [XmlType]
    public class Patient :Person
    {

        public DateTimeOffset DateOfBirth { get; set; }

        [XmlElement("DOB")]
        [JsonProperty]
        public string DateOfbirthXml
        {
            get
            {
                return DateOfBirth.ToString("");
            }
            set
            {
                DateOfBirth = DateTimeOffset.Parse(value);
            }
        }

        public string Gender { get; set; }


    }
}
