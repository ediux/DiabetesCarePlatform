using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DiabetesCarePlatform.Startup))]
namespace DiabetesCarePlatform
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            ConfigureDI(app);
            ConfigureSignalR(app);
        }
    }
}
