using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebPatter.WebUI.Models
{
    public class UserViewModel
    {
        public List<Pattern> PatternsFree { get; set; }
        public ParametersInput parametersInput { get; set; }
        public User User { get; set; }
    }
}