using CycleProvider.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycleProvider.ConsolParallel
{
    class Program
    {
        static void Main()
        {
            var sim = "123456789";

            Console.WriteLine("-------------------------------------------\nParallel throad foreach");
            Parallel.ForEach(sim,c => Console.WriteLine(
                $"Request for item[{c}] | " +
                $"Response is: {GetFromOutsources(c)}"));

            Console.WriteLine("-------------------------------------------\nSingel throad foreach");

            SingelThreadForeach(sim);
            Console.ReadKey(true);

        }

        private static void SingelThreadForeach(string sim) //ctr r contr m - refaktoryzacja do metody
        {
            foreach (var item in sim)
            {
                Console.WriteLine( $"Request for item[{item}] | " + $"Response is: {GetFromOutsources(item)}");
            }
        }

        private static string GetFromOutsources(char item)
        {
            return 1000.Sleep();
        }

        
    }
}
