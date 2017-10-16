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
        private ILifeCycleService _lifeCycleService;
        private readonly IDictionary<Type, Component> _registry = new Dictionary<Type, Component>();

        public Container()
        {
            _lifeCycleService = new TransientLifecycleService();
        }

        public Container(ILifeCycleService lifeCycleService)
        {
            _lifeCycleService = lifeCycleService;
        }

        public void Register<DeclaredType, ConcreteType>()
        {
            Register<DeclaredType, ConcreteType>(LifeCycleType.Transient);
        }

        public void Register<DeclaredType, ConcreteType>(LifeCycleType lifeCycleType)
        {
            var component = new Component(typeof(DeclaredType), typeof(ConcreteType), lifeCycleType);
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
