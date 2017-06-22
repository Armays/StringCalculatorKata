using System;
using System.Collections.Generic;

namespace SolidExercices
{
    public class CalculatorTrainer
    {
        private Dictionary<char, Func<double, double, double>> ConstructDictionary()
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
        private readonly string[] _operations = new[]
            {"1+2,3", "2 x 3,6", "6-1-3,8", "6,6/3", "6/0", "not an operation", "a+1", "12", ""};

        public void Run()
        {
            var calculator = new Calculator();
            foreach (var operation in _operations)
            {
                try
                {
                    var result = calculator.Calculate(operation, this.ConstructDictionary());
                    Console.WriteLine(operation + " = " + result);
                }
                catch (Exception e)
                {
                    Console.WriteLine("ERROR: " + e.Message);
                }
            }
        }
    }
}
