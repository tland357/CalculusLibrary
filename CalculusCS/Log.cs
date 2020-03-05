using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculusCS
{
    public class Log: Function
    {
        public readonly double Base;
        public static readonly Log LN = new Log();
        public override Function Clone()
        {
            return new Log(Base);
        }
        public Log(double b = Math.E)
        {
            Base = b;
        }
        public override double Evaluate(double x)
        {
            return Math.Log10(x) / Math.Log10(Base);
        }

        public override Function Derivative()
        {
            return new PolynomialTerm(Coefficient / Math.Log(Base), -1);
        }
    }
}
