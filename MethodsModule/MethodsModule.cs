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



	class MainClass
	{
		public static void Main(string[] args)
		{
			var p1 = new Point() {X = 10, Y = 20 };
			var p2 = new Point() { X = 10, Y = 20 };
			var p3 = p2;

			bool expectTrue = p2.Equals(p1);
			bool expectTrue2 = p3.Equals(p2);
			bool expectFalse = p1 == p2;
			Console.WriteLine("");
		}
	}
}
