using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface ICalculator
    {
        int Value { get; set; }
        int Add(int x, int y);
        int Subtract(int x, int y);
    }
}
