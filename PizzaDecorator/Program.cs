using System;

namespace PizzaDecorator
{
	abstract class Pizza {
		public int Price { get; protected set; }
		public string Name { get; protected set; }
		public void ChangeName(string newName) {
			Name = newName;
		}
	}

	class CheezePizza : Pizza {
		public CheezePizza() { Price = 100; Name = "Cheeze pizza"; }
	}

	class MeatPizza : Pizza {
		public MeatPizza() { Price = 200; Name = "Meat pizza"; }
	}

	class VegetarianPizza : Pizza {
		public VegetarianPizza() { Price = 300; Name = "Vegetarian pizza"; }
	}

	abstract class PizzaDecorator : Pizza {
		protected Pizza piz;
	}

	class Pepper : PizzaDecorator {
		public Pepper(Pizza piz) { 
			this.piz = piz;

		}



	}

	class MainClass
	{
		public static void Main(string[] args)
		{
			bool undefined = false;
			do
			{
				Console.WriteLine("Pizzamaker would like to suggest you delicious pizza:\n1 - cheese\n2 - meat\n3 - vegetarian");
				switch (Console.ReadKey().KeyChar)
				{
					case '1':

						break;
					case '2':

						break;
					case '3':

						break;
					default:
						undefined = true;
						break;
				}
			} while (undefined == true);
		}
	}
}
