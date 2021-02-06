using Autofac;
using Business;
using DataAccess;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace IocContainer
{
    public class IocModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BlBook>().As<IBlBook>().InstancePerLifetimeScope();

            builder.RegisterType<EfBook>().As<IEfBook>();

            builder.RegisterType<SampleContext>().AsSelf().WithParameter("options", DbContextOptionsFactory.Get());
        }


        public class DbContextOptionsFactory
        {
            public static DbContextOptions<SampleContext> Get()
            {
                var builder = new DbContextOptionsBuilder<SampleContext>();
                builder.UseNpgsql(Constants.Settings.SqlConnectionString);

                return builder.Options;
            }
        }


    }
}