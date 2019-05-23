using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CycleProvider.Library;

namespace CycleProvider.ConsolParallel
{
    internal class DALSimulator<T> : CycleProvider<T>
    {
        /*
        public IEnumerator<T> GetEnumerator()
        {
            return new NotImplementedException();
        }
        public override T Next()    //korzystając z bazowego next modyfikujemy go aby odpowiedział z opuxnieniem - 
                                    //odpowiednik laga w transmisji danych
        {
            2000.Sleep(true);
            return base.Next();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }*/
    }
}
