using NSM.SERVER.CORE;

namespace NSM.TEST
{
    [TestClass]
    public class BinaryFileTest
    {

        public void replaceTestFile()
        {
            if(!File.Exists("TestFiles\\test.txt"))
            {
                File.Create("TestFiles\\test.txt");
            }
            
        }

        //BinaryFile.Create()
        #region
        [TestMethod]
        [TestCategory("BinaryFile")]
        [Owner("Thiago")]
        public void BinaryCreateExist()
        {
            bool result;
            replaceTestFile();

            using(BinaryFile file = new BinaryFile()) {

                result = file.Create(@"TestFiles\test.txt");

            }

            Assert.IsFalse(result);
        }

        [TestMethod]
        [TestCategory("BinaryFile")]
        [Owner("Thiago")]
        public void BinaryCreateNotExist()
        {
            
            bool result;
            using (BinaryFile file = new BinaryFile())
            {

                result = file.Create(@"TestFiles\new.txt");
            }
            File.Delete(@"TestFiles\new.txt");
      

            Assert.IsTrue(result);
        }

        [TestMethod]
        [TestCategory("BinaryFile")]
        [Owner("Thiago")]
        [ExpectedException(typeof(Exception))]
        public void BinaryCreateIsNull()
        {

            using (BinaryFile file = new BinaryFile())
            {
                file.Create(null);
            }

        }
        #endregion

        //BinaryFile.Open()
        #region
        [TestMethod]
        [TestCategory("BinaryFile")]
        [Owner("Thiago")]
        public void BinaryOpenExist()
        {
            bool result;
            using(BinaryFile file = new BinaryFile())
            {
                result = file.Open(@"TestFiles\test.txt");
            }
            Assert.IsTrue(result);
        }

        [TestMethod]
        [TestCategory("BinaryFile")]
        [Owner("Thiago")]
        public void BinaryOpenNotExist()
        {
            bool result;
            using (BinaryFile file = new BinaryFile())
            {
                result = file.Open(@"TestFiles\notexist.txt");
            }
            Assert.IsFalse(result);
        }

        [TestMethod]
        [TestCategory("BinaryFile")]
        [Owner("Thiago")]
        public void BinaryOpenIsNull()
        {
            bool result;
            using (BinaryFile file = new BinaryFile())
            {
                result = file.Open(null);
            }
            Assert.IsFalse(result);
        }

        #endregion


    }
}