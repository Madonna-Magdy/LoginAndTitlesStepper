using System.Reflection;
using Autofac;
using Module = Autofac.Module;

namespace LoginAndStepper.DependencyInjection
{
    public class DependencyInjection : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().PropertiesAutowired().InstancePerDependency();
        }

    }
}
