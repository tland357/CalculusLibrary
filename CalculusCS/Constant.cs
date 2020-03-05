using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculusCS
{
    public class Constant: Function
    {
        public Constant(double coefficient = 1)
        {
            Coefficient = coefficient;
        }
        public override Function Derivative()
        {
            return new Constant(0);
        }
        public override double Evaluate(double x)
        {
            return Coefficient;
        }
        public override Function Clone()
        {
            return new Constant(Coefficient);
        }
        public static implicit operator Constant(double x)
        {
            return new Constant(x);
        }
        public double Value
        {
            get
            {
                return Coefficient;
            }
        }
    }
}
