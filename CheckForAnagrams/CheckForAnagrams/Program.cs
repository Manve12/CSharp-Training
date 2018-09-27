using System;

namespace CheckForAnagrams
{
    class Program
    {
        /// <summary>
        /// Check if two strings are an anagram of each other
        /// </summary>
        /// <param name="_input">Initial string</param>
        /// <param name="_compareTo">String to comprate to the initial string</param>
        /// <returns>Boolean</returns>
        public static bool IsAnagram(string _input, string _compareTo)
        {
            var tempString = ""; //used to temporarily store string - used for comparison
            
            //Loop through both string and check if the characters match - if true then store it in the temp string, otherwise don't
            foreach (var inputCharacter in _input)
            {
                foreach (var compareCharacter in _compareTo)
                {
                    if (inputCharacter.ToString().ToLower() == compareCharacter.ToString().ToLower()) // check the characters
                    {
                        tempString += inputCharacter;
                        break; // break out of loop to move to the next string
                    }
                }
            }
            
            //Check if temp string matches the input string
            if (tempString.ToLower() == _input.ToLower())
            {
                return true;
            } else
            {
                return false;
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine(IsAnagram("Dave Barry", "Ray Adverb"));
        }
    }
}
