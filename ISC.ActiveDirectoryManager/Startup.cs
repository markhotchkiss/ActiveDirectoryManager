using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ISC.ActiveDirectoryManager.Startup))]
namespace ISC.ActiveDirectoryManager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
