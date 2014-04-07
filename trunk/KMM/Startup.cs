using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KMM.Startup))]
namespace KMM
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
