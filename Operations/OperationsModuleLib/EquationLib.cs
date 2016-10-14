using System;

namespace ModuleLib
{
	public class Equation
	{
		string eqType;
		int a;
		int b;
		int c;
		public Equation(string etype, string coefs)
		{
			if (!etype.Equals("Q") && !etype.Equals("L"))
			{
				throw new Exception("Error: equation type is wrong. Type 'L' or 'Q'");
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
			if ((eqType.Equals("L") && b == 0) || (eqType.Equals("Q") && a == 0))
			{
				throw new DivideByZeroException("Zero coefficient is not acceptable");
			}
		}

		string SolveLinear()
		{
			return string.Format("Equation result:\nx={0}", ((c - a) / (double)b));
		}
		string SolveSquare()
		{
			var sb = new System.Text.StringBuilder("Equation result:\n");
			double discrimenant = Math.Pow(b, 2) - 4 * a * c;
			Func<sbyte, double> fun = new Func<sbyte, double>((sbyte sign) =>
			{
				return (-b + Math.Sign(sign) * Math.Sqrt(discrimenant)) / (double)(2 * a);
			});
			if (discrimenant > 0)
			{
				sb.AppendFormat("x1={0}", fun.Invoke(1));
				sb.AppendFormat("x2={0}", fun.Invoke(-1));
			}
			else if (discrimenant < 0)
			{
				sb.AppendLine("there are no real roots");
			}
			else {
				sb.AppendFormat("x={0}", fun.Invoke(1));
			}
			return sb.ToString();
		}

		public string Solve()
		{
			try
			{
				switch (eqType)
				{
					case "L":
						return SolveLinear();
					case "Q":
						return SolveSquare();
					default:
						throw new Exception("Invalid equation type");
				}
			}
			catch (Exception e)
			{
				return e.ToString();
			}
		}
	}
 
}
