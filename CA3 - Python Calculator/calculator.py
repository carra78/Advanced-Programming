# -*- coding: utf-8 -*-
"""
Created on Wed Jan 10 22:22:14 2018

@author: Orla
"""
import math

class Calculator():
    
    def __init__(self):
        pass
    
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
        return number / 100
    
    def square(self, number):
        return self.exponent(number, 2)
    
    def squareRoot(self, number):
        try:
            return math.sqrt(number)
        except ValueError as sqrtError:
            return "No square root of a negative number"
        
    def subtract(self, number1, number2):
        return number1 - number2
    
    