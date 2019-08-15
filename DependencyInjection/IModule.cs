using Microsoft.Practices.Unity;


namespace DependencyInjection
{
    public interface IModule
    {
        void Register(IUnityContainer container);
    }
}
