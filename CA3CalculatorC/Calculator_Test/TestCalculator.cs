using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CA3CalculatorC;

namespace Calculator_Test
{
	[TestClass]
	public class TestCalculator
	{
		[TestMethod]
		public void TestUserInput1()
		{
			Calculator mycalc = new Calculator();
			mycalc.UserInput1 = 5;
			Assert.AreEqual(5, mycalc.UserInput1);
			mycalc.UserInput1 = 5.6M;
			Assert.AreEqual(5.6M, mycalc.UserInput1);
			mycalc.UserInput1 = -5.8M;
			Assert.AreEqual(-5.8M, mycalc.UserInput1);

		}
		/* Couldn't find a way to test this in c# - don't think it's necessary 
		 * as c# is statically typed and so the property won't accept something that
		 * isn't a decimal
		[TestMethod]
		[ExpectedException(typeof(System.ArgumentException))]
		public void TestAcceptUserInput1EqualsStringFails()
		{
			Calculator mycalc = new Calculator();
			mycalc.userInput1 = "abcd";
			mycalc.userInput1 = "+";

		}
		*/

		[TestMethod]
		public void TestUserInput2()
		{
			Calculator mycalc = new Calculator();
			mycalc.UserInput2 = 5;
			Assert.AreEqual(5, mycalc.UserInput2);
			mycalc.UserInput2 = 5.6M;
			Assert.AreEqual(5.6M, mycalc.UserInput2);
			mycalc.UserInput2 = -5.8M;
			Assert.AreEqual(-5.8M, mycalc.UserInput2);

		}

		[TestMethod]
		public void TestAdd()
		{
			Calculator mycalc = new Calculator();
			Assert.AreEqual(4, mycalc.Add(2, 2));
			Assert.AreEqual(0, mycalc.Add(2, -2));
			Assert.AreEqual(-4, mycalc.Add(-2, -2));
			Assert.AreEqual(2, mycalc.Add(2, 0));
			Assert.AreEqual(5, mycalc.Add(2, 3));
			Assert.AreEqual(4.5M, mycalc.Add(2, 2.5M));
			Assert.AreEqual(4.75M, mycalc.Add(3.25M,1.5M));
			Assert.AreEqual(1.75M, mycalc.Add(3.25M, -1.5M));
		}

		[TestMethod]
		public void TestCube()
		{
			Calculator mycalc = new Calculator();
			Assert.AreEqual(27, mycalc.Cube(3));
			Assert.AreEqual(-27, mycalc.Cube(-3));
			Assert.AreEqual(0.125M, mycalc.Cube(0.5M));
			Assert.AreEqual(0, mycalc.Cube(0));
		}

		[TestMethod]
		public void TestDivide()
		{
			Calculator mycalc = new Calculator();
			Assert.AreEqual(2, mycalc.Divide(4, 2));
			Assert.AreEqual(-3, mycalc.Divide(6,-2));
			Assert.AreEqual(16, mycalc.Divide(8, 0.5M));
			Assert.AreEqual(0.25M, mycalc.Divide(0.5M, 2));
			Assert.AreEqual(1, mycalc.Divide(0.5M,0.5M));
		}

		[TestMethod]
		[ExpectedException(typeof(System.DivideByZeroException))]
		public void TestDivideByZero()
		{
			Calculator mycalc = new Calculator();
			mycalc.Divide(4, 0);
		}

		[TestMethod]
		public void TestExponent()
		{
			Calculator mycalc = new Calculator();
			Assert.AreEqual(256, mycalc.Exponent(2, 8));
			Assert.AreEqual(0.25, mycalc.Exponent(2, -2));
			Assert.AreEqual(3.1622776601683795, mycalc.Exponent(10, 0.5));
			Assert.AreEqual(0.0016000000000000003, mycalc.Exponent(0.2, 4));

		}

		[TestMethod]
		public void TestFactorial()
		{
			Calculator mycalc = new Calculator();
			Assert.AreEqual(1, mycalc.Factorial(1));
			Assert.AreEqual(1, mycalc.Factorial(0));
			Assert.AreEqual(24, mycalc.Factorial(4));
		}

		[TestMethod]
		[ExpectedException(typeof(System.ArithmeticException))]
		public void TestFactorialInvalidArgument()
		{
			Calculator mycalc = new Calculator();
			mycalc.Factorial(-2);
		}

		[TestMethod]
		public void TestMultiply()
		{
			Calculator mycalc = new Calculator();
			Assert.AreEqual(4, mycalc.Multiply(2, 2));
			Assert.AreEqual(6, mycalc.Multiply(2, 3));
			Assert.AreEqual(-6, mycalc.Multiply(2, -3));
			Assert.AreEqual(6, mycalc.Multiply(-2, -3));
			Assert.AreEqual(0, mycalc.Multiply(2, 0));
			Assert.AreEqual(3, mycalc.Multiply(1.5M, 2));
			Assert.AreEqual(6.25M, mycalc.Multiply(2.5M, 2.5M));
			Assert.AreEqual(-2.5M, mycalc.Multiply(2.5M, -1));
		}

		[TestMethod]
		public void TestPercentToDecimal()
		{
			Calculator mycalc = new Calculator();
			Assert.AreEqual(0.05M, mycalc.PercentToDecimal(5));
			Assert.AreEqual(0.0025M, mycalc.PercentToDecimal(0.25M));
			Assert.AreEqual(-0.2M, mycalc.PercentToDecimal(-20));
			Assert.AreEqual(0, mycalc.PercentToDecimal(0));

		}

		[TestMethod]
		public void TestSquare()
		{
			Calculator mycalc = new Calculator();
			Assert.AreEqual(0, mycalc.Square(0));
			Assert.AreEqual(9, mycalc.Square(3));
			Assert.AreEqual(0.25M, mycalc.Square(0.5M));
			Assert.AreEqual(25, mycalc.Square(-5));
		}

		[TestMethod]
		public void TestSquareRoot()
		{
			Calculator mycalc = new Calculator();
			Assert.AreEqual(3, mycalc.SquareRoot(9));
			Assert.AreEqual(0.5, mycalc.SquareRoot(0.25));

		}

		[TestMethod]
		[ExpectedException(typeof(System.ArithmeticException))]
		public void TestSquareRootLessThanOrEqualZero()
		{
			Calculator mycalc = new Calculator();
			mycalc.SquareRoot(-9);
			mycalc.SquareRoot(0);
		}

		[TestMethod]
		public void TestSelectedFunction()
		{
			Calculator mycalc = new Calculator();
			

			//Assert.AreEqual(13, mycalc.SelectedFunction("+", 5, 8));
		}

		[TestMethod]
		public void TestSubtract()
		{
			Calculator mycalc = new Calculator();
			Assert.AreEqual(0, mycalc.Subtract(2, 2));
		}

	}
}
