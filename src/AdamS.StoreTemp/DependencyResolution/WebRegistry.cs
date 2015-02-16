using AdamS.StoreTemp.Models;
using Autofac;

namespace AdamS.StoreTemp.DependencyResolution 
{
    public class WebRegistry : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CookieManager>().As<IStateProvider>().InstancePerRequest();
        }
    }
}