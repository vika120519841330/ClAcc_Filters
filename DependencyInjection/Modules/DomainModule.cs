using Microsoft.Practices.Unity;
using Domain.Interfaces;
using DomainServices.Services;

namespace DependencyInjection.Modules
{
    public class DomainModule : IModule
    {
        public void Register(IUnityContainer container)
        {
            container.RegisterType<ILogService, LogService>(new HierarchicalLifetimeManager());
            container.RegisterType<IAccount, AccountService>(new HierarchicalLifetimeManager());
            container.RegisterType<IClient, ClientService>(new HierarchicalLifetimeManager());
            //для работы с фейк-репозиторием - раскомментировать
            container.RegisterType<IDomainInitializationService, DomainInitializationService>(new HierarchicalLifetimeManager());
        }
    }
}
