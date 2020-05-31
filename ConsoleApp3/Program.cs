using System;
using System.Collections.Generic;

namespace ConsoleApp3
{
    class Program
    {
        private static HolidaysCalc holidaysCalc = new HolidaysCalc();
        static void Main(string[] args)
        {
            Console.WriteLine(holidaysCalc.HolidayCalc());
            Console.ReadLine();
        }
        private void Result()
        {

        }
    }
}
