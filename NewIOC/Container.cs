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
        public void Register<DeclaredType, ConcreteType>()
        {
            throw new NotImplementedException();
        }

        public DeclaredType Resolve<DeclaredType>()
        {
            throw new NotImplementedException();
        }
    }
}
