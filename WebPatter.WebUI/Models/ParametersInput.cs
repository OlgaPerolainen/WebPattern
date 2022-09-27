using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebPatter.WebUI.Models
{
    public class ParametersInput
    {
        [Required(ErrorMessage = "Выберите выкройку")]
        public int RadioButtonId { get; set; }
        [Required(ErrorMessage = "Укажите объём талии")]
        public int Waist { get; set; }

        [Required(ErrorMessage = "Укажите длину")]
        public int Length { get; set; }
        [Required(ErrorMessage = "Укажите объём бёдер")]
        public int HipWidth { get; set; }

        [Required(ErrorMessage = "Укажите рост")]
        public int Height { get; set; }

        public bool IsPersistent { get; set; }
    }
}