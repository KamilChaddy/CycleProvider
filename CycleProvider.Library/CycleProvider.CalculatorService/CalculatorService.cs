using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CycleProvider.CalculatorService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class CalculatorService : ICalculatorService
    {
        public Calculation Add(decimal left, decimal right)
        {
            return new Calculation
            {
                LeftOperand = left,
                RightOperand = right,
                Result = left + right,
                Operation = Operation.Add
            };
        }
        public Calculation Sub(decimal left, decimal right)
        {
            return new Calculation
            {
                LeftOperand = left,
                RightOperand = right,
                Result = left - right,
                Operation = Operation.Sub
            };
        }
    }
}
