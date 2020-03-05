using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculusCS
{
    public class PolynomialTerm : Function
    {
        public readonly double Exponent;
        public static PolynomialTerm Identity = new PolynomialTerm();
        public PolynomialTerm(double coefficient = 1, double exponent = 1)
        {
            Coefficient = coefficient;
            Exponent = exponent;
        }
        public override Function Derivative()
        {
            if (Coefficient == 0 || Exponent == 0) return new Constant(0);
            if (Exponent == 1) return new Constant(Coefficient);
            return new PolynomialTerm(Coefficient * Exponent, Exponent - 1);
        }
        public override double Evaluate(double x)
        {
            return Math.Pow(x, Exponent) * Coefficient;
        }

        public override Function Clone()
        {
            return new PolynomialTerm(Coefficient, Exponent);
        }

        /// <summary>
        /// Takes in a list of polynomial terms all with the same exponent and returns a single term
        /// </summary>
        /// <param name="terms"></param>
        /// <returns>Returns null if an empty list is provided</returns>
        public static PolynomialTerm CombineLikeTerms(IList<PolynomialTerm> terms)
        {
            if (terms.Count() == 0) return null;
            double exponent = terms[0].Exponent;
            double coeff = 0;
            foreach (var term in terms)
            {
                if (term.Exponent != exponent) throw new ArgumentException("Parameters must all have the same power");
                coeff += term.Coefficient;
            }
            return new PolynomialTerm(coeff, exponent);
        }
    }
}
