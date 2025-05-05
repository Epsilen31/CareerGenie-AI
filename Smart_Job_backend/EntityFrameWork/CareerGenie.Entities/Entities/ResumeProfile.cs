using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CareerGenie.Entities.Entities
{
    public class ResumeProfile
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string? Skills { get; set; }
        public string? Experience { get; set; }
        public string? Education { get; set; }
        public string? ResumeUrl { get; set; }

        public User? User { get; set; }
    }
}
