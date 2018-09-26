using System;

namespace PiToN
{
    class Program
    {
        /// <summary>
        /// Rounds pi to a number of decimal places
        /// </summary>
        /// <param name="numberOfDecimalPlaces"></param>
        /// <returns>Pi to a set number of decimal places (maximum 15)</returns>
        public static double PiToDecimalPlaces(int numberOfDecimalPlaces)
        {
           return Math.Round(Math.PI, numberOfDecimalPlaces);
        }

        static void Main(string[] args)
        {
            Console.WriteLine(PiToDecimalPlaces(15));
        }
    }
}
