using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MakeAccount.Startup))]
namespace MakeAccount
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
