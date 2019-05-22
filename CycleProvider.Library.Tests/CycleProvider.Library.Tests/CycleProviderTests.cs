using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CycleProvider.Library.Tests
{
    [TestClass]
    public class CycleProviderTests
    {
        [TestMethod]
        public void Next_LastElement_ReturnsFerstElement()
        {
            var cycleProvider = new CycleProvider<string>();
            cycleProvider.Add("First Item");
            cycleProvider.Add("Second Item");
            cycleProvider.Add("Third Item");

            cycleProvider.Next();
            cycleProvider.Next();
            cycleProvider.Next();
            object actual = cycleProvider.Next();

            Assert.AreEqual("First Item", actual);
        }
        [TestMethod]
        public void Next_FirstUse_ReturnsFerstElement()
        {
            var cycleProvider = new CycleProvider<string>();
            cycleProvider.Add("First Item");

            object actual = cycleProvider.Next();

            Assert.AreEqual("First Item", actual);
        }
        [TestMethod]
        public void Next_ThreeUse_ReturnsFerstElement()
        {
            var cycleProvider = new CycleProvider<string>();
            cycleProvider.Add("First Item");
            cycleProvider.Add("Second Item");
            cycleProvider.Add("Third Item");

            cycleProvider.Next();
            cycleProvider.Next();
            object actual = cycleProvider.Next();

            Assert.AreEqual("Third Item", actual);
        }
        [TestMethod]
        public void Next_NoItems_ThrowException()
        {
            var cycleProvider = new CycleProvider<int>();
            var actual = Assert.ThrowsException<InvalidOperationException>(() => cycleProvider.Next());
            Assert.AreEqual("Cycle provider has no item", actual.Message);
        }
        [TestMethod]
        public void Next_LastItem_EventOnLastItemFire()
        {
            const string lastItem = "Last Item";
            var wasInvoke = false;
            var cycleProvider = new CycleProvider<string>();
            cycleProvider.Add("First Item");
            cycleProvider.Add(lastItem);
            cycleProvider.OnLastItem += (s, a) =>
            {
                wasInvoke = true;
                Assert.AreEqual(cycleProvider, s);
                Assert.AreEqual(lastItem, a.LastItem);
                Assert.AreEqual(2, a.TotalItems);
            };
            cycleProvider.Next();

            object actual = cycleProvider.Next();

            Assert.AreEqual(true, wasInvoke, "Event hednler was never invoked");
            Assert.AreEqual(lastItem, actual);
        }
    }
}
