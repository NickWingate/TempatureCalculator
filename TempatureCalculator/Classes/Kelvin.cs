using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
