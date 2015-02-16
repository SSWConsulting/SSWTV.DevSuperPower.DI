using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AdamS.StoreTemp.Startup))]
namespace AdamS.StoreTemp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
