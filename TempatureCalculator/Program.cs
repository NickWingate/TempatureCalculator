using System;


namespace TempatureCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string convertFromType;
            string convertToType;
            double originalTemp;

            while (true)
            {
                (convertFromType, convertToType) = Menu();
                originalTemp = GetOriginalTemp(convertFromType);

                if (convertToType == convertFromType)
                {
                    Console.WriteLine($"{convertToType}: {originalTemp}");
                }
                else
                {
                    Console.WriteLine($"{convertToType}: {ConvertTemp(originalTemp, convertFromType, convertToType)}\n");
                }
            }
        }
        static (string, string) Menu()
        {
            Console.WriteLine("Tempatures: (C)elsius, (F)ahrenheit, (K)elvin (Ctrl + C to quit)");
            string convertFromType;
            string convertToType;
            do
            {
                Console.Write("Convert From: ");
                convertFromType = Console.ReadLine().ToLower();
            } while (!ValidateType(convertFromType));

            do
            {
                Console.Write("Convert To: ");
                convertToType = Console.ReadLine().ToLower();
            } while (!ValidateType(convertToType));

            return (convertFromType, convertToType);
        }
        static bool ValidateType(string type)
        {
            string[] validTypes = { "c", "f", "k" };
            if (Array.IndexOf(validTypes, type) >= 0)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Invalid tempature type, must be (C)elsius, (F)ahrenheit, or (K)elvin");
                return false;
            }
        }
        static double GetOriginalTemp(string type)
        {
            double temp;
            Console.Write($"Tempature in {type}: ");
            while (!Double.TryParse(Console.ReadLine(), out temp))
            {
                Console.WriteLine("Tempature must be a number");
                Console.Write($"Tempature in {type}: ");
            }
            return temp;
        }
        static double ConvertTemp(double temp, string convertFromType, string convertToType)
        {
            if (convertFromType == "k" || convertFromType == "k")
            {
                if (convertToType == "c")
                {
                    return temp - 273.15;
                }
                else if (convertFromType == "c")
                {
                    return temp + 273.15;
                }
                else if (convertToType == "f")
                {
                    return CelsiusFahrenheit(temp - 273.15, convertToType);
                }
                else if (convertFromType == "f")
                {
                    return CelsiusFahrenheit(temp + 273.15, convertToType);
                }
                else
                {
                    throw new ArgumentException("Types that can be used to convert to only consist of c, f, k");
                }
            }
            else
            {
                return CelsiusFahrenheit(temp, convertToType);
            }
        }
        static double CelsiusFahrenheit(double temp, string convertTo)
        {
            if (convertTo == "c")
            {
                return (temp - 32) * 5 / 9;
            }
            else
            {
                return (temp * 9 / 5) + 32;
            }
        }
    }
}
