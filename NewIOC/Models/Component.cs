using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewIOC
{
    /// <summary>
    /// Represents a class that mimics the way OOP creates objects from types
    /// ex. ICalculator x = new Calculator();
    /// ICalculator is the DeclaredType
    /// while Calculator is the the instantiated ConcreteType.
    /// and x will be the object Instance 
    /// Object Creation happens when we invoke the ConcreteType constructor.
    /// </summary>
    public class Component
    {
        
        public Type DeclaredType { get; }

        public Type ConcreteType { get; }

        public object Instance { get; set; }

        public LifeCycleType LifeCycle { get; set; }

        public Component(Type declaredType, Type concreteType)
        {
            //LifeCycleType lifeCycle
            DeclaredType = declaredType;
            ConcreteType = concreteType;
            //LifeCycle = lifeCycle;
        }
    }

    public enum LifeCycleType
    {
        Transient,
        Singleton
    }
}
