

using System.Web.Mvc;

using AdamS.StoreTemp.Models;
using Autofac;
using Autofac.Integration.Mvc;

namespace AdamS.StoreTemp.DependencyResolution {
    public class IoCConfig
    {
        public static void RegisterDependencies()
        {
            //Create the builder
            var builder = new ContainerBuilder();
            
            //Register all controllers for the assembly
            builder.RegisterControllers(typeof(MvcApplication).Assembly).InstancePerHttpRequest();
            
            //Register types
            builder.RegisterType<EmailSender>().As<INotificationProvider>().InstancePerRequest();
            builder.RegisterType<FileSystemLogger>().As<ILogger>().InstancePerRequest();
            builder.RegisterType<CustomerRepository>().As<ICustomerRepository>().SingleInstance();
            builder.RegisterType<OrderRepository>().As<IOrdersRepository>().SingleInstance();
            
            //Set the MVC dependency resolver to use Autofac
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

    }    

}