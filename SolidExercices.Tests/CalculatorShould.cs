using System;
using NFluent;
using NUnit.Framework;

namespace SolidExercices.Tests
{
    public class CalculatorShould
    {
        [Test]
        public void CalculateASum()
        {
            var calculator = new Calculator();
            var result = calculator.Calculate("1+2,3");
            Check.That(result).IsEqualTo(3.3);
        }
        public void CalculateAMultipleSum()
        {
            var calculator = new Calculator();
            var result = calculator.Calculate("1+2,3+5.5");
            Check.That(result).IsEqualTo(8.8);
        }
        public void CalculateASubastraction()
        {
            var calculator = new Calculator();
            var result = calculator.Calculate("1-2,3");
            Check.That(result).IsEqualTo(-1.3);
        }
        public void CalculateAMultipleSubastraction()
        {
            var calculator = new Calculator();
            var result = calculator.Calculate("1-2,3-7");
            Check.That(result).IsEqualTo(-8.3);
        }
        public void CalculateADivision()
        {
            var calculator = new Calculator();
            var result = calculator.Calculate("10/5");
            Check.That(result).IsEqualTo(2);
        }
        public void CalculateADivisionByZero()
        {
            var calculator = new Calculator();
            try
            {
                calculator.Calculate("10/0");
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
                calculator.Calculate("10,0");
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
                calculator.Calculate("10+5-2");
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
            var result = calculator.Calculate("10*5*2");
            Check.That(result).IsEqualTo(1);
        }
        public void CalculateAMultiplication()
        {
            var calculator = new Calculator();
            var result = calculator.Calculate("2*3");
            Check.That(result).IsEqualTo(6);
        }
        public void CalculateAMultipleMultiplication()
        {
            var calculator = new Calculator();
            var result = calculator.Calculate("2*3*5");
            Check.That(result).IsEqualTo(30);
        }
    }
}
