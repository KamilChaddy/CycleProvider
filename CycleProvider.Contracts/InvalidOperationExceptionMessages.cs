using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycleProvider.Contracts
{
    public static class InvalidOperationExceptionMessages
    {
        public static readonly string EmptyCycleProviderList = "Cycle provider has no item";
        public static readonly string BagIsNotEmpty = "Invalid operation. Bag is not empty";
        public static readonly string BagIsEmpty = "Invalid operation. Bag is empty";
    }
}
