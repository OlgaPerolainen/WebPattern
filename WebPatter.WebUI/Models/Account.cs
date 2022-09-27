using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebPatter.WebUI.Models
{
    public class Account
    {
        [HiddenInput(DisplayValue = false)]
        // ID аккаунта
        public virtual int AccountId { get; set; }

        // Название
        [Display(Name = "Название")]
        public virtual string Name { get; set; }

        // Стоимость
        [Display(Name = "Цена (руб)")]
        public virtual int Price { get; set; }
    }
}