using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HelpScoutDAL
{
    public class HelpScoutApi
    {
        private WebClient _client;

        public HelpScoutApi()
        {
            _client = new WebClient();
        }
    }
}
