using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculusCS
{
    public class Quotient: Function
    {
        Function Left, Right;
        public Quotient(Function left, Function right)
        {
            Left = left;
            Right = right;
        }
        public override Function Derivative()
        {
            return (Left.Derivative() * Right - Left * Right.Derivative()) / (Right * Right);
        }

        public override double Evaluate(double x)
        {
            return Left.Evaluate(x) / Right.Evaluate(x);
        }
        public override Function Clone()
        {
            return new Quotient(Left.Clone(), Right.Clone());
        }
    }
}
