using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebPatter.WebUI.Models;

namespace WebPatter.WebUI.Controllers
{
    public class PatternController : Controller
    {
        private PatternContext db = new PatternContext();
        PatternViewModel model = new PatternViewModel();

        [Authorize(Roles = "admin")]
        public ViewResult List()
        {
            var curretnUser = User.Identity.Name;
            var thisUser = db.Users.FirstOrDefault(x => x.Email == curretnUser);
            model.User = thisUser;
            var allPatterns = db.Patterns.ToList<Pattern>();
            model.Patterns = allPatterns;
            return View(model);
        }
        [Authorize(Roles = "user")]
        public ViewResult UserList()
        {
            var curretnUser = User.Identity.Name;
            var thisUser = db.Users.FirstOrDefault(x => x.Email == curretnUser);
            model.User = thisUser;
            var allPatterns = db.Patterns.ToList<Pattern>();
            model.Patterns = allPatterns;
            return View(model);
        }
        [AllowAnonymous]
        public ViewResult AnonymUserList()
        {
            var allPatterns = db.Patterns.Where(x => x.Availability).ToList<Pattern>();
            model.Patterns = allPatterns;
            return View(model);
        }
        public FileContentResult GetImage(int PatternID)
        {
            Pattern pattern = db.Patterns
                .FirstOrDefault(p => p.PatternID == PatternID);

            if (pattern != null)
            {
                return File(pattern.PatternImage, "png");
            }
            else
            {
                return null;
            }
        }

        public FileContentResult Create(int PatternID, int Waist, int HipWidth, int Length)
        {
            Pattern patternName = db.Patterns
                .FirstOrDefault(p => p.PatternID == PatternID);

            Bitmap bitmap = new Bitmap(10, 10);
            if (patternName != null)
            {

                switch (patternName.PatternID)
                {
                    case 1:
                        bitmap = CreateSkirt.CreateFullSun(Waist, Length);
                        break;
                    case 2:
                        bitmap = CreateSkirt.CreateHalfSun(Waist, Length);
                        break;
                    case 3:
                        bitmap = CreateSkirt.CreatePencil(Waist, Length, HipWidth);
                        break;
                    case 4:
                        bitmap = CreateSkirt.CreateSimple(Waist, HipWidth);
                        break;
                    default:
                        bitmap = CreateSkirt.CreateHalfSun(10, 100);
                        break;
                }

                var bitmapBytes = BitmapToBytes(bitmap); //Convert bitmap into a byte array
                return File(bitmapBytes, "image/jpeg");
            }
            else
            {
                return null;
            }
        }

        public FileResult Download(int PatternID, int Waist, int HipWidth, int Length)
        {
            Bitmap bitmap = new Bitmap(10, 10);
                switch (PatternID)
                {
                    case 1:
                        bitmap = CreateSkirt.CreateFullSun(Waist, Length);
                        break;
                    case 2:
                        bitmap = CreateSkirt.CreateHalfSun(Waist, Length);
                        break;
                    case 3:
                        bitmap = CreateSkirt.CreatePencil(Waist, Length, HipWidth);
                        break;
                    case 4:
                        bitmap = CreateSkirt.CreateSimple(Length, HipWidth);
                        break;
                    default:
                        bitmap = CreateSkirt.CreateHalfSun(10, 100);
                        break;
                }
                byte[] fileBytes = BitmapToBytes(bitmap);
            string fileName = "skirt.jpg";
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

        [Authorize]
        [HttpPost]
        public ActionResult CreatePat(PatternViewModel model)
        {
            if (ModelState.IsValid)
            {
                var curretnUser = User.Identity.Name;
                var thisUser = db.Users.FirstOrDefault(x => x.Email == curretnUser);
                if (thisUser != null)
                {
                    model.User = thisUser;
                }
                Pattern pattern = db.Patterns
                    .FirstOrDefault(p => p.PatternID == model.parametersInput.RadioButtonId);

                model.myPattern = db.UsersPatterns.Find(thisUser.UserId, pattern.PatternID);
                if (model.myPattern == null)
                {
                    var dbUsersPattern = new UsersPattern();

                    dbUsersPattern.PatternId = pattern.PatternID;
                    dbUsersPattern.UserId = thisUser.UserId;
                    dbUsersPattern.Formula = pattern.Formula;
                    dbUsersPattern.Height = thisUser.Height;
                    dbUsersPattern.Waist = model.parametersInput.Waist;
                    dbUsersPattern.Length = model.parametersInput.Length;
                    dbUsersPattern.HipWidth = model.parametersInput.HipWidth;
                    db.UsersPatterns.Add(dbUsersPattern);
                    db.SaveChanges();

                    model.myPattern = db.UsersPatterns.
                        Find(thisUser.UserId, pattern.PatternID);
                }
                else
                {
                    var dbUsersPattern = model.myPattern;
                    dbUsersPattern.Waist = model.parametersInput.Waist;
                    dbUsersPattern.Length = model.parametersInput.Length;
                    dbUsersPattern.HipWidth = model.parametersInput.HipWidth;
                    db.SaveChanges();
                }
                model.PatternID = pattern.PatternID;
                return View(model);
            }
            return RedirectToAction("UserList", "Pattern");
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult CreatePatAnonym(PatternViewModel model)
        {
            if (ModelState.IsValid)
            {
                Pattern pattern = db.Patterns
                    .FirstOrDefault(p => p.PatternID == model.parametersInput.RadioButtonId);
                model.PatternID = pattern.PatternID;
                model.HipWidth = model.parametersInput.HipWidth;
                model.Length = model.parametersInput.Length;
                model.Waist = model.parametersInput.Waist;

                return View(model);
            }
            return RedirectToAction("AnonymUserList", "Pattern");
        }


        // This method is for converting bitmap into a byte array
        private static byte[] BitmapToBytes(Bitmap img)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }

    }
}
