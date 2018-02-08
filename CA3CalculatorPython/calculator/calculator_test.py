import unittest
from calculator import Calculator

class Calculator_Test(unittest.TestCase):
     #create a test class that extends unittest.TestCase class
    def testAcceptUserInput1(self):
        calculator = Calculator()
        calculator.userinput1 = 5
        self.assertEqual(5, calculator.userinput1)
        calculator.userinput1 = 5.6
        self.assertEqual(5.6, calculator.userinput1)
        with self.assertRaises(ValueError):
            calculator.userinput1 = 'abcd'
        with self.assertRaises(ValueError):
            calculator.userinput1 = '+'
            
    def testAcceptUserInput2(self):
        calculator = Calculator()
        calculator.userinput2 = -5
        self.assertEqual(-5, calculator.userinput2)
        calculator.userinput2 = -6.5
        self.assertEqual(-6.5, calculator.userinput2)
        with self.assertRaises(ValueError):
            calculator.userinput2 = 'xyz'

    def testAdd(self):
        #instantiate calculator object to test 
        calculator = Calculator() 
        #Test cases
        self.assertEqual(4, calculator.add(2,2))
        self.assertEqual(0, calculator.add(2,-2))
        self.assertEqual(-4, calculator.add(-2,-2))
        self.assertEqual(2, calculator.add(2,0))
        self.assertEqual(5, calculator.add(2,3))
        self.assertEqual(4.5, calculator.add(2,2.5))
        self.assertEqual(4.75, calculator.add(3.25,1.5))
        self.assertEqual(1.75, calculator.add(3.25,-1.5))
    
    def testCubed(self):
        calculator = Calculator()
        self.assertEqual(27, calculator.cube(3))
        self.assertEqual(-27, calculator.cube(-3))
        self.assertEqual(0.125, calculator.cube(0.5))
        self.assertEqual(0, calculator.cube(0))
    
    def testDivide(self):
        calculator = Calculator()
        self.assertEqual(2, calculator.divide(4,2))
        self.assertEqual(-3, calculator.divide(6,-2))
        self.assertEqual(16, calculator.divide(8, 0.5))
        self.assertEqual(0.25, calculator.divide(0.5, 2))
        self.assertEqual(1, calculator.divide(0.5,0.5))        
        self.assertRaises(TypeError, calculator.divide(5,0))
        
    def testExponent(self):
        calculator = Calculator()
        self.assertEqual(256, calculator.exponent(2,8))
        self.assertEqual(.25, calculator.exponent(2,-2))
        self.assertEqual(3.1622776601683795, calculator.exponent(10, 0.5))
        self.assertEqual(0.0016000000000000003, calculator.exponent(0.2, 4)) # failed due to precision difference - expected result updated
        
        
    def testFactorial(self):
        calculator = Calculator()
        self.assertEqual(1, calculator.factorial(1))
        self.assertEqual(1, calculator.factorial(0))
        self.assertEqual(24, calculator.factorial(4))
        self.assertRaises(TypeError, calculator.factorial(-5))
    
    
    def testMultiply(self):
        calculator = Calculator()
        self.assertEqual(4, calculator.multiply(2,2))
        self.assertEqual(6, calculator.multiply(2,3))
        self.assertEqual(-6, calculator.multiply(2,-3))
        self.assertEqual(6, calculator.multiply(-2,-3))
        self.assertEqual(0, calculator.multiply(2,0))
        self.assertEqual(3, calculator.multiply(1.5,2))
        self.assertEqual(6.25, calculator.multiply(2.5,2.5))
        self.assertEqual(-2.5, calculator.multiply(2.5,-1))
    
    def testPercentToDecimal(self):
        calculator = Calculator()
        self.assertEqual(0.05, calculator.percentToDecimal(5))
        self.assertEqual(0.0025, calculator.percentToDecimal(.25))
        self.assertEqual(-0.2, calculator.percentToDecimal(-20))
        self.assertEqual(0, calculator.percentToDecimal(0))
        
        
    def testSquare(self):
        calculator = Calculator()
        self.assertEqual(0, calculator.square(0))
        self.assertEqual(9, calculator.square(3))
        self.assertEqual(0.25, calculator.square(0.5))
        self.assertEqual(25, calculator.square(-5))
        
    
    def testSquareRoot(self):
        calculator = Calculator()
        self.assertEqual(3, calculator.squareRoot(9))
        self.assertEqual(0.5, calculator.squareRoot(0.25))
        self.assertRaises(TypeError, calculator.squareRoot(-9))
        
    def testSelectFunction(self):
        calculator = Calculator()
        self.assertEqual(13, calculator.selectFunction('+',5,8))
        self.assertEqual(9, calculator.selectFunction('s', 3))

    def testSubtract(self):
        calculator = Calculator()
        self.assertEqual(0, calculator.subtract(2,2))
        self.assertEqual(4, calculator.subtract(2,-2))
        self.assertEqual(0, calculator.subtract(-2,-2))
        self.assertEqual(2, calculator.subtract(2,0))
        self.assertEqual(-1, calculator.subtract(2,3))
        self.assertEqual(-0.5, calculator.subtract(2,2.5))
        self.assertEqual(1.75, calculator.subtract(3.25,1.5))
        self.assertEqual(4.75, calculator.subtract(3.25,-1.5))
        
    
    
    
            

if __name__ == '__main__':
    unittest.main()
