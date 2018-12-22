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

        [TestInitialize]
        public void Initialize()
        {
            paper = new Paper();
        }

        [TestMethod]
        public void PaperTextPropertyStartsAsNull()
        {
            Assert.AreEqual(null, paper.Text);

        }
    }
}
