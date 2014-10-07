using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpScoutContracts
{
    public class Folder
    {
        public int id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public int userId { get; set; }
        public int totalCount { get; set; }
        public int activeCount { get; set; }
        public string modifiedAt { get; set; }
    }
}
