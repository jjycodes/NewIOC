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
        private readonly IDictionary<Type, Component> _registry = new Dictionary<Type, Component>();
        public void Register<DeclaredType, ConcreteType>()
        {
            Register<DeclaredType, ConcreteType>(LifeCycleType.Transient);
        }

        public void Register<DeclaredType, ConcreteType>(LifeCycleType lifeCycleType)
        {
            var component = new Component(typeof(DeclaredType), typeof(ConcreteType), lifeCycleType);

            if (!_registry.ContainsKey(typeof(DeclaredType)))
            {
                _registry.Add(typeof(DeclaredType), component);
            }
            else
            {
                //Override any existing component for now
                _registry[typeof(DeclaredType)] = component;
            }
        }

        public DeclaredType Resolve<DeclaredType>()
        {
            return (DeclaredType) Resolve(typeof(DeclaredType));
        }

        private object Resolve(Type typeKey)
        {
            if (_registry.ContainsKey(typeKey))
                return GetRegisteredComponentInstance(_registry[typeKey]);

            throw new ImplementationNotFoundException($"Cannot find implementation for {typeKey.FullName}");
        }

        private object GetRegisteredComponentInstance(Component component)
        {
            if (component.LifeCycle == LifeCycleType.Singleton)
            {
                if (component.Instance == null)
                    component.Instance = CreateInstance(component.ConcreteType);

                return component.Instance;
            }

            //Always return new instance for Transient types
            return CreateInstance(component.ConcreteType);
        }

        private object CreateInstance(Type concreteType)
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
                var resolvedParameterObject = Resolve(parameter.ParameterType);
                args.Add(resolvedParameterObject);
                //else
                //Trust that constructor arguments are interfaces only.
                //Why should they use DI when constructors take concrete types?
                //DI entails following a convention over configuration approach.


                //Catch here for possible circular object graph of dependencies
            }


            var instance = Activator.CreateInstance(concreteType, args.ToArray());
            Console.WriteLine($"Type : {instance.GetType()}");
            return instance;
        }
    }
}
