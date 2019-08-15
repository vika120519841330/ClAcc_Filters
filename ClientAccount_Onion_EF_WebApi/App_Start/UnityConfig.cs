using DependencyInjection;
using DependencyInjection.Modules;
using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;

namespace ClientAccount_Onion_EF_WebApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // –егистрируем модули в рамках контейнера container

            Registre<DomainModule>(container);
            Registre<InfrastructureModule>(container);


            // ”станавливаем dependency-resolver дл€ нашего приложени€, который будет использоватьс€ дл€
            // резолвинга зависимостей использу€ container

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }

        // »нициализируем экземпл€р модул€ и вызываем метод Register, передава€ целевой container 
        // дл€ регистрации зависимостей
        private static void Registre<T>(IUnityContainer container) where T : IModule, new()
        {
            new T().Register(container);
        }
    }
}