using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CycleProvider.Contracts;

namespace CycleProvider.Library.Tests
{
    [TestClass]
    public class OneItemBagTest
    {
        [TestMethod]
        public void Put_OneItemBagIsNotEmpty_ThrowsException()
        {
            var bag = new OneItemBag<object>();
            bag.Put(new object());

            var actual = Assert.ThrowsException<OneItemBagException>(() => bag.Put(null));

            Assert.AreEqual("Invalid operation. Bag is not empty", actual.Message);
        }

        [TestMethod]
        public void Get_OneItemBagIsNotEmpty_ThrowsException()
        {
            var bag = new OneItemBag<object>();

            var actual = Assert.ThrowsException<OneItemBagException>(() => bag.Get());

            Assert.AreEqual("Invalid operation. Bag is empty", actual.Message);
        }

        [TestMethod]
        public void Get_OneItemBagIsEmptyAfterPullAndGet_ThrowsException()
        {
            var bag = new OneItemBag<string>();
            bag.Put("1");
            bag.Get();

            var actual = Assert.ThrowsException<OneItemBagException>(() => bag.Get());

            Assert.AreEqual("Invalid operation. Bag is empty", actual.Message);
        }

        [TestMethod]
        public void Get_OneItemBagHasAnItem_ThrowsException()
        {
            var bag = new OneItemBag<TestItem>();
            bag.Put(new TestItem { Id = 666, Name = "TT", Description ="1212"});
            TestItem actual = bag.Get();

            Assert.AreEqual(666, actual.Id);
            Assert.AreEqual("TT", actual.Name);
            Assert.AreEqual("1212", actual.Description);
        }
        private class TestItem
        {
            public int Id;
            public string Name;
            public string Description;

        }
    }
}
