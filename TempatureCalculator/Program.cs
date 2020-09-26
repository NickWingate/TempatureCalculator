using System;
using System.Collections.Generic;

namespace TempatureCalculator
{
    internal class Program
    {
        // only use this once in GetOriginalTempValue, possibly redundant
        public static Dictionary<char, string> UnitType { get; private set; } = new Dictionary<char, string>()
        {
            { 'c', "Celsius"},
            { 'f', "Fahrenheit" },
            { 'k', "Kelvin" },
            { 'r', "Rankine" }
        };

        private static void Main()
        {
            while (true)
            {
                Tempature originalTemp = GetOriginalTemp();
                char tempToConvertTo = GetTempToConvertTo();
                Console.WriteLine($"Tempature in {UnitType[tempToConvertTo]}: {originalTemp.ConvertToCelsius().ConvertFromCelsius(tempToConvertTo)}(nearest int)\n");  // look at this monstrosity
            }
        }

        private static Tempature GetOriginalTemp()
        {
            Console.WriteLine("Tempatures: (C)elsius, (F)ahrenheit, (K)elvin, (R)ankine (Ctrl + C to quit)");
            string convertFromTypeString;

            do
            {
                Console.Write("Convert From: ");
                convertFromTypeString = Console.ReadLine().ToLower();
            } while (!ValidateType(convertFromTypeString));
            char convertFromType = convertFromTypeString[0];
            double value = GetOriginalTempValue(convertFromType);

            switch (convertFromType)
            {
                case 'c':
                    return new Celsius(value);

                case 'f':
                    return new Fahrenheit(value);

                case 'k':
                    return new Kelvin(value);

                case 'r':
                    return new Rankine(value);

                default:
                    throw new ArgumentException("Invalid string type/unit");
            }
        }

        private static char GetTempToConvertTo()
        {
            string convertToTypeString;
            do
            {
                Console.Write("Convert To: ");
                convertToTypeString = Console.ReadLine().ToLower();
            } while (!ValidateType(convertToTypeString));
            return convertToTypeString[0];
        }

        private static bool ValidateType(string stringType)
        {
            if (UnitType.ContainsKey(stringType[0]))
            {
                return true;
            }
            else
            {
                Console.WriteLine("Invalid tempature type, must be (C)elsius, (F)ahrenheit, (K)elvin, or (R)ankine");
                return false;
            }
        }

        private static double GetOriginalTempValue(char type)
        {
            double temp;
            Console.Write($"Tempature in {UnitType[type]}: ");
            while (!Double.TryParse(Console.ReadLine(), out temp))
            {
                Console.WriteLine("Tempature must be a number");
                Console.Write($"Tempature in {UnitType[type]}: ");
            }
            return temp;
        }
    }
}