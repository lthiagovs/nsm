using NSM.SERVER.Database;
using NSM.SERVER.Models;

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
                }
                catch
                {
                    return getUser;
                }

            }
            return getUser;

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



    }
}
