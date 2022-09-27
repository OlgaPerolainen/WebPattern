using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebPatter.WebUI.Models
{
    public class UsersPattern
    {
        // ID пользователя
        [Key]
        public virtual int UserId { get; set; }
        // ID выкройки
        [Key]
        public virtual int PatternId { get; set; }
        // Формула
        public virtual string Formula { get; set; }
        // Рост
        public virtual int Height { get; set; }
        // Объем талии
        public virtual int Waist { get; set; }
        // Объем бедер
        public virtual int HipWidth { get; set; }
        // Длина изделия
        public virtual int Length { get; set; }
    }
}