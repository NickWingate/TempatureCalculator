using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempatureCalculator
{
    public class Rankine : Tempature
    {
        public Rankine(double temp) : base(temp) { }

        public override Celsius ConvertToCelsius()
        {
            return new Celsius((LocalTemp - 491.67) * 5 / 9);
        }
    }
}
