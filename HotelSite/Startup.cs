using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HotelSite.Startup))]
namespace HotelSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
