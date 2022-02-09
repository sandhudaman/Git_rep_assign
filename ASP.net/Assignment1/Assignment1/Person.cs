using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;


namespace Assignment1Serializer
{

    [XmlRoot]
    [XmlType]
    public class Person :Entity
    {
        /// <summary>
        /// Gets and set or Person class
        /// With FirstName,LastName and we can ignore Middle name since its not used
        /// </summary>
        
        
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [XmlIgnore]
        [JsonIgnore]
        public string MiddleName { get; set; }

        
        /*public DateTimeOffset DateOfBirth { get; set; }

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
        }*/

    }
}
