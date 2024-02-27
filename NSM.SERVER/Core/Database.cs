using Microsoft.EntityFrameworkCore;
using NSM.SERVER.Database;
using NSM.SERVER.Models;
using static System.Net.Mime.MediaTypeNames;

namespace NSM.SERVER.CORE
{
    public static class Database
    {

        public static bool CreateUser(string name, string password, string login, string photo) 
        {

            using (DatabaseContext db = new DatabaseContext())
            {
                try
                {
                    User newUser = new User();
                    newUser.Id = 0;
                    newUser.Name = name;
                    newUser.Password = password;
                    newUser.Login = login;
                    newUser.Photo = photo;

                    db.User.Add(newUser);
                    db.SaveChanges();
                    return true;

                }catch
                {
                    return false;
                }

            }

        }

        public static User? GetUser(string login, string password)
        {
            User? getUser = null;
            using (DatabaseContext db = new DatabaseContext())
            {
                try
                {
                    getUser = db.User.Single(x => login.Equals(x.Login) && password.Equals(x.Password));
                    return getUser;
                }
                catch
                {
                    return getUser;
                    // Comentário legal
                }

            }

        }

        public static User? GetUser(string name)
        {
            User? getUser = null;
            using (DatabaseContext db = new DatabaseContext())
            {
                try
                {
                    getUser = db.User.Single(x => x.Name.Equals(name));
                    return getUser;
                }
                catch
                {
                    return getUser;
                }

            }

        }

        public static bool UserExist(string name)
        {
            User? getUser = null;
            using (DatabaseContext db = new DatabaseContext())
            {
                try
                {
                    getUser = db.User.Single(x => name.Equals(x.Name));
                    return true;
                }
                catch
                {
                    return false;
                }

            }

        }

        public static void DeleteUser(string login, string password)
        {
            
            using(DatabaseContext db = new DatabaseContext())
            {

                try
                {
                    User user = db.User.Single(x => x.Login.Equals(login) && x.Password.Equals(password));
                    db.User.Remove(user);
                    db.SaveChanges();
                }catch
                {
                    throw new Exception();
                }

            }

        }

        public static bool CreateNotification(int UserId, string Description)
        {

            using(DatabaseContext db = new DatabaseContext())
            {
                try
                {
                    Notification Notification = new Notification();
                    Notification.Id = 0;
                    Notification.UserId = UserId;
                    Notification.Description = Description;

                    db.Notification.Add(Notification);
                    db.SaveChanges();

                    return true;
                }
                catch
                {
                    return false;
                }
            }
            
        }

        public static List<Notification> GetNotifications(int UserId)
        {
            List<Notification> notifications = new List<Notification>();

            using(DatabaseContext db = new DatabaseContext())
            {

                notifications = db.Notification.Where(x => x.UserId == UserId).ToList();

            }

            return notifications;
        }

        public static void DeleteNotification(int NotificationId)
        {

            using(DatabaseContext db = new DatabaseContext())
            {
                try
                {
                    
                    Notification Notification = db.Notification.Single(x=> x.Id == NotificationId);
                    db.Notification.Remove(Notification);
                    db.SaveChanges();

                }
                catch
                {
                    throw new Exception();
                }
            }

        }

        public static bool CreateMessage(string Content, int ChatId)
        {
            using(DatabaseContext db = new DatabaseContext())
            {
                try
                {

                    Message Message = new Message();
                    Message.Id = 0;
                    Message.ChatId = ChatId;
                    Message.Content = Content;

                    db.Message.Add(Message);
                    db.SaveChanges();

                    return true;
                }
                catch
                {

                    return false;
                }
            }

        }

        public static List<Message> GetMessages (int ChatId)
        {
            List<Message> messages = new List<Message>();

            using(DatabaseContext db = new DatabaseContext())
            {

                messages = db.Message.Where(x=> x.ChatId == ChatId).ToList();

            }

            return messages;
        }

        public static void DeleteMessage(int MessageId)
        {

            using (DatabaseContext db = new DatabaseContext())
            {

                try
                {
                    Message Message = db.Message.Single(x => x.Id == MessageId);
                    db.Message.Remove(Message);
                    db.SaveChanges();

                }
                catch
                {
                    throw new Exception();
                }

            }

        }

        public static bool CreateChat(string name, int UserId)
        {

            using(DatabaseContext db = new DatabaseContext())
            {

                try
                {

                    //Add to Chat
                    Chat Chat = new Chat();
                    Chat.Id = 0;
                    Chat.Name = name;

                    db.Chat.Add(Chat);
                    db.SaveChanges();

                    //Add to ChatUser 
                    Chat = (db.Chat.ToList())[db.Chat.Count()-1];

                    ChatUser ChatUser = new ChatUser();
                    ChatUser.Id = 0;
                    ChatUser.ChatId = Chat.Id;
                    ChatUser.UserId = UserId;

                    db.ChatUser.Add(ChatUser);
                    db.SaveChanges();
                    
                    return true;
                }
                catch
                {
                    return false;
                }

            }

        }

