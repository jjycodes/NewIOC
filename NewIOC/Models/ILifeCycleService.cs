using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewIOC.Models
{
    public interface ILifeCycleService
    {
        void RegisterComponent(Type typeKey, Component component);

        object ResolveInstance(Type typeKey);
    }
}
