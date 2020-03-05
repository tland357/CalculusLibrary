using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculusCS
{
    public class Sine: Function
    {
        public static readonly Sine Sin = new Sine();
        public override double Evaluate(double x)
        {
            return Coefficient * Math.Sin(x);
        }
        Sine() { }
        public override Function Clone()
        {
            return new Sine() { Coefficient = this.Coefficient };
        }

        public override Function Derivative()
        {
            return Cosine.Cos;
        }
    }
}
