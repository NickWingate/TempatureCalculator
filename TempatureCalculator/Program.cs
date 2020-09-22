using System;
using System.Collections.Generic;

namespace TempatureCalculator
{
    class Program
    {
        // maybe use string instead of char for key for ease- although char might give peformance benefit
        public static Dictionary<char, string> UnitType { get; private set; } = new Dictionary<char, string>()
        {
            { 'c', "Celsius"},
            { 'f', "Fahrenheit" },
            { 'k', "Kelvin" },
            { 'r', "Rankine" }
        };

        static void Main()
        {
            while (true)
            {
                Tempature originalTemp = GetOriginalTemp();
                string tempToConvertTo = GetTempToConvertTo();  // should change to char in future
                Console.WriteLine($"Tempature in {UnitType[tempToConvertTo[0]]}: {originalTemp.ConvertToCelsius().ConvertFromCelsius(tempToConvertTo)}\n");  // look at this monstrosity
            }
        }

        static Tempature GetOriginalTemp()
        {
            Console.WriteLine("Tempatures: (C)elsius, (F)ahrenheit, (K)elvin, (R)ankine (Ctrl + C to quit)");
            string convertFromTypeString;

            do
            {
                Console.Write("Convert From: ");
                convertFromTypeString = Console.ReadLine().ToLower();
            } while (!ValidateType(convertFromTypeString));

            double value = GetOriginalTempValue(convertFromTypeString[0]);

            switch (convertFromTypeString)
            {
                case "c":
                    return new Celsius(value);
                case "f":
                    return new Fahrenheit(value);
                case "k":
                    return new Kelvin(value);
                case "r":
                    return new Rankine(value);
                default:
                    throw new ArgumentException("Invalid string type/unit");
            }
        }
        static string GetTempToConvertTo()
        {
            string convertToTypeString;
            do
            {
                Console.Write("Convert To: ");
                convertToTypeString = Console.ReadLine().ToLower();
            } while (!ValidateType(convertToTypeString));
            return convertToTypeString;
        }       
        static bool ValidateType(string type)
        {
            // must be better way to do this with already existing dict
            List<string> validTypes = new List<string>(){ "c", "f", "k", "r"};
            if (validTypes.Contains(type))
            {
                return true;
            }
            else
            {
                Console.WriteLine("Invalid tempature type, must be (C)elsius, (F)ahrenheit, (K)elvin, or (R)ankine");
                return false;
            }
        }
        static double GetOriginalTempValue(char type)
        {
            double temp;
            Console.Write($"Tempature in {UnitType[type]}: ");
            while (!Double.TryParse(Console.ReadLine(), out temp))
            {
                Console.WriteLine("Tempature must be a number");
                Console.Write($"Tempature in {type}: ");
            }
            return temp;
        }
    }
}
