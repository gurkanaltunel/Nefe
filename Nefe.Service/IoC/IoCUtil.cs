using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using Nefe.Service.Interfaces;
using Nefe.Service.Implementations;

namespace Nefe.Service.IoC
{
    public static class IoCUtil
    {
        private static IWindsorContainer _container;

        public static IWindsorContainer Container
        {
            get
            {
                if (_container == null)
                {
                    _container = BootstrapContainer();
                }
                return _container;
            }
        }

        private static IWindsorContainer BootstrapContainer()
        {
            return new WindsorContainer().Register(
                Component.For<IAccountService>().ImplementedBy<AccountService>()
                );
        }

        public static T Resolve<T>()
        {
            return Container.Resolve<T>();
        }
    }
}
