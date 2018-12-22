using Microsoft.VisualStudio.TestTools.UnitTesting;
using PencilKata;

namespace PencilKataTests
{
    [TestClass]
    public class PencilWriteTests
    {
        Pencil pencil;

        [TestInitialize]
        public void Initialize()
        {
            pencil = new Pencil();
           
        }
        [TestMethod]
        public void PencilWriteMethodReturnsAString()
        {
            Assert.AreEqual("", pencil.Write(""));
        }
    }
}
