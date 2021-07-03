using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Models
{
    public class AttemptResult
    {
        public AttemptResult(string input, bool success = false)
        {

            this.Id = Guid.NewGuid();
            this.Success = success;
            this.Input = input;
            this.AttemptDateTime = DateTime.Now;
        }
        public Guid Id { get; set; }
        public bool Success { get; set; }
        public string Input { get; set; }
        public DateTime AttemptDateTime { get; set; }
        public string[] Details { get; set; }
    }
}
