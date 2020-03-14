using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ehealth.Startup))]
namespace Ehealth
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
