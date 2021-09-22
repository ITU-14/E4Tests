using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using WebApplicationE4.Models;
using WebApplicationE4.Services;

namespace WebApplicationE4.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var xmlPath = Server.MapPath(UserService.UserDataPath);

            var users = UserService.GetUsers(xmlPath);

            return View(UserService.UserListView, users);
        }

        [HttpPost]
        public ActionResult InsertOrUpdate(UserModel model)
        {
            var xmlPath = Server.MapPath(UserService.UserDataPath);

            UserService.InsertOrUpdateUser(xmlPath, model);

            return this.RedirectPermanent("/");
        }

        [HttpPost]
        public ActionResult RemoveUser(string id)
        {
            var xmlPath = Server.MapPath(UserService.UserDataPath);

            UserService.DeleteUser(xmlPath, id);

            return this.RedirectPermanent("/");
        }
    }
}