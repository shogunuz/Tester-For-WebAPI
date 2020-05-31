using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;

namespace ConsoleApp3
{
    class HolidaysCalc
    {
        private int[] holidaysForQA { get; set; } = new int[366];
        private int[] holidaysForDev { get; set; } = new int[366];
        private int[] holidaysForTm { get; set; } = new int[366];
        public int qa { get; private set; }
        public int dev { get; private set; }
        public int tm { get; private set; }
        string names;
        WorkerHoliday workerHoliday = new WorkerHoliday();
        DateRange dateRange; //= new DateRange();
        private void content() { 
            workerHoliday.IdForH = 5;
            workerHoliday.PMId = 5;
            workerHoliday.FIO = "Figo Fbio";
            workerHoliday.Position = "QA";
            workerHoliday.DateStart = DateTime.Parse("2020-06-01T12:39:38");
            workerHoliday.DateEnd = DateTime.Parse("2020-06-11T12:39:38");
        }
        private  DateRecycle dateRecycle = new DateRecycle();
        private  Dictionary<int, Dictionary<string, string>> dictionary = new Dictionary<int, Dictionary<string, string>>();
        public bool HolidayCalc()
        {
            bool res = false;
            dictionary = dateRecycle.getDictOfH(dateRecycle.WorkerHolidaysGetRequest());
            content();
           
            if(psevd(workerHoliday))
            {
                Console.WriteLine("psved returned TRUE");
                Console.WriteLine("NAMES: "+names);
                res = true; }
            else { res = false; }
            
            return res;
        }
        private void schetchik(string position)
        {
            switch (position)
            {
                case "QA":
                    qa++;
                    break;
                case "Developer":
                    dev++;
                    break;
                case "TeamLead":
                    tm++;
                    break;
                default: break;
            }
        }
        private void countingWorkers()
        {
            for (int i = 0; i < dateRecycle.numberOfWorkers; i++)
            {
                DateTime parsedDateStart = DateTime.Parse(dictionary[i]["DateStart"]);
                DateTime parsedDateEnd = DateTime.ParseExact(((dictionary[i]["DateEnd"]).ToString()), "MM/dd/yyyy HH:mm:ss", null);

                if ((parsedDateStart <= workerHoliday.DateStart && workerHoliday.DateStart <= parsedDateEnd)
                   || (parsedDateStart <= workerHoliday.DateEnd && workerHoliday.DateEnd <= parsedDateEnd))
                {
                    schetchik(dictionary[i]["Position"]);
                }
            }
        }
       private bool psevd(WorkerHoliday woker)
        {
            bool res = false;
            switch (woker.Position)
            {
                case "QA":
                    countingWorkers();
                    if (dev < 1)
                    {
                        if (qa < 4)
                        {
                            res = true;
                        }
                        else
                        {
                            res = false;
                        }
                    }
                    else
                    {
                        if (qa < 2)
                        {
                            res = true;
                        }
                        else
                        {
                            res = false;
                        }
                    }
                    break;
                case "Developer":

                    if (dev < 1)
                    {
                        if (qa < 4)
                        {
                            res = true;
                        }
                        else
                        {
                            res = false;
                        }
                    }
                    else
                    {
                        if (qa < 2)
                        {
                            res = true;
                        }
                        else
                        {
                            res = false;
                        }
                    }
                    break;
                case "TeamLead":

                    break;

                default: break;
            }
            
            return res;
        }
        

    }
}
