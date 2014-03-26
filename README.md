Topshelf.SimpleInjector
=======================

Adds SimpleInjector support to TopShelf

Example usage

```CSharp
using Topshelf;

namespace CommunicationsService
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(c =>
            {
                c.UseSimpleInjector();
                c.SetDisplayName("My Display Name");
                c.SetDescription("My Description");
                c.SetServiceName("My.ServiceName");
                c.Service<HostServiceWithNoDependencyOnTopshelf>(s =>
                {
                    s.ConstructUsingSimpleInjector();
                    s.WhenStarted((service, control) => service.Start());
                    s.WhenStopped((service, control) => service.Stop());
                });
            });
        }
    }
    
    public class DefaultServicePackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            /// register with container  
        }
    }
}
```
