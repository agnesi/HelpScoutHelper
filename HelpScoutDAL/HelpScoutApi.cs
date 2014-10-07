using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace HelpScoutDAL
{
    public class HelpScoutApi
    {
        private WebClient _client;
        private readonly string _apiKey = ConfigurationManager.AppSettings["HelpScoutApiKey"];

        public HelpScoutApi()
        {
            _client = new WebClient
            {
                Credentials = new NetworkCredential(_apiKey, "X")
            };
        }

        public object GetConversations()
        {
            return null;
        }


    }
}
