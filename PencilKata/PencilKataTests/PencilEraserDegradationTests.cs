using Microsoft.VisualStudio.TestTools.UnitTesting;
using PencilKata;
using System;
using System.Collections.Generic;
using System.Text;

namespace PencilKataTests
{
    [TestClass]
    public class PencilEraserDegradationTests
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
        public void PencilEditMethodDoesNotAlterPaperTextPropertyWhenRemainingEraserIsZeroTest()
        {
            paper.Text = "test";
            pencil.RemainingEraser = 0;
            pencil.Erase(paper, "test");
            Assert.AreEqual("test", paper.Text);
        }
        [TestMethod]
        public void PencilEditMethodWillStopErasingFromPaperTextPropertyWhenTheRemainingEraserOfThePencilReachesZeroTest()
        {
            paper.Text = "a firetruck";
            pencil.RemainingEraser = 5;
            pencil.Erase(paper, "firetruck");
            Assert.AreEqual("a fire     ", paper.Text);
        }
    }
}
