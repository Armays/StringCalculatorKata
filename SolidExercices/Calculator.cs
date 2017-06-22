using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;

namespace SolidExercices
{
    public class Calculator
    {
        public double Calculate(string operation)
        {
            double Addition(double a, double b) => a + b;
            
            try
            {
                double Substraction(double a, double b) => a - b;
                double Division(double a, double b) => a / b;
                double Multiplication(double a, double b) => a * b;
                var found = false;
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
                    if (found) throw new MultipleOperatorsException();
                    if (!operation.Contains(entry.Value)) continue;
                    else found = true;
                    var numbers = operation.Split(entry.Value);
                    return numbers.Select(Convert.ToDouble)
                        .Aggregate<double, double>(0, (current, castNumber) => entry.Key(current, castNumber));
                }
                if (!found) throw new NoneOperatorException();
                return -99999;
            }
            catch (DivideByZeroException)
            {
                Console.Error.WriteLine("  Division par zéro");
                throw;
            }
            catch (ArithmeticException)
            {
                Console.Error.WriteLine("Exception arithmétique");
                throw;
            }
        }
    }
}