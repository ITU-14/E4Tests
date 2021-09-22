using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using WebApplicationE4.Models;

namespace WebApplicationE4.Services
{
    public class UserService
    {
        public static readonly string UserListView = "~/Views/Home/Index.cshtml";

        public static readonly string UserDataPath = "~/App_Data/user-data.xml";

        public static IList<UserModel> GetUsers(string xmlPath)
        {
            var document = XDocument.Load(xmlPath);

            var users = (from xmlNode in document.Descendants("user")
                       select xmlNode).Select(userNode => new UserModel(userNode)).ToList();
            
            return users;
        }

        public static void InsertOrUpdateUser(string xmlPath, UserModel model)
        {
            var document = XDocument.Load(xmlPath);

            if(!string.IsNullOrEmpty(model.ID))
            {
                var element = GetElementById(ref document, model.ID);

                element.Remove();
            }

            document.Element("users").Add(model.ToXElement());


            document.Save(xmlPath);
        }

        public static XElement GetElementById(ref XDocument document, string userId)
        {
            var user = (from xmlNode in document.Descendants("user")
                        where xmlNode.Element("id").Value == userId
                        select xmlNode).FirstOrDefault();

            return user;
        }

        public static void DeleteUser(string xmlPath, string userId)
        {
            var document = XDocument.Load(xmlPath);

            var user = GetElementById(ref document, userId);

            user.Remove();

            document.Save(xmlPath);
        }
    }
}