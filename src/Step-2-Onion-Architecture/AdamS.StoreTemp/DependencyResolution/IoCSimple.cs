

using System.Web.Mvc;
using AdamS.OnlineStore.DependencyResolverWeb;
using Autofac;
using Autofac.Integration.Mvc;

namespace AdamS.StoreTemp.DependencyResolution {
    public class IoCConfig
    {
        public static void RegisterDependencies()
        {
            //Create the builder
            var builder = new ContainerBuilder();
            
            //Setup common patterns
            builder.RegisterAssemblyTypes()
                   .Where(t => t.Name.EndsWith("Repository"))
                   .AsImplementedInterfaces()
                   .InstancePerHttpRequest();
            builder.RegisterAssemblyTypes()
                   .Where(t => t.Name.EndsWith("Service"))
                   .AsImplementedInterfaces()
                   .InstancePerHttpRequest();
            

            //Register all controllers for the assembly
            builder.RegisterControllers(typeof(MvcApplication).Assembly).InstancePerHttpRequest();


            //Register modules
            builder.RegisterAssemblyModules(typeof(MvcApplication).Assembly);
            builder.RegisterAssemblyModules(typeof(BusinessRegistry).Assembly);
            

            //Inject HTTP Abstractions
            builder.RegisterModule<AutofacWebTypesModule>();
            

            //Set the MVC dependency resolver to use Autofac
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

    }    

}