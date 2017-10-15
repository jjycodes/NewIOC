using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewIOC
{
    public interface IContainer
    {
        void Register<DeclaredType, ConcreteType>();
        void Register<DeclaredType, ConcreteType>(LifeCycleType lifeCycleType);
        DeclaredType Resolve<DeclaredType>();
    }
}
