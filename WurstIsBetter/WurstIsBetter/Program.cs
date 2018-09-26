using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WurstIsBetter
{
    class Program
    {
        /// <summary>
        /// Dictionary full of non wurst sausages
        /// </summary>
        public static Dictionary<string,string> nonWursts = new Dictionary<string, string>()
        {
            {"Kielbasa","Wurst"},
            {"Chorizo","Wurst"},
            {"Moronga","Wurst"},
            {"Salami","Wurst"},
            {"Sausages","Wursts"},
            {"Sausage","Wursts"},
            {"Andouille","Wurst"},
            {"Naem","Wurst"},
            {"Merguez","Wurst"},
            {"Gurka","Wurst"},
            {"Snorkers","Wurst"},
            {"Pepperoni","Wurst"}
        };

        /// <summary>
        /// Method for checking wursts inside of a string
        /// </summary>
        /// <param name="wurstString">string to be changed to wrusified string</param>
        /// <returns>string</returns>
        public static string CheckIfWurst(string wurstString)
        {
            //check if wurst
            //change input into array
            var inputArray = wurstString.Split(" ".ToCharArray());

            HashSet<string> outputWursts = new HashSet<string>(); 

            foreach (var input in inputArray)
            {
                var notFound = false; // used for checking if a word is found inside of a dictionary

                foreach (var nonWurst in nonWursts)
                {
                    if (input.Contains(nonWurst.Key.ToLower())) // check if input is not a wurst but in the dictionary
                    {
                        outputWursts.Add(nonWurst.Value);
                        notFound = true;
                        break;
                    }
                }

                //if word is not found in the wurst sausauge dictionary leave it as it is
                if (!notFound)
                {
                    outputWursts.Add(input);
                }
            }

            //output string to concatenate the hashset into a single string before returning
            var outputString = "";

            foreach (var i in outputWursts)
            {
                outputString += " " + i;
            }

            return outputString.TrimStart(); // return string with trimmed start
        }

        static void Main(string[] args)
        {
            Console.WriteLine(":");
            string userInput = Console.ReadLine();

            Console.WriteLine(CheckIfWurst(userInput));
        }
    }
}

