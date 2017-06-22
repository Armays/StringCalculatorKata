using System;
using System.Collections.Generic;
using System.Linq;

namespace SolidExercices
{
    public class Calculator
    {
        public double Calculate(string operation)
        {
            double Addition(double a, double b) => a + b;
            double Substraction(double a, double b) => a - b;
            double Division(double a, double b) => a / b;
            double Multiplication(double a, double b) => a * b;
            var dictionary =
                new Dictionary<Func<double, double, double>, char>
                {
                    {Addition, '+'},
                    {Substraction, '-'},
                    {Division, '/'},
                    {Multiplication, '*'}
                };


            foreach (var entry in dictionary)
            {
                if (!operation.Contains(entry.Value)) continue;
                var numbers = operation.Split(entry.Value);
                return numbers.Select(Convert.ToDouble).Aggregate<double, double>(0, (current, castNumber) => entry.Key(current, castNumber));
            }
            return -99999;
        }
    }
}