using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CA3CalculatorC
{
	public delegate T oneValueFunction<T>(T value1, string function);
	public delegate T twoValueFunction<T>(T value1, T value2, string function);

	public class Calculator
	{
		//Variables
		private static Dictionary<string, string> myFunctions = new Dictionary<string, string>()
		{
			{ "+","Add" },
			{ "-","Subtract" },
			{ "*","Multiply" },
			{ "/","Divide" },
			{ "^","Exponent" },
			{ "s","Squared" },
			{ "r","Square Root" },
			{ "c","Cubed" },
			{ "%","Percent to Decimal" },
			{ "!","Factorial" }
		};
		
		
		private static string[] oneValueSymbols = { "s", "r", "c", "%", "!" };
		private static string[] twoValueSymbols = { "+", "-", "*", "/", "^" };

		// Properties
		public decimal UserInput1 { get; set; }
		public decimal UserInput2 { get; set; }
		public Dictionary<string, string> MyFunctions
		{
			get
			{
				return myFunctions;
			}			
		}
		public string UserFunction { get; set; }
		



		//Constructor
		//use default

		//Methods
		public decimal Add(decimal value1, decimal value2, string function = "+")
		{
			return value1 + value2;
		}

		public decimal Cube(decimal value, string function = "c")
		{
			return value * value * value;			
		}

		public decimal Divide(decimal value1, decimal value2, string function = "/")
		{
			return value1 / value2;
		}

		public double Exponent(double baseNumber, double power, string function = "^")
		{
			return Math.Pow(baseNumber, power);
		}

		public int Factorial(int value, string function = "!")
		{
			
			if (value < 0)
			{
				throw new ArithmeticException("Not possible to calculate factorial value of negative numbers.");
			}
			if (value == 1 || value == 0)
			{
				return 1;
			}
			else
			{
				return value * Factorial(value - 1);
			}
		}

		public decimal Multiply(decimal value1, decimal value2, string function = "*")
		{
			return value1 * value2;
		}

		public decimal PercentToDecimal(decimal value, string function = "%")
		{
			return value / 100;
		}

		public decimal Square(decimal value, string function = "s")
		{
			return value * value;
		}

		public double SquareRoot(double value, string function = "r")
		{
			if (value <=0)
			{
				throw new ArithmeticException("Invalid input - try again");
			}
			else
			{
				return Math.Sqrt(value);
			}
		}

		//public decimal SelectedFunction(string function, decimal value1, decimal value2 = 0)
		//{
		//	oneValueFunction oneval = new oneValueFunction();

		//	if (oneValueSymbols.Contains(function))
		//	{

		//	}

		//	return 13;
		//}

		public decimal Subtract(decimal value1, decimal value2, string function = "-")
		{
			return value1 - value2;
		}


	}
}
