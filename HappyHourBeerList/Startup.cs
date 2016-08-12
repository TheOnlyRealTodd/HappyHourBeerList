using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HappyHourBeerList.Startup))]
namespace HappyHourBeerList
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
