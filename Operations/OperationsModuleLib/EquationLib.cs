using System;
using System.IO;

namespace ModuleLib
{
	static class LogEquationHelper
	{
		public static void WriteLog(string logdata)
		{
			FileStream fs = null;
			try
			{
				fs = new FileStream(Path.Combine(Directory.GetCurrentDirectory(), "logfile.txt"),
									FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
				using (var tw = new StreamWriter(fs))
				{
					tw.WriteLine(logdata);
				}

			}
			finally
			{
				if (fs != null)
					fs.Dispose();
			}
		}

	}

	public class LinearEquation : Equation
	{
		public LinearEquation(string coefs) : base(coefs)
		{
			ValidateCoefs(b == 0);
		}
		public override string Solve()
		{
			Result = string.Format("root:\nx={0:0.##}", ((c - a) / b)); ;
			LogEquationHelper.WriteLog(string.Format("Linear equation: {0}x+{1}={2}, {3}", a, b, c, Result));
			return Result;
		}

	}

	public class QuadraticEquation : Equation
	{
		public QuadraticEquation(string coef) : base(coef)
		{
			ValidateCoefs(a == 0);
		}
		public override string Solve()
		{
			var sb = new System.Text.StringBuilder("roots:\n");
			double discrimenant = Math.Pow(b, 2) - 4 * a * c;
			Func<sbyte, float> fun = new Func<sbyte, float>((sbyte sign) =>
			{
				return (float)(-b + Math.Sign(sign) * Math.Sqrt(discrimenant)) / (2 * a);
			});
			if (discrimenant > 0)
			{
				sb.AppendFormat("x1={0:0.##}", fun.Invoke(1));
				sb.AppendFormat("\nx2={0:0.##}", fun.Invoke(-1));
			}
			else if (discrimenant < 0)
			{
				sb.AppendLine("there are no real roots");
			}
			else {
				sb.AppendFormat("x={0:0.##}", fun.Invoke(1));
			}
			Result = sb.ToString();
			LogEquationHelper.WriteLog(string.Format("Quadratic equation: {0}x^2+{1}x+{2}=0, {3}", a, b, c, Result));
			return Result;
		}
	}

	public abstract class Equation
	{
		protected float a;
		protected float b;
		protected float c;
		string result = null;
		public Equation(string coefs)
		{
			string[] coef = coefs.Split(' ');
			try
			{
				a = float.Parse(coef[0], System.Globalization.CultureInfo.InvariantCulture);
				b = float.Parse(coef[1], System.Globalization.CultureInfo.InvariantCulture);
				c = float.Parse(coef[2], System.Globalization.CultureInfo.InvariantCulture);
			}
			catch (Exception e)
			{
				LogEquationHelper.WriteLog(e.Message);
				throw;
			}
		}

		protected void ValidateCoefs(bool condition)
		{
			if (condition)
			{
				Exception exc = new DivideByZeroException("Zero coefficient is not acceptable");
				LogEquationHelper.WriteLog(string.Format("Linear equation: {0}x+{1}={2}, {3}", a, b, c, exc.Message));
				throw exc;
			}
		}
		public string Result { get { return result; } protected set { result = value; } }
		public abstract string Solve();
	}
 
}
