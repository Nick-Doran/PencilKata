﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using PencilKata;
using System;
using System.Collections.Generic;
using System.Text;

namespace PencilKataTests
{
    [TestClass]
    public class PencilSharpenMethodTests
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
        public void PencilSharpenMethodReturnsPencilToMaxDurabilityWhenSharpenedTest()
        {
            pencil.RemainingDurability = 0;
            pencil.Sharpen();
            Assert.AreEqual(10, pencil.RemainingDurability);
        }
        [TestMethod]
        public void PencilSharpenMethodSubtractsOneFromPencilLengthWhenSharpenMethodIsCalledTest()
        {
            pencil.Sharpen();
            Assert.AreEqual(4, pencil.Length);
        }
    }
}
