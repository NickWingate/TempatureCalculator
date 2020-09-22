

namespace TempatureCalculator
{
    public class Kelvin : Tempature
    {
        public Kelvin(double temp) : base(temp) { }

        public override Celsius ConvertToCelsius()
        {
            return new Celsius(LocalTemp - 273.15);
        }
    }
}
