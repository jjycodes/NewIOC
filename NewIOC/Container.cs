using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NewIOC
{
    public class Container : IContainer
    {
        private readonly IList<Component> _registry = new List<Component>();
        public void Register<DeclaredType, ConcreteType>()
        {
            Register<DeclaredType, ConcreteType>(LifeCycleType.Transient);
        }

        public void Register<DeclaredType, ConcreteType>(LifeCycleType lifeCycleType)
        {
            _registry.Add(new Component(typeof(DeclaredType), typeof(ConcreteType), lifeCycleType));
        }

        public DeclaredType Resolve<DeclaredType>()
        {
            var component = _registry.FirstOrDefault(o => o.DeclaredType == typeof(DeclaredType));
            if (component != null)
            {
                if (component.Instance != null)
                {
                    return (DeclaredType) component.Instance;
                }

                component.Instance = CreateInstance(component.ConcreteType);
                return (DeclaredType) component.Instance;
            }

            throw new Exception($"Type {typeof(DeclaredType)} not found");
        }

        private object CreateInstance(Type concreteType)
        {
            return Activator.CreateInstance(concreteType);
        }
    }
}
