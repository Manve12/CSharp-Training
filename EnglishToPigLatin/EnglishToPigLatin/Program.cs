using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EnglishToPigLatin
{
    class Program
    {
        private static string[] vowels = new[] {"A", "E", "I", "U", "O"}; // array fo vowels
        
        public static string TranslateWord(string word)
        {
            //variables - used in loops
            int vowelIndexAt = 0;
            bool voewlIndexSet = false;

            //check if word is null
            if (word.Length == 0 || word == null)
            {
                return "";
            }

            //remove any punctuation
            var wordPunctuation = Regex.Match(word.ToCharArray()[word.Length - 1].ToString(), @"[^\w\s]");

            if (wordPunctuation.Length > 0)
            {
                word = word.Substring(0, word.Length - 1);
            }

            //loops to get word after vowel
            foreach (var vowel in vowels) {
                if (word.ToCharArray()[0].ToString().ToLower() == vowel.ToString().ToLower()) //check if the word starts with vowel
                {
                    word = word + "yay";
                    return word;
                }

                for (int i = 0; i < word.Length; i++) // loop through word
                {
                    if (word[i].ToString().ToLower() == vowel.ToString().ToLower() && !voewlIndexSet) // if word character is equal to vowel
                    {
                        vowelIndexAt = i;
                        voewlIndexSet = true;
                        break;
                    }
                }
            }
            
            //get the sections of the word and concatenate them
            var beforeVowel = word.Substring(0, vowelIndexAt);
            var afterVowel = word.Substring(beforeVowel.Count());

            word = afterVowel + beforeVowel + "ay";
            
            return word + wordPunctuation;
        }

        public static string TranslateSentence(string sentence)
        {
            //get an array from the sentence
            var sentenceArray = sentence.ToLower().Split(' ');
            var newSentence = "";
            
            //loop through the words
            foreach(var arrItem in sentenceArray)
            {
                newSentence += " " + TranslateWord(arrItem);
            }

            newSentence = newSentence.Trim(); // trim the space in the front
            newSentence = newSentence.ToCharArray()[0].ToString().ToUpper() + newSentence.Substring(1); //capitalise the sentence

            return newSentence;
        }
        
        static void Main(string[] args)
        {
            Console.WriteLine(TranslateSentence("Do you think it is going to rain today?"));
            Console.WriteLine(TranslateWord("flag"));
        }
    }
}
