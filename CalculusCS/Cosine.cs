using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculusCS
{
    public class Cosine : Function
    {
        public static readonly Cosine Cos = new Cosine();
        public override double Evaluate(double x)
        {
            return Coefficient * Math.Cos(x);
        }
        Cosine() { }
        public override Function Clone()
        {
            return new Cosine() { Coefficient = this.Coefficient };
        }

        public override Function Derivative()
        {
            return -Sine.Sin;
        }
    }
}
