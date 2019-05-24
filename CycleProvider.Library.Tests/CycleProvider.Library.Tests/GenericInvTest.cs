using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CycleProvider.Contracts;
using System.Linq;
using System.Collections.Generic;

namespace CycleProvider.Library.Tests
{
    [TestClass]
    public class GenericInvTest
    {
        private class Animal { public string Kind { get; set;  }}
        private class Tiger : Animal { public string Strips { get; set; }}

        [TestMethod]
        public void VariableParadigm()
        {
            var generic = new GenericInv<string>();
            
            DoWithObject("ok");
            DoWithObject(generic);
            //DoWithGenericOfObject(generic); //compile error nie można żutować z typu bardziej dopracowanego do ogólnego
            DoWithGenericInterfecaInOfObject(generic);
            DoWithGenericInterfecaOutOfObject(generic);
            "".Where(c => true);

            var table = new List<Tiger>();
            LinqQuery(table);
        }
        private void DoWithObject(object obj)
        {
        }
        private void DoWithGenericOfObject(GenericInv<object> genericInv) // tu jest generyk od obiektu a nie od stringa
        {
        }
        private IGenericInvIn<string> DoWithGenericInterfecaInOfObject(IGenericInvIn<string> genericInv)
        {
            genericInv.Put("abcdef");
            return genericInv;
        }
        private void DoWithGenericInterfecaOutOfObject(IGenericInvOut<object> genericInv)
        {
            var anything = genericInv.Get();
        }
        private void LinqQuery(IEnumerable<Animal> table) //Ienumerable pozwala na dziedziczenie obiektów z typu przadziej sprecyzowanego do ugulniejszego Animal v. Tiger
        {
            table.FirstOrDefault(a => a.Kind == "Predator");
        }
    }
}
