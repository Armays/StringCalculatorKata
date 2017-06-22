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
        public void CalculateASubastraction()
        {
            var calculator = new Calculator();
            var result = calculator.Calculate("1-2,3");
            Check.That(result).IsEqualTo(-1.3);
        }
    }
}
