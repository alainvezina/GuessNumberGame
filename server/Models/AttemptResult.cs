using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Models
{
    public class AttemptResult
    {
        public AttemptResult(string password, bool success = false)
        {

            this.Id = Guid.NewGuid();
            this.Success = success;
            this.Password = password;
            this.AttemptDateTime = DateTime.Now;
        }
        public Guid Id { get; set; }
        public bool Success { get; set; }
        public string Password { get; set; }

        public DateTime AttemptDateTime { get; set; }
    }
}
