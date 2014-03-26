using System.Collections.Generic;

using System.Reflection;
using SimpleInjector;
using Topshelf.Builders;
using Topshelf.Configurators;
using Topshelf.HostConfigurators;

namespace Topshelf.SimpleInjector
{
    /// <summary>
    /// Class SimpleInjectorBuilderConfigurator.
    /// </summary>
    public class SimpleInjectorBuilderConfigurator : HostBuilderConfigurator
    {
        /// <summary>
        /// The container
        /// </summary>
        private static Container _container;
        /// <summary>
        /// The assemblies containaing IPackage 
        /// </summary>
        private static IEnumerable<Assembly> _packageAssemblies;

        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleInjectorBuilderConfigurator"/> class.
        /// </summary>
        public SimpleInjectorBuilderConfigurator()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleInjectorBuilderConfigurator"/> class.
        /// </summary>
        /// <param name="packageAssemblies">The package assemblies.</param>
        public SimpleInjectorBuilderConfigurator(IEnumerable<Assembly> packageAssemblies)
        {
            _packageAssemblies = packageAssemblies;
        }

        /// <summary>
        /// Gets the service provider.
        /// </summary>
        /// <value>The service provider.</value>
        public static Container ServiceProvider
        {
            get
            {
                if (_container != null) return _container;

                _container = new Container();

                if (_packageAssemblies != null)
                    _container.RegisterPackages(_packageAssemblies);
                else
                    _container.RegisterPackages();

                _container.Verify();

                return _container;
            }
        }

        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns>IEnumerable&lt;ValidateResult&gt;.</returns>
        public IEnumerable<ValidateResult> Validate()
        {

            yield break;
        }

        /// <summary>
        /// Configures the specified builder.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns>HostBuilder.</returns>
        public HostBuilder Configure(HostBuilder builder)
        {
            return builder;
        }
    }
}
