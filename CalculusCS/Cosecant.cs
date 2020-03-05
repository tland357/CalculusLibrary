using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculusCS
{
    public class Cosecant : Function
    {
        public static readonly Cosecant Csc = new Cosecant();
        public override double Evaluate(double x)
        {
            return Coefficient / Math.Sin(x);
        }

        Cosecant()
        { }
        public override Function Clone()
        {
            return new Cosecant() { Coefficient = this.Coefficient };
        }

        public override Function Derivative()
        {
            return -Cosecant.Csc * Cotangent.Cot;
        }
    }
}
