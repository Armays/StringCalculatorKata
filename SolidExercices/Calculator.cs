using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;

namespace SolidExercices
{
    public class Calculator
    {
        public double Calculate(string operation, Dictionary<char, Func<double, double, double>> dictionary)
        {
            
            
            try
            {
                var found = false;
                foreach (var entry in dictionary)
                {
                    if (found) throw new MultipleOperatorsException();
                    if (!operation.Contains(entry.Key)) continue;
                    else found = true;
                    var numbers = operation.Split(entry.Key);
                    return numbers.Select(Convert.ToDouble)
                        .Aggregate<double, double>(0, (current, castNumber) => entry.Value(current, castNumber));
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