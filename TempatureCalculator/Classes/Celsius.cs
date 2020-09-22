using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempatureCalculator
{
    public class Celsius : Tempature
    {
        public Celsius(double temp) : base(temp) { }

        public Tempature ConvertFromCelsius(string unitTo)
        {
            switch (unitTo)
            {
                case "f":
                    return new Fahrenheit((LocalTemp * 9 / 5) + 32);
                case "k":
                    return new Kelvin(LocalTemp + 273.15);
                case "r":
                    return new Rankine(LocalTemp * 9 / 5 + 461.57);
                case "c":
                    return this;
                default:
                    throw new ArgumentException("Invalid unit, must be: f, k, r, or c");
            }
        }

        public override Celsius ConvertToCelsius()
        {
            return this;
        }
    }
}
