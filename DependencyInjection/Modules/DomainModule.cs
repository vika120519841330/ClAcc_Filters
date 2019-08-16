using Microsoft.Practices.Unity;
using Domain.Interfaces;
using DomainServices.Services;

namespace DependencyInjection.Modules
{
    public class DomainModule : IModule
    {
        public void Register(IUnityContainer container)
        {
            //для работы с логированием запросов в БД
            container.RegisterType<ILogService, LogService>(new HierarchicalLifetimeManager());

            //для работы с логированием исключений в БД
            container.RegisterType<IExcLogService, ExcLogService>(new HierarchicalLifetimeManager());

            container.RegisterType<IAccount, AccountService>(new HierarchicalLifetimeManager());
            container.RegisterType<IClient, ClientService>(new HierarchicalLifetimeManager());

            //для работы с фейк-репозиторием
            container.RegisterType<IDomainInitializationService, DomainInitializationService>(new HierarchicalLifetimeManager());
        }
    }
}
