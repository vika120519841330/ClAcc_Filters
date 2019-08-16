using Microsoft.Practices.Unity;
using Infrastructure.Interfaces;
using InfrastructureServices.Repositories;
using InfrastructureServices.Contexts;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using InfrastructureServices.Services;

namespace DependencyInjection.Modules
{
    public class InfrastructureModule : IModule
    {
        public void Register(IUnityContainer container)
        {
            // подключение БД
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();

            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["MyContext"].ConnectionString);

            using (var context = new MyContext(optionsBuilder.Options))
            {
                context.Database.EnsureCreated();
            }

            container.RegisterType<MyContext>(
                //new HierarchicalLifetimeManager(),        
                //если раскомментировать, то будет singletone
                new InjectionConstructor(optionsBuilder.Options));

            // если работать с контекстом напрямую без фейк-репозитория - раскомментировать
            //container.RegisterType<IClientRepository, ClientRepository>(new ContainerControlledLifetimeManager());
            //container.RegisterType<IAccountRepository, AccountRepository>(new ContainerControlledLifetimeManager());

            //для логирования запросов в БД
            container.RegisterType<ILogRepository, LogRepository>(new ContainerControlledLifetimeManager());
            //для логирования исключений в БД
            container.RegisterType<IExcLogRepository, ExcLogRepository>(new ContainerControlledLifetimeManager());

            // для работы с  фейк-репозиторием - раскомментировать, если нужно
            container.RegisterType<IMyContextInitializationService, MyContextInitializationService>(new HierarchicalLifetimeManager());
            container.RegisterType<IClientProvider, FakeRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IAccountProvider, FakeRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IClientRepository, FakeRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IAccountRepository, FakeRepository>(new HierarchicalLifetimeManager());

        }
    }
}
