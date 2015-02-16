using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdamS.RepositoryInterfaces;
using AdamS.SQLData;
using Autofac;

namespace AdamS.OnlineStore.DependencyResolverWeb
{


    public class BusinessRegistry : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterType<DebugMessageService>().As<IMessageService>().InstancePerRequest();
        }
    }

    
    public class RepositoryRegistry : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CustomerRepository>().As<ICustomerRepository>().SingleInstance();
        }
    }
}
