using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TripUp.WebAPI.Final.Startup))]
namespace TripUp.WebAPI.Final
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
