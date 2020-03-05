using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;


namespace CalculusCS
{
    public abstract class Function
    {
        static readonly Regex Parentheses = new Regex(@"\(.+\)");
        static readonly Regex Polynomial = new Regex(@"x\^[0-9]+(.+)?([0-9]+)?");
        static readonly Regex Exponential = new Regex(@"[0-9]+(\.+)?([0-9]+)?\^x");
        
        static Dictionary<string, Function> specFuncs;
        public static Dictionary<string, Function> SpecialFunctions
        {
            get
            {
                if (specFuncs == null)
                {
                    specFuncs = new Dictionary<string, Function>();
                    specFuncs.Add("sin", Sine.Sin);
                    specFuncs.Add("cos", Cosine.Cos);
                    specFuncs.Add("tan", Tangent.Tan);
                    specFuncs.Add("csc", Cosecant.Csc);
                    specFuncs.Add("sec", Secant.Sec);
                    specFuncs.Add("cot", Cotangent.Cot);
                    specFuncs.Add("ln", Log.LN);
                    
                }
                return specFuncs;
            }
        }
        public abstract Function Clone();
        public abstract double Evaluate(double x);
        public abstract Function Derivative();
        protected double Coefficient = 1;
        public Function NthDerivative(uint n)
        {
            if (n == 0) return this;
            Function curr = this;
            for (uint i = 0; i < n; i += 1)
            {
                curr = curr.Derivative();
            }
            return curr;
        }
        /*public static Function FromString(string function)
        {
            return EvaluateFunction(function.RemoveWhiteSpace());
        }*/
        static Function EvaluateFunction(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) throw new ArgumentException("Cannot evaluate an empty string");
            var plus = s.SplitFirst('+');
            var minus = s.SplitFirst('-');
            var divide = s.SplitFirst('/');
            var times = s.SplitFirst('*');
            if (plus != null)
            {
                if (plus.Item1.Length == 1)
                {
                    if (plus.Item2 != 0) throw new FormatException("Missing expression following the \"+\" at index (" + plus.Item2 + ")");
                    return EvaluateFunction(plus.Item1[0]);
                } else
                {
                    return new Sum(EvaluateFunction(plus.Item1[0]), EvaluateFunction(plus.Item1[1]));
                }
            }
            else if (minus != null)
            {
                if (minus.Item1.Length == 1)
                {
                    if (minus.Item2 != 0) throw new FormatException("Missing expression following the \"-\" at index (" + minus.Item2 + ")");
                    return new Negation(EvaluateFunction(minus.Item1[0]));
                } else
                {
                    new Sum(EvaluateFunction(minus.Item1[0]), -EvaluateFunction(minus.Item1[1]));
                }
            }
            else if (times != null)
            {
                if (times.Item1.Length == 1) throw new FormatException("Expression not provided for \"*\" at index (" + times.Item2 + ")");
                return new Product(EvaluateFunction(times.Item1[0]), EvaluateFunction(times.Item1[1]));
            }
            else if (divide != null)
            {
                if (divide.Item1.Length == 1) throw new FormatException("Expression not provided for \"/\" at index (" + times.Item2 + ")");
                return new Quotient(EvaluateFunction(divide.Item1[0]), EvaluateFunction(divide.Item1[1]));
            } else
            {
                
            }
            return null;
        }
        public static Sum operator +(Function x, Function y)
        {
            return new Sum(x, y);
        }

        public static Product operator *(Function x, Function y)
        {
            return new Product(x, y);
        }

        public static Function operator -(Function x)
        {
            return new Negation(x);
        }

        public static Function operator -(Function x, Function y)
        {
            return x + -y;
        }

        public static Function operator /(Function x, Function y)
        {
            return new Quotient(x, y);
        }

        /// <summary>
        /// Composes the function with the inner function
        /// </summary>
        /// <param name="inner"></param>
        /// <returns></returns>
        public Function this[Function inner]
        {
            get
            {
                return Compose(inner);
            }
        }

        /// <summary>
        /// evaluates the function at x
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public double this[double x]
        {
            get
            {
                return Evaluate(x);
            }
        }

        /// <summary>
        /// Composes the inner function with the function calling compose
        /// </summary>
        /// <param name="function"></param>
        /// <returns></returns>
        public Function Compose(Function inner)
        {
            return new Composition(this, inner);
        }

        static void Sanitize(ref Function func)
        {
            if (func is ISanitizable)
            {
                (func as ISanitizable).Sanitize();
            }
            if (func is PolynomialTerm)
            {
                if ((func as PolynomialTerm).Exponent == 0)
                {
                    func = new Constant(func.Coefficient);
                }
            }
        }

        /// <summary>
        /// Takes the derivative of the function
        /// </summary>
        /// <param name="function"></param>
        /// <returns></returns>
        public static Function operator ~(Function function)
        {
            return function.Derivative();
        }
    }
}
