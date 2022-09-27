using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Web;

namespace WebPatter.WebUI.Models
{
    public class PatternViewModel
    {
        public List<Pattern> Patterns { get; set; }
        public ParametersInput parametersInput { get; set; }
        public Pattern thisPattern { get; set; }
        public UsersPattern myPattern { get; set; }
        public Bitmap patternImage { get; set; }
        public User User { get; set; }
        public int PatternID { get; set; }
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
    }
}