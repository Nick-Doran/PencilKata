using Microsoft.VisualStudio.TestTools.UnitTesting;
using PencilKata;
using System;
using System.Collections.Generic;
using System.Text;

namespace PencilKataTests
{
    [TestClass]
    public class PencilEraseMethodTests
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
        public void PencilEraseMethodRemovesAStringFromtheTextPropertyOfParameterPaperTest()
        {
            paper.Text = "text";
            pencil.Erase(paper, "text", out int startIndex);
            Assert.AreEqual("    ", paper.Text);
        }
        [TestMethod]
        public void PencilEraseMethodFindsTheLastInstanceOfTheSpecifiedStringTest()
        {
            paper.Text = "text text";
            pencil.Erase(paper, "text", out int startIndex);
            Assert.AreEqual("text     ", paper.Text);
        }
        [TestMethod]
        public void PencilEraseMethodCanEditMulitpleOccurencesOfTheSameTextTest()
        {
            paper.Text = "text text";
            pencil.Erase(paper, "text", out int startIndex);
            Assert.AreEqual("text     ", paper.Text);
            pencil.Erase(paper, "text", out startIndex);
            Assert.AreEqual("         ", paper.Text);
        }
        [TestMethod]
        public void PencilEraseMethodDoesNotEditTextIfTextDoesNotContainTheTextToEditParameterItWasPassed()
        {
            paper.Text = ("text text");
            Assert.AreEqual("text text", pencil.Erase(paper, "test", out int startIndex));
        }
        [TestMethod]
        public void PencilEraseMethodRemovesTextToEditMatchesWhenTheyAreNestedInAnotherWordTest()
        {
            paper.Text = "test oneone test";
            Assert.AreEqual("test one    test", pencil.Erase(paper, "one", out int startIndex));
        }
    }
}
