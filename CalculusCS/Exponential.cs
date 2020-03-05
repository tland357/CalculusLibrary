using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculusCS
{
    public class Exponential: Function
    {
        public readonly double Base;
        public Exponential(double exBase, double coefficient)
        {
            Coefficient = coefficient;
            Base = exBase;
        }
        public override Function Derivative()
        {
            if (Base == 0 || Base == 1 || Coefficient == 0) return new Constant(0);
            return new Exponential(Base, Math.Log(Base) * Coefficient);
        }
        public override double Evaluate(double x)
        {
            return Math.Pow(Base, x) * Coefficient;
        }

        public override Function Clone()
        {
            return new Exponential(Base, Coefficient);
        }
    }
}
