using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebPatter.WebUI.Models
{
    public class Pattern
    {
        // ID выкройки
        //[Key]
        public virtual int PatternID { get; set; }
        // Название
        public virtual string Name { get; set; }
        // Формула
        public virtual string Formula { get; set; }
        // Изображение
        public virtual Byte[] PatternImage { get; set; }
        // Доступность
        public virtual bool Availability { get; set; }
        public string Commentary { get; set; }

        public bool IsChecked { get; set; }
    }
}