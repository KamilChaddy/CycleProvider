using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CycleProvider.Library.Tests
{
    [TestClass]
    public class DbProviderMockTest
    {
        [TestMethod]
        public void Destructor_Invoking_Demo()
        {
            ConstructAndFreeUpReference();
            //ConstructAndFreeUpReferenceWithUsing();
            // GC.Collect(); //nie zaleca się bo wymusza na GC przesuwanie referencji na którkich obiektach, co jest niekorzystne
            //ConstructAndFreeUpReferencButDevISPlanningWithGC();
            GC.Collect();
            GC.WaitForPendingFinalizers();

            3000.Sleep(true);
        }

        public static void ConstructAndFreeUpReference()
        {
            new DbPrividerMock("Green, green ... I pink up the phone and I say yellow.");
        }
        public static void ConstructAndFreeUpReferenceWithUsing()
        {
            using (var db = new DbPrividerMock())
            {
                db.ToString();
            } // ni ema błedu bo jest uzyta klasa IDISPOSABLE using tworzy niejawnie fakt ze bedzie odwołanie do klasy z której dziedziczy DIsposabel
        }
        public static void ConstructAndFreeUpReferencButDevISPlanningWithGC()
        {
            var db = new DbPrividerMock();
            db.Dispose();
            GC.ReRegisterForFinalize(db);
        }
    }
}
