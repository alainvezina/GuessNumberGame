using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Models
{
    public class RandomNumber
    {
        public RandomNumber(int minValue = 0, int maxValue = 100)
        {
            this.MinValue = minValue;
            this.MaxValue = maxValue;
            Random random = new System.Random();
            this.Number = random.Next(minValue, maxValue);
            this.Details = new List<string>();
        }
        public int Number { get; private set; }

        public int MaxValue { get; set; }
        public int MinValue { get; set; }

        public int NumberOfAttempts
        {
            get; private set;
        }


        public List<string> Details { get; set; }
        public AttemptResult Check(int input)
        {
            NumberOfAttempts++;
            var isRight = input == Number ? "right" : "wrong";
            Details.Add($"You guess {input} and you were {isRight}");
            return new AttemptResult(input, input >= Number, input == Number, MinValue, MaxValue, NumberOfAttempts, Details);
        }

        public AttemptResult Cheat()
        {
            NumberOfAttempts++;
            int input = 0;

            Details.Add($"Well not everyone is smart enough, but keep trying.  Here the current number : {Number}");
            return new AttemptResult(0, input >= Number, input == Number, MinValue, MaxValue, NumberOfAttempts, Details);

        }
    }
}
