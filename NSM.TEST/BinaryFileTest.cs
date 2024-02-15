using NSM.COMMON;

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

        //BinaryFile.WriteAll()
        #region
        [TestMethod]
        [TestCategory("BinaryFile")]
        [Owner("Thiago")]
        public void BinaryWriteAllFileExist()
        {

            using (BinaryFile file = new BinaryFile())
            {
                file.Open(@"TestFiles\test.txt");
                List<string> words = new List<string>();
                words.Add("test");
                words.Add("test");
                file.WriteAll(words);

            }

        }

        [TestMethod]
        [TestCategory("BinaryFile")]
        [Owner("Thiago")]
        [ExpectedException(typeof(Exception))]
        public void BinaryWriteAllFileNotExist()
        {

            using (BinaryFile file = new BinaryFile())
            {
                file.Open(@"TestFiles\notexist.txt");
                List<string> words = new List<string>();
                words.Add("test");
                words.Add("test");
                file.WriteAll(words);

            }

        }

        [TestMethod]
        [TestCategory("BinaryFile")]
        [Owner("Thiago")]
        public void BinaryWriteAllEmptyListt()
        {

            using (BinaryFile file = new BinaryFile())
            {
                file.Open(@"TestFiles\test.txt");
                List<string> words = new List<string>();
                file.WriteAll(words);

            }

        }

        [TestMethod]
        [TestCategory("BinaryFile")]
        [Owner("Thiago")]
        [ExpectedException(typeof(Exception))]
        public void BinaryWriteNullList()
        {

            using (BinaryFile file = new BinaryFile())
            {
                file.Open(@"TestFiles\test.txt");
                file.WriteAll(null);

            }

        }

        [TestMethod]
        [TestCategory("BinaryFile")]
        [Owner("Thiago")]
        [ExpectedException(typeof(Exception))]
        public void BinaryWithoutOpen()
        {

            using (BinaryFile file = new BinaryFile())
            {
                file.WriteAll(null);
            }

        }
        #endregion

        //BinaryFile.ReadAll()
        #region

        [TestMethod]
        [TestCategory("BinaryFile")]
        [Owner("Thiago")]
        public void BinaryReadAllFileExist()
        {
            List<string> strings = new List<string>();
            using (BinaryFile file = new BinaryFile())
            {
                file.Open(@"TestFiles\test.txt");
                strings = file.ReadAll();

            }

            Assert.IsTrue(strings.Count>=1);

        }

        [TestMethod]
        [TestCategory("BinaryFile")]
        [Owner("Thiago")]
        [ExpectedException(typeof(Exception))]
        public void BinaryReadAllFileNotExist()
        {
            List<string> strings = new List<string>();
            using (BinaryFile file = new BinaryFile())
            {
                file.Open(@"TestFiles\notexist.txt");
                strings = file.ReadAll();

            }

        }

        [TestMethod]
        [TestCategory("BinaryFile")]
        [Owner("Thiago")]
        [ExpectedException(typeof(Exception))]
        public void BinaryReadAllWithoutFile()
        {
            List<string> strings = new List<string>();
            using (BinaryFile file = new BinaryFile())
            {
                strings = file.ReadAll();
            }

        }

        #endregion
         
    }
}