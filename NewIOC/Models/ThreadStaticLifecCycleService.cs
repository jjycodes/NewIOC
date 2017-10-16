using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewIOC.Models
{
    public class ThreadStaticLifecCycleService : ILifeCycleService
    {
        public void RegisterComponent(Type typeKey, Component component)
        {
            throw new NotImplementedException();
        }

        public object ResolveInstance(Type typeKey)
        {
            throw new NotImplementedException();
        }
    }
}
