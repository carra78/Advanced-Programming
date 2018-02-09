using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CA3CalculatorC
{
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

		//private static string[] oneValueSymbols = { "s", "r", "c", "%", "!" };
		private static string[] twoValueSymbols = { "+", "-", "*", "/", "^" };

		//Properties
		public string[] TwoValueSymbols
		{
			get
			{
				return twoValueSymbols;
			}
		}
		
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
		public static decimal Add(decimal value1, decimal value2)
		{
			return value1 + value2;
		}

		public static decimal Cube(decimal value)
		{
			return value * value * value;			
		}

		public static decimal Divide(decimal value1, decimal value2)
		{
			return value1 / value2;
		}

		public static double Exponent(double baseNumber, double power)
		{
			return Math.Pow(baseNumber, power);
		}

		public static int Factorial(int value)
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

		public static decimal Multiply(decimal value1, decimal value2)
		{
			return value1 * value2;
		}

		public static decimal PercentToDecimal(decimal value)
		{
			return value / 100;
		}

		public void PrintFunction()
		{
			foreach (KeyValuePair<string, string> pair in myFunctions)
			{
				Console.Write("| {0} : {1} |", pair.Key, pair.Value);
			}
			Console.WriteLine();
		}

		public static decimal Square(decimal value)
		{
			return value * value;
		}

		public static double SquareRoot(double value)
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

		public dynamic SelectedFunction(string function, string input1, string input2 = "0")
		{
			switch (function)
			{				
				case "+":
					{
						try
						{
							return Calculator.Add(decimal.Parse(input1), decimal.Parse(input2));
						}
						catch (Exception)
						{
							throw new ArithmeticException("Invalid input - try again!");
						}
					 }
				case "c":
					try
					{
						return Calculator.Cube(decimal.Parse(input1));
					}
					catch (Exception e)
					{
						return e.Message.ToString();
					}
				case "-":
					try
					{
						return Calculator.Subtract(decimal.Parse(input1), decimal.Parse(input2));
					}
					catch (Exception e)
					{
						return e.Message.ToString();
					}
				case "*":
					try
					{
						return Calculator.Multiply(decimal.Parse(input1),decimal.Parse(input2));
					}
					catch (Exception e)
					{
						return e.Message.ToString();
					}
				case "/":
					try
					{
						return Calculator.Divide(decimal.Parse(input1), decimal.Parse(input2));
					}
					catch (DivideByZeroException e)
					{
						return e.Message.ToString();
					}
					
				case "^":
					try
					{
						return Calculator.Exponent(double.Parse(input1), double.Parse(input2));
					}
					catch (Exception e)
					{
						return e.Message.ToString();
					}
				case "s":
					try
					{
						return Calculator.Square(decimal.Parse(input1));
					}
					catch (Exception e)
					{
						return e.Message.ToString();
					}
				case "r":
					try
					{
						return Calculator.SquareRoot(double.Parse(input1));
					}
					catch (ArithmeticException e)
					{
						return e.Message.ToString();
					}

				case "%":
					try
					{
						return Calculator.PercentToDecimal(decimal.Parse(input1));
					}
					catch (Exception e)
					{
						return e.Message.ToString();
					}
				case "!":
					try
					{
						return Calculator.Factorial(int.Parse(input1));
					}
					catch (ArithmeticException e)
					{
						return e.Message.ToString();
					}
					

				default:
					return "Invalid input - try again";
			}

		}

		public static decimal Subtract(decimal value1, decimal value2)
		{
			return value1 - value2;
		}


	}
}
