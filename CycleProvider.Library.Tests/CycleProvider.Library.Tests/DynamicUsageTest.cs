using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CycleProvider.Library.Tests
{
    [TestClass]
    public class DynamicUsageTest
    {
        [TestMethod]
        public void DynamicObjectInjection_Demo()
        {
            LogFromDynamic(new Person("Dolas") { FirstName = "Franek " });
            LogFromDynamic(new PrivatePerson { LastName = "PrivatePerson", FirstName = "XXX " });
            LogFromDynamic(new PrivatePersonValueType { LastName = 123, FirstName = 989 });

            LogFromDynamic(new { FirstName = "Person ", LastName = new {AnyPropety = "dsadsdasda", OtherProperty = "dsadasdasd", } });
        }
        private static void LogFromDynamic(dynamic fullName)
        {
            Console.WriteLine($"FN: {fullName.FirstName}, LN: {fullName.LastName}");
        }
        private class PrivatePerson
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
        private class PrivatePersonValueType
        {
            public int FirstName { get; set; }
            public int LastName { get; set; }
        }
    }
}
