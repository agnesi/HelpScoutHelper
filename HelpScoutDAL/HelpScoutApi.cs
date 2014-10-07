using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using HelpScoutContracts;
using Newtonsoft.Json;

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

        public PagedEntity<User> GetUsers()
        {
            var byteArray = _client.DownloadData("https://api.helpscout.net/v1/users.json");
            var output = Encoding.UTF8.GetString(byteArray);
            return JsonConvert.DeserializeObject<PagedEntity<User>>(output);
        }

        public User GetUserByEmail(string email)
        {
            return GetUsers().items.FirstOrDefault(u => u.email == email);
        }

        public PagedEntity<Mailbox> GetMailboxes()
        {
            var byteArray = _client.DownloadData("https://api.helpscout.net/v1/mailboxes.json");
            var output = Encoding.UTF8.GetString(byteArray);
            return JsonConvert.DeserializeObject<PagedEntity<Mailbox>>(output);
        }

        public Mailbox GetMailboxByName(string mailboxName)
        {
            return GetMailboxes().items.FirstOrDefault(m => m.name == mailboxName);
        }

        public PagedEntity<Folder> GetFolders(string mailboxName)
        {
            var mailbox = GetMailboxByName(mailboxName);
            var uri = String.Format("https://api.helpscout.net/v1/mailboxes/{0}/folders.json", mailbox.id);
            var byteArray = _client.DownloadData(uri);
            var output = Encoding.UTF8.GetString(byteArray);
            return JsonConvert.DeserializeObject<PagedEntity<Folder>>(output);
        }

        public PagedEntity<ConversationPreview> GetConversations(int mailboxId, int userId)
        {
            var uri = String.Format("https://api.helpscout.net/v1/mailboxes/{0}/users/{1}/conversations.json", mailboxId,
                userId);
            var byteArray = _client.DownloadData(uri);
            var output = Encoding.UTF8.GetString(byteArray);
            return JsonConvert.DeserializeObject<PagedEntity<ConversationPreview>>(output);
        }

        public PagedEntity<ConversationPreview> GetConversationsByMailboxFolder(int mailboxId, int folderId)
        {
            var uri = String.Format("https://api.helpscout.net/v1/mailboxes/{0}/folders/{1}/conversations.json",
                mailboxId, folderId);
            var byteArray = _client.DownloadData(uri);
            var output = Encoding.UTF8.GetString(byteArray);
            return JsonConvert.DeserializeObject<PagedEntity<ConversationPreview>>(output);
        }
    }
}
