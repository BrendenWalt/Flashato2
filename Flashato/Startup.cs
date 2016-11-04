using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Flashato.Startup))]
namespace Flashato
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
