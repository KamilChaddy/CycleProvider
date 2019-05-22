using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CycleProvider.Contracts;

namespace CycleProvider.Library.Tests
{
    [TestClass]
    public class ICycleProviderTests
    {

        private class FakeCycyleProvider : ICycleProvider
        {
            public event Action<object, CycleProviderEventArgs> OnLastItem;
            public void Add(object item)
            {
                throw new NotImplementedException();
            }
            public object Next()
            {
                return 10;
            }
            public void AdditionalMethodOutsideOfIntefaceDefinition() { }
        }

        public ICycleProviderTests()
        {
           var _cycleProvider = new FakeCycyleProvider();
        }

        [TestMethod]
        public void TDD_PreTestPreparation_Demo()
        {
            var outsidecycleprovider = new FakeCycyleProvider();
            outsidecycleprovider.AdditionalMethodOutsideOfIntefaceDefinition();
            var cycleProvider = new FakeCycyleProvider();

            var actual = cycleProvider.Next();
            Assert.AreEqual(10, actual);
        }
    }
}
