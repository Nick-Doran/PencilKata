﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        public void PencilEditMethodRemovesAStringFromtheTextPropertyOfParameterPaperTest()
        {
            paper.Text = "text";
            pencil.Edit(paper, "text");
            Assert.AreEqual("    ", paper.Text);
        }
        [TestMethod]
        public void PencilEditMethodFindsTheLastInstanceOfTheSpecifiedStringTest()
        {
            paper.Text = "text text";
            pencil.Edit(paper, "text");
            Assert.AreEqual("text     ", paper.Text);
        }
        [TestMethod]
        public void PencilEditMethodCanEditMulitpleOccurencesOfTheSameTextTest()
        {
            paper.Text = "text text";
            pencil.Edit(paper, "text");
            Assert.AreEqual("text     ", paper.Text);
            pencil.Edit(paper, "text");
            Assert.AreEqual("         ", paper.Text);
        }
        [TestMethod]
        public void PencilEditMethodDoesNotEditTextIfTextDoesNotContainTheTextToEditParameterItWasPassed()
        {
            paper.Text = ("text text");
            Assert.AreEqual("text text", pencil.Edit(paper, "test"));
        }
        [TestMethod]
        public void PencilEditMethodRemovesTextToEditMatchesWhenTheyAreNestedInAnotherWordTest()
        {
            paper.Text = "test oneone test";
            Assert.AreEqual("test one    test", pencil.Edit(paper, "one"));
        }
    }
}
