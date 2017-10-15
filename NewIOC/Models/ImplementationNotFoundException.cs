using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewIOC.Models
{
    public class ImplementationNotFoundException : Exception
    {
        public ImplementationNotFoundException(string message)
            : base(message)
        {
        }
    }
}
