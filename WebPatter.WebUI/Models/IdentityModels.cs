using System;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebPatter.WebUI.Models
{
    // В профиль пользователя можно добавить дополнительные данные, если указать больше свойств для класса ApplicationUser. Подробности см. на странице https://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        // Имя
        public virtual string FirstName { get; set; }
        // Фамилия
        public virtual string LastName { get; set; }
        // Телефон
        public virtual string Phone { get; set; }
        // Рост
        public virtual int Height { get; set; }
        // Объем талии
        public virtual int Waist { get; set; }
        // Объем бедер
        public virtual int HipWidth { get; set; }
        // Тип аккаунта
        public virtual int AccountId { get; set; }
        // Дата регистрации
        public virtual DateTime RegistrationDate { get; set; }
        // Дата активации аккаунта
        public virtual DateTime ActivationDate { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {

            // Обратите внимание, что authenticationType должен совпадать с типом, определенным в CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            //userIdentity.AddClaim(new Claim("FirstName", FirstName));
            //userIdentity.AddClaim(new Claim("LastName", LastName));
            userIdentity.AddClaim(new Claim("Phone", Phone));
            // Здесь добавьте утверждения пользователя
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}