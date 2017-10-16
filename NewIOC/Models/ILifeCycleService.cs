using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewIOC.Models
{
    public abstract class ILifeCycleService
    {
        protected readonly IDictionary<Type, Component> _registry = new Dictionary<Type, Component>();
        public virtual void RegisterComponent(Type typeKey, Component component)
        {
            if (!_registry.ContainsKey(typeKey))
            {
                _registry.Add(typeKey, component);
            }
            else
            {
                //Override any existing component for now
                _registry[typeKey] = component;
            }
        }

        public virtual object ResolveInstance(Type typeKey)
        {
            if (_registry.ContainsKey(typeKey))
                return CreateInstance(_registry[typeKey].ConcreteType);

            throw new ImplementationNotFoundException($"Cannot find implementation for {typeKey.FullName}");
        }

        protected virtual object CreateInstance(Type concreteType)
        {
            var args = new List<object>();

            var constructor = concreteType.GetConstructors().FirstOrDefault();
            var parameterList = constructor.GetParameters();

            if (!parameterList.Any())
            {
                return Activator.CreateInstance(concreteType);
            }

            //Recursive appraoch to instantiate a nested type that depends on other registered types
            foreach (var parameter in parameterList)
            {
                //if (paramType.IsInterface)
                var resolvedParameterObject = ResolveInstance(parameter.ParameterType);
                args.Add(resolvedParameterObject);
                //else
                //Trust that constructor arguments are interfaces only.
                //Why should they use DI when constructors take concrete types?
                //DI entails following a convention over configuration approach.


                //Catch here for possible circular object graph of dependencies
            }


            var instance = Activator.CreateInstance(concreteType, args.ToArray());
            return instance;
        }
    }
}
