using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebPatter.WebUI.Models
{
    public class User
    {
        public virtual int UserId { get; set; }
        // Имя
        public virtual string FirstName { get; set; }
        // Фамилия
        public virtual string LastName { get; set; }
        // Адрес электронной почты
        public virtual string Email { get; set; }
        // Телефон
        public virtual string Phone { get; set; }
        // Пароль
        public virtual string Password { get; set; }
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
    }
}