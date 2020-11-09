using System.Reflection;
using Autofac;
using Module = Autofac.Module;

namespace API_Tutorial
{
    public class AutoFacConfig : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.Load("API_Application")).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(Assembly.Load("API_Infrastructure")).AsImplementedInterfaces();
        }
    }
}