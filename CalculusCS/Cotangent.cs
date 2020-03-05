using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculusCS
{
    public class Cotangent : Function
    {
        public static readonly Cotangent Cot = new Cotangent();
        public override double Evaluate(double x)
        {
            return Coefficient / Math.Tan(x);
        }
        Cotangent()
        { }
        public override Function Clone()
        {
            return new Cotangent() { Coefficient = this.Coefficient };
        }

        public override Function Derivative()
        {
            return -new PolynomialTerm(1, 2).Compose(Cosecant.Csc);
        }
    }
}
