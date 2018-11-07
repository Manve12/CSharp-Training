using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicEmailValidation
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "";

            while (input != "quit")
            {
                Console.Clear();
                Console.WriteLine("Please enter an email or type quit to exit the program");

                input = Console.ReadLine();
                Console.WriteLine(IsEmailValid(input));
                Console.WriteLine("Press enter to type another email in");
                Console.ReadLine();
            }
        }

        private static bool IsEmailValid(string input)
        {

                //check if entered value does not contain special characters only
                if (CheckIfLetterOrDigit(input))
                    return false;

                var splitAt = input.Split('@');
                if (splitAt.Length > 1) // check if after the @ symbol there is text
                {
                    var beforeAtSymbol = splitAt[0];
                    var afterAtSymbol = splitAt[1];

                    if (!(beforeAtSymbol.Length > 0)) // check if before the @ symbol there is text 
                    {
                        return false;
                    }

                    var splitStop = afterAtSymbol.Split('.');
                    if (splitStop.Length > 1)
                    {
                        var beforeStop = splitStop[0];
                        var afterStop = splitStop[1];
                    }
                    else // if no . detected after the @ symbol
                    {
                        return false;
                    }

                }
                else // if not @ symbol detected
                {
                    return false;
                }

                return true;
            
        }

        private static bool CheckIfLetterOrDigit(string str)
        {
            return str.All(s => !Char.IsLetterOrDigit(s));
        }
    }
}
