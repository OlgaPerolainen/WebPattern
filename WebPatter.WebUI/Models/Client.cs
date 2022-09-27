using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebPatter.WebUI.Models
{
    public class Client
    {
        // ID клиента
        public virtual int ClientId { get; set; }
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
        // ID пользователя
        public virtual int UserId { get; set; }
    }
}