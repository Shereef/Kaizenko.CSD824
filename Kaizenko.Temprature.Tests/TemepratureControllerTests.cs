using NUnit.Framework;

namespace Kaizenko.Temperature.Tests
{
    [TestFixture]
    public class TemepratureControllerTests
    {
        [TestCase(0, 32)]
        [TestCase(100, 212)]
        [TestCase(-40, -40)]
        [TestCase(25, 77)]
        [TestCase(double.MaxValue, double.PositiveInfinity)]
        [TestCase(double.MinValue, double.NegativeInfinity)]
        public void ConvertCtoF_WhenTempInC_ExpectTempInFF(double tempInC, double expected)
        {
            TemperatureConverter temperatureConverter = new TemperatureConverter();
            var tempInF = temperatureConverter.convertCtoF(tempInC);
            Assert.That(expected, Is.EqualTo(tempInF));
        }

        [TestCase(32, 0)]
        [TestCase(212, 100)]
        [TestCase(-40, -40)]
        [TestCase(77, 25)]
        [TestCase(double.MaxValue, double.PositiveInfinity)]
        [TestCase(double.MinValue, double.NegativeInfinity)]
        public void ConvertFtoC_WhenTempInC_ExpectTempInF(double tempInF, double expected)
        {
            TemperatureConverter temperatureConverter = new TemperatureConverter();
            var tempInC = temperatureConverter.convertFtoC(tempInF);
            Assert.That(expected, Is.EqualTo(tempInC));
        }
    }
}
