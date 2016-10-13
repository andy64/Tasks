using System;

namespace MethodsModule
{

	class Point {
		public int X { get; set; }
		public int Y { get; set; }

		public Point() {
			X = 0;
			Y = 0;
		}
		public override bool Equals(object obj)
		{
			bool rez = false;
			if (this == obj)
			{
				rez = true;
			}
			else{
				if (obj.GetType() == typeof(Point))
				{
					rez = ((obj as Point).X == X) && ((obj as Point).Y == Y);
				}
			}
			return rez;
		}
		public override string ToString()
		{
			return string.Format("Coordinates: X={0}, Y={1}", X, Y);
		}	
	}


	static class FibFac{	
		static void FibFunc(ref int fib1, ref int fib2){
			int mem = 0;
			mem = fib1;
			fib1 = fib2;
			fib2 = fib2 + mem;
		}
		public static int CalcFactorial(int number) {
			int result = 1;
			if (number < 0) {
				throw new ArithmeticException("Error: method expects positive arguments");
			}
			var enumerator = System.Linq.Enumerable.Range(1, number).GetEnumerator();
			while (enumerator.Current != number) {				
				enumerator.MoveNext();
				result *= enumerator.Current;
			}
			return result;
		}
		public static System.Collections.Generic.List<int> CalcFibonacci(int limit){			
			if (limit>0 && limit < short.MaxValue) {
				int fib1 = 0;
				int fib2 = 1;
				System.Collections.Generic.List<int> rezFib = new System.Collections.Generic.List<int>();
				rezFib.Add (fib1);
				while (fib2 < limit) {
					rezFib.Add (fib2);
					FibFunc (ref fib1, ref fib2);
				}
				return rezFib;
			} else {
				throw new ArithmeticException ("Error: set limit less than 32767 and positive");
			}
		}
		//public static int CalcFactorial(){}
	}

	class ILikeToCountMyInstances{
		public static int count = 0;
		public ILikeToCountMyInstances(){
			count++;
		}
	}

	static class RectangularHelper{
		class SquareFigure{
			int square;
			public SquareFigure(int square){ this.square = square;}
			public int Side{get{ return (int)Math.Sqrt(square); }}
		}
		public static int CalcRectCount(int squareOfSquareRect, int width, int height){
			int rez = 0;
			int side = new SquareFigure(squareOfSquareRect).Side;
			for (int i = 0; i < side / height; i++) {
				rez += side / width;
			}
			return rez;
		}
	}


	class MainClass
	{
		public static void Main(string[] args)
		{
			#region 4.1
			var p1 = new Point() {X = 10, Y = 20 };
			var p2 = new Point() { X = 10, Y = 20 };
			var p3 = p2;
			bool expectTrue = p2.Equals(p1);
			bool expectTrue2 = p3.Equals(p2);
			bool expectFalse = p1 == p2;
			#endregion

			#region 4.2		
			Console.WriteLine("Fibonacci row:");
			FibFac.CalcFibonacci(100).ForEach(i => Console.Write("{0}\t", i));
			Console.WriteLine("\nFactorial: {0}", FibFac.CalcFactorial(5));

			#endregion

			#region 4.3
			var ilcmi1 = new ILikeToCountMyInstances();
			var ilcmi2 = new ILikeToCountMyInstances();
			//expected '2' below:
			string ilcmi3 = string.Format("Count of instances for ILikeToCountMyInstances: {0}", ILikeToCountMyInstances.count);
			#endregion

			#region 4.4
			int rhRez = RectangularHelper.CalcRectCount(100, 2, 5);
			#endregion

			Console.Read();
		
		}
	}
}
