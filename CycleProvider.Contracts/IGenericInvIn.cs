using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CycleProvider.Contracts;

namespace CycleProvider.Contracts
{
    public interface IGenericInvIn<in T> // modyfikacje elementu
    {
        void Put(T item);
    }
}
