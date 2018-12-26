using Microsoft.VisualStudio.TestTools.UnitTesting;
using PencilKata;
using System;
using System.Collections.Generic;
using System.Text;

namespace PencilKataTests
{
    [TestClass]
    public class PencilEditTests
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
            Assert.AreEqual("This is a      string", pencil.Edit(paper, "test", ""));
        }
    }
}
