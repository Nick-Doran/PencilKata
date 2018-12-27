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
            Assert.AreEqual("a", pencil.Write("a", paper));
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
            Assert.AreEqual("test", pencil.Write("test", paper));
            Assert.AreEqual(pencil.Write("!", paper), "test!");
        }

        [TestMethod]
        public void PencilWriteMethodCanHandleSpacesTest()
        {
            Assert.AreEqual(" ", pencil.Write(" ", paper));
        }

        [TestMethod]
        public void PencilRemainingDurabilityIsDegradedAfterWritingAStringOfLowercaseCharactersTest()
        {
            pencil.Write("test", paper);
            Assert.AreEqual(6, pencil.RemainingDurability);
        }

        [TestMethod]
        public void PencilRemainingDurabilityIsNotAffectedBySpacesTest()
        {
            pencil.Write("      ", paper);
            Assert.AreEqual(10, pencil.RemainingDurability);
        }

        [TestMethod]
        public void PencilRemainingDurabilityIsAccurateAfterWritingAStringWithSpacesTest()
        {
            pencil.Write("t  t  t", paper);
            Assert.AreEqual(7, pencil.RemainingDurability);
        }

        [TestMethod]
        public void PencilWriteMethodPassesOutTheRemainingNumberOfDegradationPointsTest()
        {
            pencil.Write("  ", paper);
            Assert.AreEqual(10, pencil.RemainingDurability);
        }

        [TestMethod]
        public void PencilWriteMethodDegradesPencilPointAfterWritingAStringWithUppercaseAndPunctuationTest()
        {
            pencil.Write("Hello!", paper);
            Assert.AreEqual(3, pencil.RemainingDurability);
        }

        [TestMethod]
        public void PencilWriteIgnoresNewlineCharactersWhenDegradingThePencilPointTest()
        {
            pencil.Write("hi\\r\\nworld", paper);
            Assert.AreEqual(3, pencil.RemainingDurability);
        }

        [TestMethod]
        public void PencilCharacterCountIgnoresSoloNewLineCharactersTest()
        {
            pencil.Write("\\r\\n", paper);
            Assert.AreEqual(10, pencil.RemainingDurability);
        }

        [TestMethod]
        public void PencilWriteMethodCountsUppercaseCharactersAsTwoCharacterDegradationPointsTest()
        {
            pencil.Write("A", paper);
            Assert.AreEqual(8, pencil.RemainingDurability);
        }
        
        [TestMethod]
        public void PencilWriteMethodReturnsAccurateCountFromStringWithNewLineAndUppercaseCharactersTest()
        {
            pencil.Write("Hello\\r\\n  ! !", paper);
            Assert.AreEqual(2, pencil.RemainingDurability);
        }
        [TestMethod]
        public void PencilWriteMethodWritesEmptySpacesWhenRemainingDurabilityIsZeroTest()
        {
            Assert.AreEqual("1 2 3 4 5 6 7 8 9 1 ", pencil.Write("1 2 3 4 5 6 7 8 9 10", paper));
        }
        [TestMethod]
        public void CustomPencilConstructorPointDegradationTest()
        {
            Pencil customPencil = new Pencil(100, 10, 100);
            Assert.AreEqual("ABCDEFGHIJKLMNOPQRSTUVWXYZ", customPencil.Write("ABCDEFGHIJKLMNOPQRSTUVWXYZ", paper));
        }

    }
}
