using Microsoft.VisualStudio.TestTools.UnitTesting;
using PencilKata;

namespace PencilKataTests
{
    [TestClass]
    public class PencilWriteTests
    {
        Pencil pencil;

        [TestInitialize]
        public void Initialize()
        {
            pencil = new Pencil();
           
        }
        [TestMethod]
        public void PencilWriteMethodReturnsAStringTest()
        {
            Assert.AreEqual("", pencil.Write(""));
        }
        [TestMethod]
        public void PencilWriteMethodReturnsStringItWasPassedTest()
        {
            string testString = "test string";
            Assert.AreEqual(testString, pencil.Write("test string"));
        }

    }
}
