using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Models
{
    public class PasswordChecker
    {
        public PasswordChecker()
        {
            this.Secret = DateTime.Now.ToString("yyyyMMdd");
        }
        public string Secret { get; private set; }

        public bool IsValid { get; private set; }
        public AttemptResult Validate(string input) {

            var details = new List<string>();

            if (input?.Length != Secret.Length)
            {
                details.Add($"Password must be {Secret.Length} digits."); 
            }

            if (!string.IsNullOrEmpty(input) && !input.All(char.IsDigit))
            {
                details.Add($"Password must be only digits.");
            }

            if (details.Count == 0)
            {
                if (Secret == input)
                {
                    details.Add($"Congrats!! You're a genius...");
                    IsValid = true;
                }
                else
                {
                    details.Add($"Well not everyone is a genius, but keep trying!!");
                }
            }
            return new AttemptResult(input, IsValid) {
                Details = details.ToArray()
            };
        }
    }
}
