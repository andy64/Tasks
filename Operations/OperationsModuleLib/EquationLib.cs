using System;

namespace ModuleLib
{
 class Equation
	{
		string eqType;
		int a;
		int b;
		int c;
		public Equation(string etype, string coefs)
		{
			if (etype.Equals("Q") || !etype.Equals("L"))
			{
				throw new Exception("Error: equation type is wrong");
			}
			this.eqType = etype;
			string[] coef = coefs.Split(' ');
			try
			{
				a = int.Parse(coef[0]);
				b = int.Parse(coef[1]);
				c = int.Parse(coef[2]);
			}
			catch
			{
				throw;
			}
		}

		public double Solve()
		{
			double rez = 0.0;
			if (eqType == "L")
			{
				rez = (c - a) / b;
			}
			else {
			}
			return rez;

		}
	}
}
