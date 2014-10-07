using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpScoutContracts
{
    public class PagedEntity<T>
    {
        public int page { get; set; }
        public int pages { get; set; }
        public int count { get; set; }
        public List<T> items { get; set; } 
    }
}
