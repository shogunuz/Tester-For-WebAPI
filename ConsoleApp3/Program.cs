using System;
using System.Collections.Generic;

namespace ConsoleApp3
{
    class Program
    {
        private static HolidaysCalc holidaysCalc = new HolidaysCalc();
        private static DateRecycle dateRecycle = new DateRecycle();
        private static Dictionary<int, Dictionary<string, string>> dictionary = new Dictionary<int, Dictionary<string, string>>();
        private static WorkerHoliday workerHoliday = new WorkerHoliday();
        static void Main(string[] args)
        {
            Console.WriteLine(holidaysCalc.HolidayCalc());
            Console.WriteLine("Все сотрудника из отпуска:\n" + "QA: " + holidaysCalc.qa + " Dev:" +
               holidaysCalc.dev + " TM:" + holidaysCalc.tm);
            // Console.WriteLine(holidaysCalc.HolidayCalc());
           // dictionary = dateRecycle.getDictOfH(dateRecycle.WorkerHolidaysGetRequest());
           // Console.WriteLine(dictionary[1]["FIO"]);
            //string str = (dictionary[1]["DateEnd"]);
            // str = str + ((dictionary[1]["DateStart"]).ToString());
            //Console.WriteLine(str);
            //DateTime parsedDateStart = DateTime.Parse("2020-06-11T12:39:38");
            //DateTime parsedDateEnd = DateTime.ParseExact(((dictionary[1]["DateEnd"]).ToString()), "MM/dd/yyyy HH:mm:ss",null);
            Console.ReadLine();
        }
        private void content()
        {
            workerHoliday.IdForH = 5;
            workerHoliday.PMId = 5;
            workerHoliday.FIO = "Figo Fbio";
            workerHoliday.Position = "QA";
            workerHoliday.DateStart = DateTime.Parse("2020-06-01T12:39:38");
            workerHoliday.DateEnd = DateTime.Parse("2020-06-11T12:39:38");
        }

    }
}
