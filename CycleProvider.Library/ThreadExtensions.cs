using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CycleProvider.Library
{
    public static class ThreadExtensions
    {
        private static string Sleep(this int milliseconds, bool withLog = false)
        {
            string returnValue;
            var start = DateTime.Now;
            Thread.Sleep(milliseconds);
            returnValue = $"Slept: {start: hh:mm:ss:ms} to {DateTime.Now: hh:mm:ss:ms}";
            if (withLog) Console.WriteLine(returnValue);

            return returnValue;
        }
        //słowa zabronione używamy z małpką, małpka oznacza też ścieżkę, metoda generyczna w <>gdzie określamy jaki typ
        public static string Sleep<TStrct>(this TStrct @struct, bool withLog = false, Action action = null) where TStrct : struct
        {
            if (action != null) Task.Run(action); //wywołanie asynchronicznie metodę

            int ms = 0;
            if (@struct is int || @struct is decimal)
            {
                ms = Convert.ToInt32(@struct);
            }
            return Sleep(ms, withLog);
        }
    }
}
