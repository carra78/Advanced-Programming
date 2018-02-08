import math

class Calculator(object):
    """Functions of a Calculator"""
    def __init__(self):
        self.__userinput1 = 0
        self.__userinput2 = 0
        self.__myFunctions = { '+':'Add',
                               '-':'Subtract',
                               '*':'Multiply',
                               '/':'Divide',
                               '^':'Exponent',
                               's':'Squared',
                               'r':'Square Root',
                               'c':'Cubed',
                               '%':'Percent to Decimal',
                               '!':'Factorial'}
        self.__oneValueFunction = {'s':self.square, 'r':self.squareRoot, 'c':self.cube, '%':self.percentToDecimal,'!':self.factorial}
        self.__twoValueFunction = {'+':self.add, '-':self.subtract, '*' : self.multiply, '/':self.divide, '^':self.exponent}
        self.__oneValueSymbols = ['s','r','c','%','!']
        self.__twoValueSymbols = ['+','-','*','/','^']
        self.userfunction = ''
        self.userinput = False
        
    @property
    def userinput1(self):
        return self.__userinput1
    
    @userinput1.setter
    def userinput1(self, value):
        try:
            self.__userinput1 = float(value)
        except:
            raise ValueError
    
    @property
    def userinput2(self):
        return self.__userinput2
        
    @userinput2.setter
    def userinput2(self, value):
        try:
            self.__userinput2 = float(value)
        except:
            raise ValueError
         
    @property
    def oneValueSymbols(self):
        return self.__oneValueSymbols
        
    @property
    def twoValueSymbols(self):
        return self.__twoValueSymbols
    
    
    def add(self, number1, number2):
        return number1 + number2
        #return math.add(number1, number2)
        
    def cube(self, number):
        return number ** 3
    
    def divide(self, number1, number2):
        try:
            return number1 / number2
        except ZeroDivisionError:
            return "Can't divide by zero!"
    
    def exponent(self, base, power):
        return base ** power
    
    def factorial(self, number):
        try:
            if(number <2):
                return 1
            else:
                result = 1
                for i in range(2,number+1):
                    result *= i
                return result
        except ValueError as factorialError:
            return "Not possible to calculate factorial of a negative number"
    
    def multiply(self, number1, number2):
        return number1 * number2
    
    def percentToDecimal(self, number):
        return float(number) / 100
    
    def printFunction(self):
        mf = self.__myFunctions
        for k, v in mf.items():
            print('| {0} : {1} |'.format(k, v), end = '' )
    
    def square(self, number):
        return self.exponent(number, 2)
    
    def squareRoot(self, number):
        try:
            return math.sqrt(number)
        except ValueError as sqrtError:
            return "No square root of a negative number"
        
    def subtract(self, number1, number2):
        return number1 - number2
        
    def selectFunction(self, function, value1, value2=0):
        result = 0
        if function in self.__oneValueSymbols:
            oneFunc = self.__oneValueFunction
            for key in oneFunc:
                if(key == function):
                    result = oneFunc[function](value1)
                    return result
        elif function in self.__twoValueSymbols:
            twoFunc = self.__twoValueFunction
            for key in twoFunc:
                if (key == function):
                    result = twoFunc[function](value1, value2)
                    return result
    def checkQuit(self, input):
        if (input == 'q' or input =='Q'):
            self.userinput = True
            return print("Goodbye!")
        


