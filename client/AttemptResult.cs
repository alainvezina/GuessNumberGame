using System;
using System.Collections.Generic;

namespace server.Models
{
    public class AttemptResult
    {
     
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
