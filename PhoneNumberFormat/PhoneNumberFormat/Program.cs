using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PhoneNumberFormat
{
    class Program
    {
        /// <summary>
        /// Checks if phone number matches a correct format
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns>True if phone number is of valid format, False otherwise</returns>
        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            string pattern = @"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}"; // matches us phone numbers e.g: (888) 888-8888;
            
            Match result = Regex.Match(phoneNumber, pattern);

            //check if regex matches to the phone number provided (length of 0 will be returned from regex if not)
            if (result.Length > 0)
            {
                return true;
            }
            return false;
        }

        static void Main(string[] args)
        {
            string phoneNumber = "(123) 456-7890";
            Console.WriteLine(IsValidPhoneNumber(phoneNumber));
        }
    }
}
