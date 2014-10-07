using System;
using System.Runtime;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HelpScoutDAL.Tests
{
    [TestClass]
    public class HelpScoutApiTests
    {
        [TestMethod]
        public void TestGetUserByEmail()
        {
            var api = new HelpScoutApi();
            var result = api.GetUserByEmail("klin@dbrs.com");
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestGetMailboxByName()
        {
            var api = new HelpScoutApi();
            var result = api.GetMailboxByName("Insight Support");
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestGetFoldersByMailbox()
        {
            var api = new HelpScoutApi();
            var result = api.GetFolders("Insight Support");
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestGetConversations()
        {
            var api = new HelpScoutApi();
            var user = api.GetUserByEmail("klin@dbrs.com");
            var mailbox = api.GetMailboxByName("Insight Support");

            var conversations = api.GetConversations(mailbox.id, user.id);
            Assert.IsNotNull(conversations);
        }
    }
}
