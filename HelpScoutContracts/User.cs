using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpScoutContracts
{
    public class User
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string fullName { get; set; }
        public string email { get; set; }
        public string role { get; set; }
        public string timezone { get; set; }
        public string photoUrl { get; set; }
        public string createdAt { get; set; }
        public string modifiedAt { get; set; }
    }
}
