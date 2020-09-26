namespace TempatureCalculator
{
    public class Fahrenheit : Tempature
    {
        public Fahrenheit(double temp) : base(temp)
        {
        }

        public override Celsius ConvertToCelsius()
        {
            return new Celsius((LocalTemp - 32) * 5 / 9);
        }
    }
}