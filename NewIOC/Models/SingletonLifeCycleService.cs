using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewIOC.Models
{
    public class SingletonLifeCycleService : ILifeCycleService
    {
        public override object ResolveInstance(Type typeKey)
        {
            if (_registry.ContainsKey(typeKey))
            {
                var component = _registry[typeKey];
                if (component.Instance == null)
                {
                    component.Instance = CreateInstance(component.ConcreteType);
                }

                return component.Instance;
            }

            throw new ImplementationNotFoundException($"Cannot find implementation for {typeKey.FullName}");
        }
    }
}
