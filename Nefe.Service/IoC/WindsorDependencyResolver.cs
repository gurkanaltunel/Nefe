using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using Nefe.Service.Interfaces;
using Nefe.Service.Implementations;
using System.Web.Http.Dependencies;
using Castle.MicroKernel;

namespace Nefe.Service.IoC
{
    public sealed class WindsorDependencyResolver : System.Web.Http.Dependencies.IDependencyResolver
    {
        private IWindsorContainer _container;

        public WindsorDependencyResolver(IWindsorContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException();
            }
            _container = container;
        }

        public IDependencyScope BeginScope()
        {
            return new WindsorDependencyScope(_container);
        }

        public object GetService(Type serviceType)
        {
            return _container.Kernel.HasComponent(serviceType) ? _container.Resolve(serviceType) : null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _container.ResolveAll(serviceType).Cast<object>().ToArray();
        }

        public void Dispose()
        {
            _container.Dispose();
        }
    }
}
