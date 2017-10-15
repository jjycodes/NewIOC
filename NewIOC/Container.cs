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
                return (DeclaredType) GetRegisteredComponentInstance(component);
            }

            throw new Exception($"Type {typeof(DeclaredType).FullName} not found");
        }

        private object Resolve(Type typeKey)
        {
            var component = _registry.FirstOrDefault(o => o.DeclaredType == typeKey);

            if (component != null)
            {
                return GetRegisteredComponentInstance(component);
            }

            throw new Exception($"Type {typeKey.FullName} not found");
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

            if (constructor == null || !parameterList.Any())
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
