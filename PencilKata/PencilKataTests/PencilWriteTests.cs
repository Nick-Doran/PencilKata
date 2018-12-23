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
            Assert.AreEqual("a", pencil.Write("a", paper, out int remainingDurability));
        }

        [TestMethod]
        public void PencilWriteMethodReturnsStringItWasPassedTest()
        {
            string testString = "test string";
            Assert.AreEqual(testString, pencil.Write("test string", paper, out int remainingDurability));
        }

        [TestMethod]
        public void PencilWriteAppendsStringItWasPassedToPreviousStringTest()
        {
            Assert.AreEqual("test", pencil.Write("test", paper, out int remainingDurability));
            Assert.AreEqual(pencil.Write("!", paper, out remainingDurability), "test!");
        }

        [TestMethod]
        public void PencilWriteMethodCanHandleSpacesTest()
        {
            Assert.AreEqual(" ", pencil.Write(" ", paper, out int remainingDurability));
        }

        [TestMethod]
        public void PencilRemainingDurabilityIsDegradedAfterWritingAStringOfLowercaseCharactersTest()
        {
            pencil.Write("test", paper, out int remainingDurability);
            Assert.AreEqual(6, pencil.RemainingDurability);
        }

        [TestMethod]
        public void PencilRemainingDurabilityIsNotAffectedBySpacesTest()
        {
            pencil.Write("      ", paper, out int remainingDurability);
            Assert.AreEqual(10, pencil.RemainingDurability);
        }

        [TestMethod]
        public void PencilRemainingDurabilityIsAccurateAfterWritingAStringWithSpacesTest()
        {
            pencil.Write("t  t  t", paper, out int remainingDurability);
            Assert.AreEqual(7, remainingDurability);
        }

        [TestMethod]
        public void PencilWriteMethodPassesOutTheRemainingNumberOfDegradationPointsTest()
        {
            pencil.Write("  ", paper, out int remainingDurability);
            Assert.AreEqual(10, remainingDurability);
        }

        [TestMethod]
        public void PencilWriteMethodDegradesPencilPointAfterWritingAStringWithUppercaseAndPunctuationTest()
        {
            pencil.Write("Hello!", paper, out int remainingDurability);
            Assert.AreEqual(3, pencil.RemainingDurability);
        }

        [TestMethod]
        public void PencilWriteIgnoresNewlineCharactersWhenDegradingThePencilPointTest()
        {
            pencil.Write("hi\\r\\nworld", paper, out int remainingDurability);
            Assert.AreEqual(3, remainingDurability);
        }

        [TestMethod]
        public void PencilCharacterCountIgnoresSoloNewLineCharactersTest()
        {
            pencil.Write("\\r\\n", paper, out int remainingDurability);
            Assert.AreEqual(10, remainingDurability);
        }

        [TestMethod]
        public void PencilWriteMethodCountsUppercaseCharactersAsTwoCharacterDegradationPointsTest()
        {
            pencil.Write("A", paper, out int remainingDurability);
            Assert.AreEqual(8, remainingDurability);
        }
        
        [TestMethod]
        public void PencilWriteMethodReturnsAccurateCountFromStringWithNewLineAndUppercaseCharactersTest()
        {
            pencil.Write("Hello\\r\\n  ! !", paper, out int remainingDurability);
            Assert.AreEqual(2, remainingDurability);
        }

        [TestMethod]
        public void PencilWriteMethodWritesEmptySpacesWhenRemainingDurabilityIsZeroTest()
        {
            Assert.AreEqual("1 2 3 4 5 6 7 8 9 1 ", pencil.Write("1 2 3 4 5 6 7 8 9 10", paper, out int characterCount));
        }

    }
}
