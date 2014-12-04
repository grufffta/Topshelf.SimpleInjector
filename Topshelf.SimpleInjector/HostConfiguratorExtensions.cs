using System.Reflection;
using SimpleInjector.Packaging;
using Topshelf.HostConfigurators;
using Topshelf.Logging;

namespace Topshelf.SimpleInjector
{
    public static class HostConfiguratorExtensions
    {
        /// <summary>
        /// Instructs TopShelf to use simple injector for dependency resolution.
        /// </summary>
        /// <param name="configurator">The configurator.</param>
        /// <param name="packageAssemblies">The package assemblies containng types implementing <see cref="IPackage"/>.</param>
        /// <returns>HostConfigurator.</returns>
        public static HostConfigurator UseSimpleInjector(this HostConfigurator configurator, params Assembly[] packageAssemblies)
        {
            var logWriter = HostLogger.Get(typeof(HostConfiguratorExtensions));
            logWriter.Info("[Topshelf.SimpleInjector] Integration started in host.");
            logWriter.Debug(packageAssemblies.Length == 0
                ? "[Topshelf.SimpleInjector] scanning all loaded assemblies for packages."
                : string.Format("[Topshelf.SimpleInjector] instantiating with {0} package assemblies.", packageAssemblies.Length));
            configurator.AddConfigurator(new SimpleInjectorBuilderConfigurator(packageAssemblies));
            return configurator;
        }
    }
}
