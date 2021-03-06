using System;
using System.Collections.Generic;

namespace server.Models
{
    public class AttemptResult
    {
        public AttemptResult(int input, bool isLowerOrEqual, bool succeed, int minValue, int maxValue, int numberOfAttempts, List<string> details)
        {

            Id = Guid.NewGuid();
            AmIright = succeed;
            Input = input;
            IsLowerOrEqual = isLowerOrEqual;
            AttemptDateTime = DateTime.Now;
            MinValue = minValue;
            MaxValue = maxValue;
            NumberOfAttempts = numberOfAttempts;
            Details = details.ToArray();
        }
        public Guid Id { get; set; }
        public bool AmIright { get; set; }
        public int Input { get; set; }

        public int NumberOfAttempts { get; set; }

        public bool IsLowerOrEqual { get; set; }

        public int MinValue { get; set; }
        public int MaxValue { get; set; }

        public DateTime AttemptDateTime { get; set; }
        public string[] Details { get; set; }
    }
}
