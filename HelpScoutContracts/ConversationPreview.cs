using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace HelpScoutContracts
{
    public class ConversationPreview
    {
        public int id { get; set; }
        public string type { get; set; }
        public int folderId { get; set; }
        public bool isDraft { get; set; }
        public int number { get; set; }
        public Person owner { get; set; }
        public Mailbox mailbox { get; set; }
        public Person customer { get; set; }
        public int threadCount { get; set; }
        public string status { get; set; }
        public string subject { get; set; }
        public string preview { get; set; }
        public Person createdBy { get; set; }
        public string createdAt { get; set; }
        public string userModifiedAt { get; set; }
        public string closedAt { get; set; }
        public Person closedBy { get; set; }
        public Source source { get; set; }
        public string createdByType { get; set; }
        public List<string> cc { get; set; }
        public List<string> bcc { get; set; }
        public List<string> tags { get; set; }

        public string DisplayText
        {
            get
            {
                var createdAtTime = DateTime.Parse(createdAt);

                return String.Format("{0} {1} - {2} - {3} - {4}", customer.firstName, customer.lastName, subject, preview,
                    createdAtTime.ToLocalTime().ToLongTimeString());
            }
        }
    }
}
