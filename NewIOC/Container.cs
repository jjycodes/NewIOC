using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NewIOC.Models;

namespace NewIOC
{
    public class Container : IContainer
    {
        private readonly ILifeCycleService _lifeCycleService;
        
        public Container()
        {
            _lifeCycleService = new TransientLifecycleService();
        }

        public Container(ILifeCycleService lifeCycleService)
        {
            _lifeCycleService = lifeCycleService;
        }
        
        public void Register<DeclaredType, ConcreteType>() where ConcreteType : DeclaredType
        {
            var component = new Component(typeof(DeclaredType), typeof(ConcreteType));
            _lifeCycleService.RegisterComponent(typeof(DeclaredType), component);
        }

        public DeclaredType Resolve<DeclaredType>()
        {
            return (DeclaredType) Resolve(typeof(DeclaredType));
        }

        private object Resolve(Type typeKey)
        {
            return _lifeCycleService.ResolveInstance(typeKey);
        }
        
    }
}
