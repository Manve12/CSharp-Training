using System;
using System.Collections.Generic;

namespace CodeActivity
{
    class Program
    {
        static void Main(string[] args)
        {
            float TimeGreen = 60;
            float TimeYellow = 5; 
            float TimeRed = 480; 

            float CurrentSpeed = 10;
            float DistanceToLight = 5000; 

            var TimeTo = DistanceToLight/CurrentSpeed;

            var RandomGreenNotes = new List<string>()
            {
                "Take a nap",
                "You're 10 over, slow it",
                "Pretty sure it's time to lift the right pedal"
            };

            var RandomYellowNotes = new List<string>()
            {
                "Speed up grandma",
                "Risk it?",
                "Hit the right pedal to make it"
            };

            var RandomRedNotes = new List<string>()
            {
                "Red? No .. Green",
                "It's green if no one can see you",
                "Others do it",
                "Now you have to wait",
                "Saying sorry won't make it green",
                "Oh look, you're slow"
            };

            if (TimeTo < TimeGreen)
            {
                Console.WriteLine(RandomGreenNotes[new Random().Next(0,RandomGreenNotes.Count)]);
            } else if (TimeTo < TimeGreen+TimeYellow)
            {
                Console.WriteLine(RandomYellowNotes[new Random().Next(0, RandomYellowNotes.Count)]);
            } else if ((TimeTo > TimeGreen+TimeYellow) && (TimeTo < TimeGreen+TimeYellow+TimeRed))
            {
                Console.WriteLine(RandomRedNotes[new Random().Next(0, RandomRedNotes.Count)]);
            }

            Console.ReadLine();
        }


    }
}
