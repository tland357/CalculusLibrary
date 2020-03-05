using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculusCS
{
    public class Polynomial : Sum
    {
        public Polynomial(params double[] Coefficients)
        {
            int i = -1;
            foreach (double coeff in Coefficients)
            {

                Functions.Add(new PolynomialTerm(coeff, ++i));
            }
        }
        public int Order
        {
            get
            {
                return Functions.Count();
            }
        }
    }
}
