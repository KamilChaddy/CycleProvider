using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CycleProvider.Contracts;

namespace CycleProvider.Library.Tests
{
    [TestClass]
    public class ICycleProviderTests
    {

        private class FakeCycyleProvider<T> : ICycleProvider<T>
        {
            private T _item;

            public T CurrentItem => _item;

#pragma warning disable CS0067
            public event Action<object, CycleProviderEventArgs> OnLastItem;
#pragma warning restore CS0067

            public void Add(T item)
            {
                _item = item;
            }
            T ICycleProvider<T>.Next()
            {
                return _item;
            }
            public void AdditionalMethodOutsideOfIntefaceDefinition() { }
        }

        [TestMethod]
        public void TDD_PreTestPreparation_Demo()
        {
            FakeCycyleProvider<int> outsidecycleprovider = new FakeCycyleProvider<int>();
            outsidecycleprovider.AdditionalMethodOutsideOfIntefaceDefinition();

            ICycleProvider<int> cycleProvider = new FakeCycyleProvider<int>();
            cycleProvider.Add(10);
            var actual = cycleProvider.Next();

            Assert.AreEqual(10, actual);
        }
    }
}
