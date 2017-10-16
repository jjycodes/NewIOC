using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewIOC.Models
{
    public class ThreadStaticLifecCycleService : ILifeCycleService
    {
        [ThreadStatic]
        protected static readonly IDictionary<Thread, Component> _registry = new Dictionary<Thread, Component>();

        public override void RegisterComponent(Type typeKey, Component component)
        {
            //initial implementation for thread static custom lifecycle
            if (!_registry.ContainsKey(Thread.CurrentThread))
            {
                _registry.Add(Thread.CurrentThread, component);
            }
        }

        public override object ResolveInstance(Type typeKey)
        {
            return base.ResolveInstance(typeKey);
        }
    }
}