using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebPatter.WebUI.Models;

namespace WebPatter.WebUI.Views
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private PatternContext db = new PatternContext();
        AdminViewModel model = new AdminViewModel();
        // GET: Admin
        public ActionResult Index()
        {
            var freePatterns = db.Patterns.Where(x => x.Availability).ToList<Pattern>();
            var notFreePatterns = db.Patterns.Where(x => !x.Availability).ToList<Pattern>();
            model.PatternsFree = freePatterns;
            model.PatternsNotFree = notFreePatterns;
            model.Accounts = db.Accounts.ToList<Account>();
            return View(model);
        }

        [HttpPost]
        public ActionResult ChangePattern(AdminViewModel model)
        {

            foreach (var cr in model.PatternsFree)
            {
                if (cr.IsChecked)
                {
                    var checkedPattern = db.Patterns.FirstOrDefault(p => p.PatternID == cr.PatternID);
                    if(checkedPattern != null)
                    {
                        checkedPattern.Availability = false;
                    }
                }
            }
            foreach (var cr in model.PatternsNotFree)
            {
                if (cr.IsChecked)
                {
                    var checkedPattern = db.Patterns.FirstOrDefault(p => p.PatternID == cr.PatternID);
                    if (checkedPattern != null)
                    {
                        checkedPattern.Availability = true;
                    }
                }
            }
            db.SaveChanges();
            TempData["message"] = string.Format("Изменения сохранены");
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public ActionResult ChangeAccounts(AdminViewModel model)
        {
            foreach (var AccId in model.Accounts)
            {
                var getDue = db.Accounts.Where(p => p.AccountId == AccId.AccountId).FirstOrDefault();
                if (getDue != null) // add this
                {
                    getDue.Price = AccId.Price;
                }

            }
            db.SaveChanges();
            TempData["message"] = string.Format("Изменения сохранены");
            return RedirectToAction("Index", "Home");
        }
    }
}