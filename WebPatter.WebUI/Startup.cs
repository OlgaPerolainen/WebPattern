using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebPatter.WebUI.Startup))]
namespace WebPatter.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
