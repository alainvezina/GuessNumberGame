using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Models
{
    public class AttemptResult
    {
        public AttemptResult(int input, bool isLowerOrEqual, bool succeed, int minValue, int maxValue, int numberOfAttempts, List<string> details)
        {

            this.Id = Guid.NewGuid();
            this.AmIright = succeed;
            this.Input = input;
            this.IsLowerOrEqual = isLowerOrEqual;
            this.AttemptDateTime = DateTime.Now;
            this.MinValue = minValue;
            this.MaxValue = maxValue;
            this.NumberOfAttempts = numberOfAttempts;
            this.Details = details.ToArray();
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
