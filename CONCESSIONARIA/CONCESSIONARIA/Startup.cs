using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CONCESSIONARIA.Startup))]
namespace CONCESSIONARIA
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
