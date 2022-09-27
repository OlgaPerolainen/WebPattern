using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebPatter.WebUI.Models
{
    public class AdminViewModel
    {
        public List<Pattern> PatternsFree { get; set; }
        public List<Pattern> PatternsNotFree { get; set; }
        public List<Account> Accounts { get; set; }
        public bool IsChecked { get; set; }
        public ChangePattern changePattern { get; set; }
    }
}