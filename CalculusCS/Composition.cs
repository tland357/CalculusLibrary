using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculusCS
{
    public class Composition : Function, ISanitizable
    {
        public readonly Function Outer, Inner;
        public Composition(Function outer, Function inner)
        {
            Outer = outer;
            Inner = inner;
        }
        public override Function Clone()
        {
            return new Composition(Outer, Inner);
        }

        public override double Evaluate(double x)
        {
            return Outer[Inner[x]];
        }

        public override Function Derivative()
        {
            return Outer.Derivative().Compose(Inner) * Inner.Derivative();
            
        }

        public Function Sanitize()
        {
            if (Inner is Constant)
            {
                return new Constant(Outer[(Inner as Constant).Value]);
            }
            return this;
        }
    }
}
