using Microsoft.VisualStudio.TestTools.UnitTesting;
using PencilKata;
using System;
using System.Collections.Generic;
using System.Text;

namespace PencilKataTests
{
    [TestClass]
    public class PencilEditMethodTests
    {
        Paper paper;
        Pencil pencil;

        [TestInitialize]
        public void Initialize()
        {
            paper = new Paper();
            pencil = new Pencil();
        }
        [TestMethod]
        public void PencilEditMethodReceivesErasedStringFromEraseMethodWhenItIsCalledTest()
        {
            paper.Text = "This is a test string";
            Assert.AreEqual("This is a      string", pencil.Edit(paper, "test", "    "));
        }
        [TestMethod]
        public void PencilEditMethodDoesNotChangeTextIfThereIsNotAMatchForTheTextToEraseParameterTest()
        {
            paper.Text = "This is a test string";
            Assert.AreEqual("This is a test string", pencil.Edit(paper, "woof", ""));
        }
        [TestMethod]
        public void PencilEditMethodPutsReplacementTextIntoPaperTextPropertyAfterErasingPreviousTextTest()
        {
            paper.Text = "This is a test string";
            Assert.AreEqual("This is a best string", pencil.Edit(paper, "test", "best"));
        }
        [TestMethod]
        public void PencilEditMethodReturnsAStringThatIsTheSameLengthAsTheInputStringTest()
        {
            paper.Text = "length of 12";
            int stringLength = paper.Text.Length;
            Assert.AreEqual(stringLength,pencil.Edit(paper, "of", "is").Length);
        }
    }
}
