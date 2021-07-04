using server.Models;
using System;
using System.Collections.Generic;
namespace server
{
    public class RandomNumber
    {
        public RandomNumber(int minValue = 0, int maxValue = 100)
        {
            MinValue = minValue;
            MaxValue = maxValue;
            Random random = new Random();
            Number = random.Next(minValue, maxValue);
            Details = new List<string>();
        }
        public int Number { get; private set; }
        public int MaxValue { get; set; }
        public int MinValue { get; set; }
        public int NumberOfAttempts { get; set; }
        public List<string> Details { get; set; }

        public AttemptResult Check(int input)
        {
            NumberOfAttempts++;
            var isRight = input == Number ? "right" : "wrong";
            Details.Add($"You guess {input} and you were {isRight}.");
            return new AttemptResult(input, input >= Number, input == Number, MinValue, MaxValue, NumberOfAttempts, Details);
        }

        public AttemptResult Cheat()
        {
            NumberOfAttempts++;
            int input = -1;

            Details.Add($"Well not everyone is smart enough, but keep trying.  Here the current number : {Number}.");
            return new AttemptResult(input, input >= Number, input == Number, MinValue, MaxValue, NumberOfAttempts, Details);

        }
    }
}