        public static void BoundChat(int ChatId, int UserId)
        {
            ChatUser chatUser = new ChatUser();
            chatUser.ChatId = ChatId;
            chatUser.UserId = UserId;
            using(DatabaseContext db = new DatabaseContext())
            {
                db.ChatUser.Add(chatUser);
                db.SaveChanges();
            }
        }

        public static Chat GetLastChat()
        {
            using(DatabaseContext db = new DatabaseContext())
            {
                return (db.Chat.ToList())[db.Chat.Count() - 1];
            }
        }

        public static List<Chat> GetChats(int UserId)
        {
            List<Chat> chats = new List<Chat>();

            using(DatabaseContext db = new DatabaseContext())
            {

                //Get ChatUser
                List<ChatUser> chatUsers = new List<ChatUser>();
                chatUsers = db.ChatUser.Where(x => x.UserId == UserId).ToList();

                try
                {
                    for (int i = 0; i < chatUsers.Count; i++)
                    {
                        //Get Chats
                        chats.Add(db.Chat.Single(x => x.Id == chatUsers[i].ChatId));
                    }

                }
                catch
                {
                    throw new Exception();
                }


            }

            return chats;
        }

        //**Very complex!!**// O(x^2) //**Very complex!!**//
        public static Chat GetFriendChat(int UserId, int FriendId)
        {
            Chat Chat = null;
            using(DatabaseContext db = new DatabaseContext())
            {
                try
                {
                    //Search for a chat in common
                    foreach(ChatUser userChats in db.ChatUser)
                    {

                        //Got a chat thats user have!
                        if(userChats.UserId == UserId)
                        {

                            foreach(ChatUser friendChats in db.ChatUser)
                            {

                                //Got a chat that the friend have!
                                if (friendChats.UserId == FriendId)
                                {
                                    //They are the same!
                                    if (friendChats.ChatId == userChats.ChatId)
                                    {
                                        return db.Chat.Single(x => x.Id == friendChats.ChatId);
                                    }
                                }

                            }

                        }

                    }


                    return Chat;
                }
                catch
                {
                    return Chat;
                }
            }

        }

        public static void DeleteChat(int ChatId)
        {

            using(DatabaseContext db = new DatabaseContext())
            {

                try
                {

                    Chat Chat = db.Chat.Single(x => x.Id == ChatId);
                    db.Chat.Remove(Chat);

                }
                catch
                {
                    throw new Exception();
                }

            }

        }

        //**Very complex!!**// O(x) //**Very complex!!**//
        public static List<Chat> GetGroups(int UserId)
        {
            List<Chat> Groups = new List<Chat>();


            using (DatabaseContext db = new DatabaseContext())
            {

                //Get user chats
                List<ChatUser> UserChats = db.ChatUser.Where(x => x.UserId == UserId).ToList();

                //Get all user groups
                foreach(ChatUser chatUser in UserChats)
                {
                    try
                    {
                        Groups.Add(db.Chat.Single(x => x.Id == chatUser.ChatId && !(x.Name.Equals("FriendChat")) ));
                    }
                    catch
                    {
                        continue;
                    }
                }


            }
            return Groups;
        }

        public static bool ChangeProfilePhoto(int UserId, byte[] image)
        {
            try
            {
                using (DatabaseContext db = new DatabaseContext())
                {
                    User user = db.User.Single(x => x.Id == UserId);
                    user.Photo = @"Photos\"+user.Name+".jpg";
                    db.User.Attach(user);
                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();

                    //Save photo
                    if(!File.Exists(user.Photo)) {
                        File.Create(user.Photo).Close();
                    }
                    File.WriteAllBytes(user.Photo, image);
                    //Save photo

                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static string GetProfilePhoto(int UserId)
        {
            string photo64 = "";

            try
            {
                using(DatabaseContext db = new DatabaseContext())
                {
                    User user = db.User.Single(x=>x.Id==UserId);

                    byte[] imgBytes = File.ReadAllBytes(@"Photos\"+user.Name+".jpg");
                    photo64 = Convert.ToBase64String(imgBytes);

                }
                return photo64;
            }
            catch
            {
                return photo64;
            }
            
        }
        public static string ChangeUserName(int UserId, string NewName)
        {
            string oldName = "";
            try
            {
                using(DatabaseContext db = new DatabaseContext())
                {

                    User user = db.User.Single(x => x.Id == UserId);
                    oldName = user.Name;
                    user.Name = NewName;
                    db.User.Attach(user);
                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();

                }
                return oldName;
            }
            catch
            {
                return oldName;
            }
        }
        public static List<string> GetAllUserNames()
        {
            List<string> names = new List<string>();

            using(DatabaseContext db =new DatabaseContext())
            {

                foreach(User user in db.User)
                {
                    names.Add(user.Name);
                }

            }

            return names;
        }

    }
}
