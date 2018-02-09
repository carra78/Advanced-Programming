using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA3CalculatorC
{
	class Program
	{
		static void Main(string[] args)
		{
			//instantiate calculator class
			Calculator mycalc = new Calculator();

			//print welcome and instructions for user
			Console.WriteLine("A 10 Function Calculator\n**********************\n" +
				"Please use the following symbol:function pairs to perform calculations:\n");
			mycalc.PrintFunction();
			Console.WriteLine();

			//local variables
			string userNumber1, userNumber2, userFunction, quit = "";

			while (quit != "q")
			{
				Console.Write("Enter a number to start of q to quit: ");
				userNumber1 = Console.ReadLine();
				quit = userNumber1.ToLower();
				if (quit == "q")
					break;
				else
				{
					Console.Write("Select a funtion: ");
					userFunction = Console.ReadLine();
					quit = userFunction.ToLower();
					if (quit == "q")
						break;
					if (mycalc.TwoValueSymbols.Contains(userFunction))
					{
						Console.Write("Enter a second number: ");
						userNumber2 = Console.ReadLine();
						quit = userNumber2.ToLower();
						if (quit == "q")
							break;
						else
						{
							Console.WriteLine(mycalc.SelectedFunction(userFunction, userNumber1, userNumber2));
						}

					}
					else
					{
						Console.WriteLine(mycalc.SelectedFunction(userFunction, userNumber1));
					}
				}
				


			}
			Console.WriteLine("Goodbye!");					
			
			Console.ReadLine();
		}
	}
}
