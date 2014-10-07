using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpScoutContracts
{
    public class Mailbox
    {
        public int id { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
        public string email { get; set; }
        public string createdAt { get; set; }
        public string modifiedAt { get; set; }
    }
}
