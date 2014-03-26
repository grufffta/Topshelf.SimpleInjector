using Topshelf.Logging;
using Topshelf.ServiceConfigurators;

namespace Topshelf.SimpleInjector
{
    public static class ServiceConfiguratorExtensions
    {
        /// <summary>
        /// Constructs the service type using simple injector for dependency resolution.
        /// </summary>
        /// <typeparam name="T">Topshelf Service type</typeparam>
        /// <param name="configurator">The configurator.</param>
        /// <returns>ServiceConfigurator&lt;T&gt;.</returns>
        public static ServiceConfigurator<T> ConstructUsingSimpleInjector<T>(this ServiceConfigurator<T> configurator) where T : class
        {
            HostLogger.Get(typeof(ServiceConfiguratorExtensions)).Info("[Topshelf.SimpleInjector] Service configured to construct using SimpleInjector.");
            configurator.ConstructUsing(serviceFactory => SimpleInjectorBuilderConfigurator.ServiceProvider.GetInstance<T>());
            return configurator;
        }
    }
}
