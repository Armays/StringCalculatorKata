using System;
using System.Collections.Generic;
using System.Linq;

namespace SolidExercices
{
    public class Calculator
    {
        public double Calculate(string operation)
        {
            Func<double, double, double> addition = (a, b) => a + b;
            Func<double, double, double> substraction = (a, b) => a - b;
            Func<double, double, double> division = (a, b) => a / b;
            Func<double, double, double> multiplication = (a, b) => a * b;
            Dictionary<Func<double, double, double>, char> dictionary = new Dictionary<Func<double, double, double>, char>();
            dictionary.Add(addition, '+');
            dictionary.Add(substraction, '-');
            dictionary.Add(division,'/');
            dictionary.Add(multiplication, '*');


            foreach (KeyValuePair<Func<double, double, double>, char> entry in dictionary)
            {
                double response = 0;
                if (operation.Contains(entry.Value))
                {
                    
                    var numbers = operation.Split(entry.Value);
                    for (var i = 0; i < numbers.Length; i++)
                    {
                        double castNumber = Convert.ToDouble(numbers[i]);

                        response = entry.Key(response, castNumber);
                    }
                    return response;
                }
                
            }
            return -99999;
        }
    }
}