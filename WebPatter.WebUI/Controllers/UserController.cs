using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebPatter.WebUI.Models;

namespace WebPatter.WebUI.Controllers
{
    [Authorize(Roles = "user")]
    public class UserController : Controller
    {

        private PatternContext db = new PatternContext();
        UserViewModel model = new UserViewModel();
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public UserController()
        {
        }

        public UserController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET: User
        public ActionResult Index()
        {
            var curretnUser = User.Identity.Name;
            var thisUser = db.Users.FirstOrDefault(x => x.Email == curretnUser);
            model.User = thisUser;
            var allPatterns = db.Patterns.ToList<Pattern>();
            model.PatternsFree = allPatterns;
            return View(model);
        }
        // GET: /User/ChangeContact
        public ActionResult ChangeContact()
        {
            return RedirectToAction("Index", "Home");
        }

        //
        // POST: /User/ChangeContact
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangeContact(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var getDue = db.Users.Where(p => p.UserId == model.User.UserId).FirstOrDefault();
                if (getDue != null) // add this
                {
                    getDue.FirstName = model.User.FirstName;
                    getDue.LastName = model.User.LastName;
                    getDue.Phone = model.User.Phone;
                }

                db.SaveChanges();
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());

                if (user != null)
                {
                    user.FirstName = model.User.FirstName;
                    user.LastName = model.User.LastName;
                    user.Phone = model.User.Phone;
                    var result = await UserManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        TempData["message"] = string.Format("Изменения сохранены");
                        return RedirectToAction("Index", "Home");
                    }
                    AddErrors(result);
                }
            }
            return View(model);
        }

        // GET: /User/UserList
        public ViewResult UserList()
        {
            var curretnUser = User.Identity.Name;
            var thisUser = db.Users.FirstOrDefault(x => x.Email == curretnUser);
            model.User = thisUser;
            var allPatterns = db.Patterns.ToList<Pattern>();
            model.PatternsFree = allPatterns;
            return View(model);
        }
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
        // GET: /User/ChangeParameters
        public ActionResult ChangeParameters()
        {
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangeParameters(UserViewModel model)
        {

            if (ModelState.IsValid)
            {
                var getDue = db.Users.Where(p => p.UserId == model.User.UserId).FirstOrDefault();
                if (getDue != null) // add this
                {
                    getDue.Waist = model.User.Waist;
                    getDue.Height = model.User.Height;
                    getDue.HipWidth = model.User.HipWidth;
                }

                db.SaveChanges();
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());

                if (user != null)
                {
                    user.Waist = model.User.Waist;
                    user.Height = model.User.Height;
                    user.HipWidth = model.User.HipWidth;
                    var result = await UserManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        TempData["message"] = string.Format("Изменения сохранены");
                        return RedirectToAction("Index", "Home");
                    }
                    AddErrors(result);
                }
            }
            return View(model);
        }

        // GET: /User/Delete
        public ActionResult Delete()
        {
            return RedirectToAction("Index", "Home");
        }
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
        //
        // POST: /User/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(UserViewModel model)
        {
            var curretnUser = User.Identity.Name;
            var thisUser = db.Users.FirstOrDefault(x => x.Email == curretnUser);
            if (thisUser != null) // add this
            {
                db.Users.Remove(thisUser);
            }

            db.SaveChanges();
            var user = await UserManager.FindByNameAsync(curretnUser);
            if (user != null)
                {
                //List Logins associated with user
                var logins = user.Logins;

                //Gets list of Roles associated with current user
                var rolesForUser = await UserManager.GetRolesAsync(user.Id);


                    foreach (var login in logins.ToList())
                    {
                        await UserManager.RemoveLoginAsync(login.UserId, new UserLoginInfo(login.LoginProvider, login.ProviderKey));
                    }

                    if (rolesForUser.Count() > 0)
                    {
                        foreach (var item in rolesForUser.ToList())
                        {
                            // item should be the name of the role
                            var result = await UserManager.RemoveFromRoleAsync(user.Id, item);
                        }
                    }

                    //Delete User
                    await UserManager.DeleteAsync(user);

                TempData["Message"] = "Ваш аккаунт удален";
                AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
                return RedirectToAction("Index", "Home"); ;
            }
            return View("Index", "Home");
        }
    }
}