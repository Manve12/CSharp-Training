using System;
using System.Linq;

namespace Switcharoo
{
    class Program
    {
        /// <summary>
        /// Switches first and last character of a string as long as it has more than 2 characters and does not contain any numbers
        /// </summary>
        /// <param name="_string">string to switch</param>
        /// <returns>string</returns>
        public static string Switcharoo(string _string)
        {
            if (_string.Any(char.IsDigit) || _string.Length < 2) // check if string contains any numbers or is less than 2 characters long
            {
                return "Incompatible.";
            } else if (_string.ToCharArray()[0] == _string.ToCharArray()[_string.Length-1]) // check if first and last character is the same (case-sensitive)
            {
                return "Two's a pair";
            }

            //Switch string around
            var stringArray = _string.ToCharArray();

            var firstCharacter = stringArray[0];
            var lastCharacter = stringArray[stringArray.Length - 1];

            var outputString = "";

            for (int i = 0; i < stringArray.Length; i++)
            {
                //check if character is the first one in the array - swap with the last one
                if (stringArray[i] == firstCharacter && i == 0)
                {
                    outputString += lastCharacter; 
                } else if (stringArray[i] == lastCharacter && i == stringArray.Length-1) // check if character is the last one in the array - swap with the first one
                {
                    outputString += firstCharacter;
                } else // otherwise add character to string
                {
                    outputString += stringArray[i];
                }
            }

            return outputString;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(Switcharoo("Cat, dog, and mouse."));
        }
    }
}
