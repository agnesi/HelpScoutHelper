using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HelpScoutContracts;
using HelpScoutDAL;

namespace HelpScoutHelper
{
    public partial class ConversationsList : Form
    {
        private HelpScoutApi _api;
        private List<ConversationPreview> _items;

        private Timer _timer;

        public ConversationsList()
        {
            InitializeComponent();
            _api = new HelpScoutApi();

            QueryForUnassignedConversations();

            _timer = new Timer();
            _timer.Tick += timer_Tick;
            _timer.Interval = 180000;
            _timer.Start();
        }

        private void QueryForUnassignedConversations()
        {
            var mailbox = _api.GetMailboxByName("Insight Support");
            var folders = _api.GetFolders(mailbox.name);

            var unassignedFolder = folders.items.FirstOrDefault(f => f.name == "Unassigned");
            var conversations = _api.GetConversationsByMailboxFolder(mailbox.id, unassignedFolder.id);
            _items = conversations.items;

            //refresh datasource
            listBox1.DataSource = null;
            listBox1.DataSource = _items;
            listBox1.DisplayMember = "DisplayText";

            if (_items.Count > 0)
                notifyIcon1.ShowBalloonTip(5000, "New Convos!", "There are new HelpScout conversations awaiting review", ToolTipIcon.Info);
        }

        private void ConversationsList_MouseDoubleClick(object sender, EventArgs e)
        {
            if (sender is ListBox)
            {
                var convo = (sender as ListBox).SelectedItem as ConversationPreview;
                var helpscoutUri = String.Format("https://secure.helpscout.net/conversation/{0}/{1}/", convo.id, convo.number);
                Process.Start(helpscoutUri);
            }
        }

        private void RefreshConversations_Click(object sender, EventArgs e)
        {
            QueryForUnassignedConversations();
            _timer.Stop();
            _timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            QueryForUnassignedConversations();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Activate();
        }
    }
}
