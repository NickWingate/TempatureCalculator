using System;

namespace TempatureCalculator
{
    public abstract class Tempature
    {
        // Properties
        public double LocalTemp { get; set; }

        // Constructors
        protected Tempature(double temp)
        {
            this.LocalTemp = temp;
        }

        // Methods
        public abstract Celsius ConvertToCelsius();

        public override string ToString()
        {
            return Math.Round(LocalTemp).ToString();
        }
    }
}