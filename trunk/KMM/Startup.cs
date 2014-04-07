using System.Reflection;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using KMM.Data.Infrastructure;
using KMM.Data.Repository;
using KMM.Data.Service;
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
            SetAutofacContainer();
        }

        private static void SetAutofacContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerHttpRequest();
            builder.RegisterType<DatabaseFactory>().As<IDatabaseFactory>().InstancePerHttpRequest();
            builder.RegisterAssemblyTypes(typeof(IMaterialRequestRepository).Assembly)
                .Where(a => a.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerHttpRequest();
            builder.RegisterAssemblyTypes(typeof(IMaterialRequestService).Assembly)
                .Where(a => a.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerHttpRequest();

            builder.RegisterFilterProvider();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }
    }
}
