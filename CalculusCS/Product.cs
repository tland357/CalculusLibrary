using System;
using System.Collections.Generic;
using System.Linq;

namespace CalculusCS
{
    public class Product : Function
    {
        readonly List<Function> functions = new List<Function>();
        public List<Function> Functions
        {
            get
            {
                return functions;
            }
        }
        void Init(IList<Function> funcs)
        {
            if (funcs.Count() == 0) throw new ArgumentException("Cannot initialize a product of zero functions!");
            foreach (var function in funcs)
            {
                if (function is Product)
                {
                    foreach (var function2 in (function as Product).Functions)
                    {
                        Functions.Add(function2);
                    }
                }
                else
                {
                    Functions.Add(function);
                }
            }
        }
        public Product(IList<Function> funcs)
        {
            Init(funcs);   
        }
        public Product(params Function[] funcs)
        {
            Init(funcs);
        }

        public override Function Derivative()
        {
            List<Function> newFunctions = new List<Function>();
            foreach (var function in functions)
            {
                List<Function> InnerProduct = new List<Function>();
                foreach (var function2 in functions)
                {
                    InnerProduct.Add(function != function2 ? function2 : function.Derivative());
                }
                newFunctions.Add(new Product(InnerProduct));
            }
            return new Sum(newFunctions);
        }

        public override double Evaluate(double x)
        {
            double total = 1;
            foreach (var Function in Functions)
            {
                total *= Function.Evaluate(x);
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
            return new Product(functions);
        }
    }
}
