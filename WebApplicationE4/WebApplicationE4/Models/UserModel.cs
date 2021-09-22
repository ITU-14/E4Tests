using System;
using System.Xml.Linq;

namespace WebApplicationE4.Models
{
    public class UserModel
    {
        public string ID { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Cellphone { get; set; }

        public UserModel() { }

        public UserModel(XElement userNode)
        {
            this.ID = userNode.Element("id").Value;

            this.Name = userNode.Element("name").Value;

            this.Surname = userNode.Element("surname").Value;

            this.Cellphone = userNode.Element("cellphone").Value;
        }

        public XElement ToXElement()
        {
            return new XElement("user",
                new XElement("id", string.IsNullOrEmpty(this.ID) ? Guid.NewGuid().ToString() : this.ID),
                new XElement("name", this.Name),
                new XElement("surname", this.Surname),
                new XElement("cellphone", this.Cellphone)
            );
        }
    }
}