using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculusCS
{
	/// <summary>
	/// Represents a function raised from one 
	/// </summary>
	public class FuncToPower: ISanitizable
	{
		public FuncToPower(Function b, Function e)
		{
			Base = b;
			Exponent = e;
		}
		Function Base, Exponent;
		public Function Sanitize()
		{
			if (Base is Constant)
			{
				return new Composition(new Exponential((Base as Constant).Value, 1), Exponent).Sanitize();
			}
			if (Exponent is Constant)
			{
				return new Composition(new PolynomialTerm(1, (Exponent as Constant).Value), Base);
			}
			return this;
		}
	}
}
