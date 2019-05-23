using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CycleProvider.Library.Tests
{
    [TestClass]
    public class ThreadExtensionTest
    {
        [TestMethod]
        public void Sleep_Demo()
        {
            ThreadExtensions.Sleep(1, true);
            500.Sleep(true);
            750.Sleep(true);
            1000.Sleep(true);

            ThreadExtensions.Sleep(500, true, 
                () => Console.WriteLine($"This method is assync: {2000.Sleep(true)}"));

            500.Sleep(true);

            Console.WriteLine($"Returned: {1000.Sleep(true)}");
        }
    }
}
