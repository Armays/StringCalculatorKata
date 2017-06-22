using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using NFluent;
using NUnit.Framework;

namespace SolidExercices.Tests
{
    public class CalculatorShould
    {
        private static Dictionary<char, Func<double, double, double>> ConstructDictionary()
        {
            double Addition(double a, double b) => a + b;
            double Substraction(double a, double b) => a - b;
            double Division(double a, double b) => a / b;
            double Multiplication(double a, double b) => a * b;

            var dictionary =
                new Dictionary<char, Func<double, double, double>>
                {
                    {'+', Addition},
                    {'-', Substraction},
                    {'/', Division},
                    {'*', Multiplication}
                };

            return dictionary;
        }

        [Test]
        public void CalculateASum()
        {
            var calculator = new Calculator();
            var result = calculator.Calculate("1+2,3", CalculatorShould.ConstructDictionary());
            Check.That(result).IsEqualTo(3.3);
        }
        public void CalculateAMultipleSum()
        {
            var calculator = new Calculator();
            var result = calculator.Calculate("1+2,3+5.5", CalculatorShould.ConstructDictionary());
            Check.That(result).IsEqualTo(8.8);
        }
        public void CalculateASubastraction()
        {
            var calculator = new Calculator();
            var result = calculator.Calculate("1-2,3", CalculatorShould.ConstructDictionary());
            Check.That(result).IsEqualTo(-1.3);
        }
        public void CalculateAMultipleSubastraction()
        {
            var calculator = new Calculator();
            var result = calculator.Calculate("1-2,3-7", CalculatorShould.ConstructDictionary());
            Check.That(result).IsEqualTo(-8.3);
        }
        public void CalculateADivision()
        {
            var calculator = new Calculator();
            var result = calculator.Calculate("10/5", CalculatorShould.ConstructDictionary());
            Check.That(result).IsEqualTo(2);
        }
        public void CalculateADivisionByZero()
        {
            var calculator = new Calculator();
            try
            {
                calculator.Calculate("10/0", CalculatorShould.ConstructDictionary());
                Assert.Fail("Expected exception");
            }
            catch (DivideByZeroException)
            {
                // Expected
            }
        }
        public void CalculateANonOperation()
        {
            var calculator = new Calculator();
            try
            {
                calculator.Calculate("10,0", CalculatorShould.ConstructDictionary());
                Assert.Fail("Expected exception");
            }
            catch (NoneOperatorException)
            {
                // Expected
            }
        }
        public void CalculateWithMultipleOperators()
        {
            var calculator = new Calculator();
            try
            {
                calculator.Calculate("10+5-2", CalculatorShould.ConstructDictionary());
                Assert.Fail("Expected exception");
            }
            catch (MultipleOperatorsException)
            {
                // Expected
            }
        }
        public void CalculateAMultipleDivision()
        {
            var calculator = new Calculator();
            var result = calculator.Calculate("10*5*2", CalculatorShould.ConstructDictionary());
            Check.That(result).IsEqualTo(1);
        }
        public void CalculateAMultiplication()
        {
            var calculator = new Calculator();
            var result = calculator.Calculate("2*3", CalculatorShould.ConstructDictionary());
            Check.That(result).IsEqualTo(6);
        }
        public void CalculateAMultipleMultiplication()
        {
            var calculator = new Calculator();
            var result = calculator.Calculate("2*3*5", CalculatorShould.ConstructDictionary());
            Check.That(result).IsEqualTo(30);
        }
    }
}
