using System;
using System.Xml.Linq;

namespace E4StudentAPI.Models
{
    public class StudentModel
    {
        public string ID { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Gender { get; set; }

        public string Class { get; set; }

        public StudentModel() { }

        public StudentModel(XElement userNode)
        {
            this.ID = userNode.Element("id").Value;

            this.Name = userNode.Element("name").Value;

            this.Surname = userNode.Element("surname").Value;

            this.Gender = userNode.Element("gender").Value;

            this.Class = userNode.Element("class").Value;
        }

        public XElement ToXElement()
        {
            this.ID = string.IsNullOrEmpty(this.ID) ? Guid.NewGuid().ToString() : this.ID;
            return new XElement("student",
                new XElement("id", this.ID),
                new XElement("name", this.Name),
                new XElement("surname", this.Surname),
                new XElement("gender", this.Gender),
                new XElement("class", this.Class)
            );
        }
    }
}