using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebPatter.WebUI.Models;

namespace WebPatter.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private PatternContext db = new PatternContext();

        public ActionResult Index()
        {
            var curretnUser = User.Identity.Name;
            if (curretnUser != null)
            {
                var thisUser = db.Users.FirstOrDefault(x => x.Email == curretnUser);
                if (thisUser != null)
                {
                    ViewBag.UserName = thisUser.FirstName;
                }
            }
            return View();
        }
    }
}