using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculusCS
{
    public class Negation: Function
    {
        Function Function;
        public Negation(Function function)
        {
            Function = function;
        }
        public override Function Derivative()
        {
            return (-Function).Derivative();
        }

        public override Function Clone()
        {
            return new Negation(Function);
        }

        public override double Evaluate(double x)
        {
            return -Function.Evaluate(x);
        }
    }
}
