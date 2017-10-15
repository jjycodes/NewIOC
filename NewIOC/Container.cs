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
            _registry.Add(new Component(typeof(DeclaredType), typeof(ConcreteType), LifeCycleType.Transient));
        }

        public DeclaredType Resolve<DeclaredType>()
        {
            var component = _registry.FirstOrDefault(o => o.DeclaredType == typeof(DeclaredType));
            if (component != null)
                return (DeclaredType) component.Instance;

            throw new Exception($"Type {typeof(DeclaredType)} not found");
        }
    }
}
