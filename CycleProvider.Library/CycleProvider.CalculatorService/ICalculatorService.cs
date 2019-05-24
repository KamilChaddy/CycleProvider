using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CycleProvider.CalculatorService
{
    public enum Operation { Add = 1, Sub = 2,}
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ICalculatorService
    {
        [OperationContract]
        Calculation Add(decimal left, decimal right);
        [OperationContract]
        Calculation Sub(decimal left, decimal right);
        // TODO: Add your service operations here
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "CycleProvider.CalculatorService.ContractType".
    [DataContract]
    public class Calculation
    {
        [DataMember]
        public decimal LeftOperand { get; set;}
        [DataMember]
        public decimal RightOperand { get; set; }
        [DataMember]
        public decimal Result { get; set; }
        [DataMember]
        public Operation Operation { get; set; }
    }
}
