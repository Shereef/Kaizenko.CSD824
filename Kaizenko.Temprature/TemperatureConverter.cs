namespace Kaizenko.Temperature
{
    public class TemperatureConverter
    {
        public double convertCtoF(double c)
        {
            //(0°C × 9/5) + 32 = 32°F
            return c * 9 / 5 + 32;
        }

        public double convertFtoC(double f)
        {
            //(32°F − 32) × 5/9 = 0°C
            return (f - 32) * 5 / 9;
        }
    }
}