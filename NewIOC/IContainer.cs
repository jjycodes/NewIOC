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
        DeclaredType Resolve<DeclaredType>();
    }
}
