using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebPatter.WebUI.Models;

namespace WebPatter.WebUI.Controllers
{
    [Authorize(Roles = "premium")]
    public class PremiumController : Controller
    {
        private PatternContext db = new PatternContext();
        PatternViewModel model = new PatternViewModel();
        // GET: User
        public ActionResult Index()
        {
            var allPatterns = db.Patterns.ToList<Pattern>();
            model.Patterns = allPatterns;
            return View(model);
        }
    }
}