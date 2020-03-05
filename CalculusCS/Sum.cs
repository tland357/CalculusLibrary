using System;
using System.Linq;
using System.Collections.Generic;

namespace CalculusCS
{
    public class Sum : Function, ISanitizable
    {
        public Sum(params Function[] funcs)
        {
            Init(funcs);
        }
        void Init(IList<Function> funcs, bool sanitize = false)
        {
            if (funcs.Count() == 0) throw new ArgumentException("Cannot initialize a sum of zero functions!");
            foreach (var function in funcs)
            {
                if (function is Sum)
                {
                    foreach (var function2 in (function as Sum).Functions)
                    {
                        Functions.Add(function2);
                    }
                }
                else
                {
                    Functions.Add(function);
                }
            }
            if (sanitize) Sanitize();
        }
        public Sum(IList<Function> funcs)
        {
            Init(funcs);
        }
        readonly List<Function> functions = new List<Function>();
        public List<Function> Functions { get
            {
                return functions;
            }
        }
        public override Function Derivative()
        {
            List<Function> functions = new List<Function>();
            foreach (var function in Functions)
            {
                if (function is Sum)
                {
                    foreach (var function2 in (function as Sum).Functions)
                    {
                        functions.Add(function2);
                    }
                }
                else
                {
                    functions.Add(function);
                }
            }
            return new Sum(functions.ToArray());
        }
        public override double Evaluate(double x)
        {
            double total = 0;
            foreach (var function in Functions)
            {
                total += function.Evaluate(x);
            }
            return total;
        }

        public override Function Clone()
        {
            List<Function> functions = new List<Function>();
            foreach (var function in Functions)
            {
                functions.Add(function.Clone());
            }
            return new Sum(functions);
        }

        public Function Sanitize()
        {
            IEnumerable<PolynomialTerm> polys = Functions.Select(x => x as PolynomialTerm).Where(x => x != null);
            Functions.RemoveAll(x => polys.Contains(x));
            Dictionary<double, List<PolynomialTerm>> usedPowers = new Dictionary<double, List<PolynomialTerm>>();
            foreach (PolynomialTerm function in polys)
            {
                if (usedPowers.ContainsKey(function.Exponent))
                {
                    usedPowers[function.Exponent].Add(function);
                } else
                {
                    usedPowers.Add(function.Exponent, new List<PolynomialTerm> { function });
                }
            }
            foreach (Sum sum in Functions.Where(x => x is Sum).Select(x => x as Sum))
            {
                this.Functions.Remove(sum);
                foreach (Function f in sum.Functions)
                {
                    this.Functions.Add(f);
                }
            }
            foreach (var likeTerms in usedPowers.Values)
            {
                Functions.Add(PolynomialTerm.CombineLikeTerms(likeTerms));
            }
            for (int i = 0; i < Functions.Count(); i += 1)
            {
                if (Functions[i] is ISanitizable)
                {
                    Functions[i] = (Functions[i] as ISanitizable).Sanitize();
                }
            }
            return this;
        }
    }
}
