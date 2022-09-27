using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;

namespace WebPatter.WebUI.Models
{
    public static class ExtentionMethods
    {
        public static string GetUserPhone(this IIdentity identity)
        {
            var customClaim = ((ClaimsIdentity)identity).FindFirst("Phone");
            return (customClaim != null) ? customClaim.Value : string.Empty;
        }
    }
}