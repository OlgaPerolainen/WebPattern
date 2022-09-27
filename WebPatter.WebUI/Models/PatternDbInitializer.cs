using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebPatter.WebUI.Models
{
    public class PatternDbInitializer : DropCreateDatabaseIfModelChanges<PatternContext>
    {
        protected override void Seed(PatternContext context)
        {
            context.Accounts.Add(new Account
            {
                Name = "Администратор",
                Price = 0
            });
            context.Accounts.Add(new Account
            { Name = "Обычный", Price = 0 });
            context.Accounts.Add(new Account
            {
                Name = "Премиум",
                Price = 2000
            });
            base.Seed(context);

            context.Users.Add(new User
            { 
                FirstName = "John",
                LastName = "Johnson",
                Email = "admin@mail.ru",
                Phone = "89110987654",
                Password = "qwerty_311",
                AccountId = 1,
                Height = 175,
                Waist = 80,
                HipWidth = 95,
                ActivationDate = DateTime.Now,
                RegistrationDate = DateTime.Now
            });
            context.Users.Add(new User
            {
                FirstName = "Марина",
                LastName = "Иванова",
                Email = "marina@mail.ru",
                Phone = "89110987653",
                Password = "Marina_1",
                AccountId = 2,
                Height = 168,
                Waist = 75,
                HipWidth = 96,
                ActivationDate = DateTime.Now,
                RegistrationDate = DateTime.Now
            });
            context.Users.Add(new User
            {
                FirstName = "Диана",
                LastName = "Веткова",
                Email = "dvetkova@mail.ru",
                Phone = "89110987652",
                Password = "Dvetkova_1",
                AccountId = 3,
                Height = 160,
                Waist = 70,
                HipWidth = 90,
                ActivationDate = DateTime.Now,
                RegistrationDate = DateTime.Now
            });
            base.Seed(context);

        }
    }
}