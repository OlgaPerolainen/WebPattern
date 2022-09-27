using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebPatter.WebUI.Models
{
    public class AppDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>

    {
        protected override void Seed(ApplicationDbContext context)
        {
            var userManager = new ApplicationUserManager(new
           UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new
           RoleStore<IdentityRole>(context));
            var role1 = new IdentityRole { Name = "admin" };
            var role2 = new IdentityRole { Name = "user" };
            var role3 = new IdentityRole { Name = "premium" };
            roleManager.Create(role1);
            roleManager.Create(role2);
            roleManager.Create(role3);

            var admin = new ApplicationUser
            {
                Email = "admin@mail.ru",
                UserName = "admin@mail.ru",
                FirstName = "John",
                LastName = "Johnson",
                Phone = "89110987654",
                AccountId = 1,
                Height = 175,
                Waist = 80,
                HipWidth = 95,
                ActivationDate = DateTime.Now,
                RegistrationDate = DateTime.Now
            };
            string password = "qwerty_311";
            var result = userManager.Create(admin, password);
            if (result.Succeeded)
            {
                userManager.AddToRole(admin.Id, role1.Name);
                userManager.AddToRole(admin.Id, role2.Name);
                userManager.AddToRole(admin.Id, role3.Name);
            }

            var regular = new ApplicationUser
            {
                Email = "marina@mail.ru",
                UserName = "marina@mail.ru",
                FirstName = "Марина",
                LastName = "Иванова",
                Phone = "89110987653",
                AccountId = 2,
                Height = 168,
                Waist = 75,
                HipWidth = 96,
                ActivationDate = DateTime.Now,
                RegistrationDate = DateTime.Now
            };
            string passwordMar = "Marina_1";
            var resultMar = userManager.Create(regular, passwordMar);
            if (resultMar.Succeeded)
            {
                userManager.AddToRole(regular.Id, role2.Name);
            }

            var premium = new ApplicationUser
            {
                Email = "dvetkova@mail.ru",
                UserName = "dvetkova@mail.ru",
                FirstName = "Диана",
                LastName = "Веткова",
                Phone = "89110987652",
                AccountId = 3,
                Height = 160,
                Waist = 70,
                HipWidth = 90,
                ActivationDate = DateTime.Now,
                RegistrationDate = DateTime.Now
            };
            string passwordNew = "Dvetkova_1";
            var result1 = userManager.Create(premium, passwordNew);
            if (result1.Succeeded)
            {
                userManager.AddToRole(premium.Id, role3.Name);
            }
            base.Seed(context);
        }
    }
}