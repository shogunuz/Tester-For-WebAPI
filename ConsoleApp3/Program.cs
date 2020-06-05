using System;
using System.Collections.Generic;

namespace ConsoleApp3
{
    class Program
    {
        private static DateRecycle dateRecycle = new DateRecycle();

        static void Main(string[] args)
        {
            Console.WriteLine(dateRecycle.HolidayCalc());
            
            Console.ReadLine();
        }
    }
}
