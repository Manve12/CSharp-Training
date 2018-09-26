using System;
using System.Collections.Generic;
using System.Linq;

namespace MueseumOfDullThings
{
    class Program
    {
        /// <summary>
        /// Remove the lowest integer in an array
        /// </summary>
        /// <param name="ratingArray">Integer array to iterate over</param>
        /// <returns>Array of integers without lowest or empty array</returns>
        public static int[] RemoveLowestRating(int[] ratingArray)
        {
            try
            {
                var index = Array.IndexOf(ratingArray, ratingArray.Min());
                var listRating = new List<int>(ratingArray);

                listRating.RemoveAt(index);

                return listRating.ToArray();
            }
            catch
            {
                return ratingArray;
            }
        }

        static void Main(string[] args)
        {
            var array = RemoveLowestRating(new int[] { 1, 2, 3, 4, 5 });
            foreach(var item in array)
            {
                Console.WriteLine(item);
            }
        }
    }
}
