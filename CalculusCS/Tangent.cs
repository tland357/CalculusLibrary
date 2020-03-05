using System;

namespace CalculusCS
{
    public class Tangent : Function
    {
        public static readonly Tangent Tan = new Tangent();
        public override double Evaluate(double x)
        {
            return Coefficient * Math.Tan(x);
        }
        Tangent()
        { }
        public override Function Clone()
        {
            return new Tangent() { Coefficient = this.Coefficient };
        }

        public override Function Derivative()
        {
            return new PolynomialTerm(1, 2).Compose(Secant.Sec);
        }
    }
}
