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
            Assert.AreEqual("", pencil.Write("", paper, out int characterCount));
        }

        [TestMethod]
        public void PencilWriteMethodReturnsStringItWasPassedTest()
        {
            string testString = "test string";
            Assert.AreEqual(testString, pencil.Write("test string", paper, out int characterCount));
        }

        [TestMethod]
        public void PencilWriteAppendsStringItWasPassedToPreviousStringTest()
        {
            Assert.AreEqual("test string", pencil.Write("test string", paper, out int characterCount));
            Assert.AreEqual(pencil.Write("!", paper, out characterCount), "test string!");
        }

        [TestMethod]
        public void PencilWriteMethodCanHandleSpacesTest()
        {
            Assert.AreEqual(" ", pencil.Write(" ", paper, out int characterCount));
        }

        [TestMethod]
        public void PencilCharacterCountMethodReturnsCountOfCharactersInAStringTest()
        {
            Assert.AreEqual(5, pencil.CharacterCount("hello"));
        }

        [TestMethod]
        public void PencilCharacterCountMethodDoesNotCountSpacesInReturnedCharacterCountTest()
        {
            Assert.AreEqual(0,pencil.CharacterCount(" "));
        }

        [TestMethod]
        public void PencilCharacterCountWillCountCharactersInAStringWithSpacesTest()
        {
            Assert.AreEqual(2, pencil.CharacterCount("t t"));
        }

        [TestMethod]
        public void PencilWriteMethodPassOutTheNumberOfCharactersWrittenTest()
        {
            pencil.Write("hello", paper, out int characterCount);
            Assert.AreEqual(5, characterCount);
        }

        [TestMethod]
        public void PencilWriteMethodDegradesPencilPointByTheIntReturnedByCharacterCountMethodTest()
        {
            pencil.Write("hello!", paper, out int characterCount);
            Assert.AreEqual(4, pencil.RemainingDurability);
        }

        [TestMethod]
        public void PencilCharacterCountMethodIgnoresNewlineCharactersInCharacterCount()
        {
            pencil.Write("Hello\\r\\nWorld", paper, out int characterCount);
            Assert.AreEqual(10, characterCount);
        }
       


    }
}
