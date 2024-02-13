using NSM.SERVER.CORE;
using NSM.SERVER.Models;

namespace NSM.TEST
{
    [TestClass]
    public class DatabaseTest
    {
        //Database.CreateUser
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

        //Database.GetUser
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

    }
}
