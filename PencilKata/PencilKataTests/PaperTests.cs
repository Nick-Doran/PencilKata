using Microsoft.VisualStudio.TestTools.UnitTesting;
using PencilKata;
using System;
using System.Collections.Generic;
using System.Text;

namespace PencilKataTests
{
    [TestClass]
    public class PaperTests
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
        public void PaperTextPropertyStartsAsNullTest()
        {
            Assert.AreEqual(null, paper.Text);
        }

        [TestMethod]
        public void PaperTextPropertyHoldsTextPassedToItTest()
        {
            Assert.AreEqual(pencil.Write("1", paper, out int characterCount),paper.Text);
        }

        [TestMethod]
        public void PaperTextPropertyHoldsTextFromMulitipleWrites()
        {
            Assert.AreEqual(pencil.Write("1", paper, out int characterCount), paper.Text);
            pencil.Write("2", paper, out characterCount);
            Assert.AreEqual("12", paper.Text);
        }
    }
}
