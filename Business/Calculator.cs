using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Interfaces;

namespace Business
{
    public class Calculator : ICalculator
    {
        public Calculator()
        {
            Value = 0;
        }
        public int Value { get; set; }

        public int Add(int x, int y)
        {
            return x + y;
        }

        public int Subtract(int x, int y)
        {
            return x - y;
        }
    }
}
