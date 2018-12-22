using Microsoft.VisualStudio.TestTools.UnitTesting;
using PencilKata;

namespace PencilKataTests
{
    [TestClass]
    public class PencilWriteTests
    {
        Pencil pencil;
        Paper paper;

        [TestInitialize]
        public void Initialize()
        {
            pencil = new Pencil();
            paper = new Paper();
        }
        [TestMethod]
        public void PencilWriteMethodReturnsAStringTest()
        {
            Assert.AreEqual("", pencil.Write("", paper));
        }
        [TestMethod]
        public void PencilWriteMethodReturnsStringItWasPassedTest()
        {
            string testString = "test string";
            Assert.AreEqual(testString, pencil.Write("test string", paper));
        }
        [TestMethod]
        public void PencilWriteAppendsStringItWasPassedToPreviousStringTest()
        {
            Assert.AreEqual("test string", pencil.Write("test string", paper));
            Assert.AreEqual(pencil.Write("!", paper), "test string!");
        }
    }
}
