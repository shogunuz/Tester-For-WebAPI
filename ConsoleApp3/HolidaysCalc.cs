using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;

namespace ConsoleApp3
{
    class HolidaysCalc
    {
        public int qa { get; private set; }
        public int dev { get; private set; }
        public int tm { get; private set; }
        WorkerHoliday workerHoliday = new WorkerHoliday();
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
           // dictionary = getDictOfH(WorkerHolidaysGetRequest());
            content();
           
            if(psevd(workerHoliday))
            {  res = true; }
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
            for (int i = 0; i < dateRecycle.NumberOfWorkers; i++)
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
                    countingWorkers();
                    if (tm < 1)
                    {
                        if (qa < 2)
                        {
                           if(dev < 3)
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
                            if(dev < 1)
                            {
                                res = true;
                            }
                            else
                            {
                                res = false;
                            }
                        }
                    }
                    else
                    {
                        res = false;
                    }
                    break;
                case "TeamLead":
                    countingWorkers();
                    if (dev < 1)
                    {
                        if (tm < 2)
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
                        res = false;
                    }
                    break;
                default: break;
            }
            
            return res;
        }
        

    }
}
