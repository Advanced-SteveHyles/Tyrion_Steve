using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace IOC
{
    public class IOCModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(this.GetType().Assembly)
                 .AsImplementedInterfaces()
                 .AsSelf()
                 .As(q => q.BaseType);

            builder.RegisterType<Cleaner>().As<ICleaner>().SingleInstance();
            builder.RegisterType<Reporter>().As<IReporter>().SingleInstance();
            builder.RegisterType<Terminator>().As<ITerminator>().SingleInstance();
        }
    }

    public class IocBuilder
    {
        public IocBuilder(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(this.GetType().Assembly)
                 .AsImplementedInterfaces()
                 .AsSelf()
                 .As(q => q.BaseType);

            builder.RegisterType<Cleaner>().As<ICleaner>().SingleInstance();
            builder.RegisterType<Reporter>().As<IReporter>().SingleInstance();
            builder.RegisterType<Terminator>().As<ITerminator>().SingleInstance();
            builder.RegisterType<LoadParameters>().As<IParameters>().SingleInstance();
            builder.RegisterType<Starter>().As<IStarter>().SingleInstance();
        }
    }
}
