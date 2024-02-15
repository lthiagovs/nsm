using NSM.SERVER.Models;

namespace NSM.TEST
{
    [TestClass]
    public class DatabaseTest
    {
        //Database.Message_CreateUser
        #region
        [TestMethod]
        [TestCategory("Database")]
        [Owner("Thiago")]
        public void CreateUserWithValidInformations()
        {

            bool result = Database.CreateUser("","","","");

            Assert.IsTrue(result);
        }

        [TestMethod]
        [TestCategory("Database")]
        [Owner("Thiago")]
        public void CreateUserWithNotValidInformations()
        {
            bool result = Database.CreateUser(null, null, null, null);

            Assert.IsFalse(result);
        }
        #endregion

        //Database.Message_GetUser
        #region
        [TestMethod]
        [TestCategory("Database")]
        [Owner("Thiago")]
        public void GetUserWithValidInformations()
        {

            User? user = Database.GetUser("test","test");

            Assert.IsNotNull(user);
        }

        [TestMethod]
        [TestCategory("Database")]
        [Owner("Thiago")]
        public void GetUserWithNotValidInformations()
        {

            User? user = Database.GetUser(null, null);

            Assert.IsNull(user);
        }
        #endregion

        //Database.DeleteUser
        #region
        [TestMethod]
        [TestCategory("Database")]
        [Owner("Thiago")]
        public void DeleteUserThatExist()
        {

            Database.CreateUser("_delete_", "_delete_", "_delete_", "_delete_");
            Database.DeleteUser("_delete_", "_delete_");
            User? user = Database.GetUser("_delet_", "_delete_");
            Assert.IsNull(user);

        }

        [TestMethod]
        [TestCategory("Database")]
        [Owner("Thiago")]
        [ExpectedException(typeof(Exception))]
        public void DeleteUserThatNotExist()
        {

            Database.DeleteUser("__","__");

        }

        [TestMethod]
        [TestCategory("Database")]
        [Owner("Thiago")]
        [ExpectedException(typeof(Exception))]
        public void DeleteUserWithNull()
        {
            Database.DeleteUser(null,null);
        }
        #endregion

        //Database.CreateNotification
        #region
        [TestMethod]
        [TestCategory("Database")]
        [Owner("Thiago")]
        public void CreateNotificationWithValidInformation()
        {
            bool result = Database.CreateNotification(1, "_test_");

            Assert.IsTrue(result);
        }

        [TestMethod]
        [TestCategory("Database")]
        [Owner("Thiago")]
        public void CreateNotificationWithNotValidInformation()
        {
            bool result = Database.CreateNotification(-1, "_test_");

            Assert.IsFalse(result);
        }

        [TestMethod]
        [TestCategory("Database")]
        [Owner("Thiago")]
        public void CreateNotificationWithNullInformation()
        {
            bool result = Database.CreateNotification(1, null);

            Assert.IsFalse(result);
        }

        #endregion

        //Database.GetNotifications
        #region
        [TestMethod]
        [TestCategory("Database")]
        [Owner("Thiago")]
        public void GetNotificationsWithValidInformations()
        {
            List<Notification> notifications = Database.GetNotifications(1);

            Assert.IsTrue(notifications.Count >= 1);

        }

        [TestMethod]
        [TestCategory("Database")]
        [Owner("Thiago")]
        public void GetNotificationsWithNotValidInformations()
        {
            List<Notification> notifications = Database.GetNotifications(0);

            Assert.IsTrue(notifications.Count < 1);

        }
        #endregion

        //Database.DeleteNotification
        #region
        [TestMethod]
        [TestCategory("Database")]
        [Owner("Thiago")]
        [ExpectedException(typeof(Exception))]
        public void DeleteNotificationsWithNotInformations()
        {
            Database.DeleteNotification(0);

        }
        #endregion

        //Database.CreateMessage
        #region
        [TestMethod]
        [TestCategory("Database")]
        [Owner("Thiago")]
        public void CreateMessageWithValidInformations()
        {
            bool result = Database.CreateMessage("_test_", 1);
            Assert.IsTrue(result);

        }

        [TestMethod]
        [TestCategory("Database")]
        [Owner("Thiago")]
        public void CreateMessageWithNotValidInformations()
        {
            bool result = Database.CreateMessage("_test_", 0);
            Assert.IsFalse(result);

        }

        [TestMethod]
        [TestCategory("Database")]
        [Owner("Thiago")]
        public void CreateMessageWithNullInformations()
        {
            bool result = Database.CreateMessage(null, 0);
            Assert.IsFalse(result);

        }

        #endregion

        //Database.GetMessages
        #region
        [TestMethod]
        [TestCategory("Database")]
        [Owner("Thiago")]
        public void GetMessagesWithValidInformations()
        {

            List<Message> Messages = Database.GetMessages(1);
            Assert.IsTrue(Messages.Count >= 1);

        }

        [TestMethod]
        [TestCategory("Database")]
        [Owner("Thiago")]
        public void GetMessagesWithNotValidInformations()
        {

            List<Message> Messages = Database.GetMessages(0);
            Assert.IsFalse(Messages.Count >= 1);

        }
        #endregion

        //Database.DeleteMessage
        #region
        [TestMethod]
        [TestCategory("Database")]
        [Owner("Thiago")]
        [ExpectedException(typeof(Exception))]
        public void DeleteMessagesWithNotValidInformations()
        {

            Database.DeleteMessage(0);

        }
        #endregion

        //Database.CreateChat
        #region
        [TestMethod]
        [TestCategory("Database")]
        [Owner("Thiago")]
        public void CreateChatWithValidInformations()
        {

            bool result = Database.CreateChat("_test_", 1);
            Assert.IsTrue(result);

        }

        [TestMethod]
        [TestCategory("Database")]
        [Owner("Thiago")]
        public void CreateChatWithNotValidInformations()
        {

            bool result = Database.CreateChat("_test_", 0);
            Assert.IsFalse(result);

        }

        [TestMethod]
        [TestCategory("Database")]
        [Owner("Thiago")]
        public void CreateChatWithNullInformations()
        {

            bool result = Database.CreateChat(null, 1);
            Assert.IsFalse(result);

        }
        #endregion

        //Database.GetChats
        #region
        [TestMethod]
        [TestCategory("Database")]
        [Owner("Thiago")]
        public void GetChatsWithValidInformations()
        {

            List<Chat> Chats = Database.GetChats(1);
            Assert.IsTrue(Chats.Count >= 1);

        }

        [TestMethod]
        [TestCategory("Database")]
        [Owner("Thiago")]
        public void GetChatsWithNotValidInformations()
        {

            List<Chat> Chats = Database.GetChats(0);
            Assert.IsFalse(Chats.Count >= 1);

        }
        #endregion

        //Database.DeleteChat
        #region
        [TestMethod]
        [TestCategory("Database")]
        [Owner("Thiago")]
        [ExpectedException(typeof(Exception))]
        public void DeleteChatWithNotValidInformations()
        {

            Database.DeleteChat(0);

        }
        #endregion

    }
}
