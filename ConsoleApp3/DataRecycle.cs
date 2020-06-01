
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace ConsoleApp3
{
    public class DateRecycle
    {
        public int qa { get; private set; }
        public int dev { get; private set; }
        public int tm { get; private set; }
        public int numberOfWorkers { get; private set; } // 365
        private string workers { get; set; }
        public int selfself { get; private set; } = 0;
        public int idNumber { get; private set; }

        private Dictionary<int, Dictionary<string, string>> dictionary = new Dictionary<int, Dictionary<string, string>>();

        WorkerHoliday workerHoliday = new WorkerHoliday();
        private void content()
        {
            workerHoliday.IdForH = 5;
            workerHoliday.PMId = 5;
            workerHoliday.FIO = "Figo Fbio";
            workerHoliday.Position = "QA";
            workerHoliday.DateStart = DateTime.Parse("2020-06-01T12:39:38");
            workerHoliday.DateEnd = DateTime.Parse("2020-06-11T12:39:38");
        }

        public string WorkerHolidaysGetRequest()
        {
            WebRequest request = WebRequest.Create("https://localhost:44342/api/WorkerHolidays");
            WebResponse response = request.GetResponse();
            using (Stream dataStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();
                workers = responseFromServer;
            }
            response.Close();

            return workers;
        }
        private void getDictOfH(string jsonInput)
        {
            Console.WriteLine(jsonInput + "\n\n");
            var objects = JsonConvert.DeserializeObject<List<object>>(jsonInput);
            var result = objects.Select(obj => JsonConvert.SerializeObject(obj)).ToArray();
            numberOfWorkers = result.Length;
            JObject jsonObj;
            for (int i = 0; i < numberOfWorkers; i++)
            {
                jsonObj = JObject.Parse(result[i]);
                Dictionary<string, string> dictObj = jsonObj.ToObject<Dictionary<string, string>>();
                dictionary.Add(i, new Dictionary<string, string>(dictObj));
            }

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
        private void countingWorkers(WorkerHoliday workerHoliday)
        {
            for (int i = 0; i < numberOfWorkers; i++)
            {
                Int32.TryParse(dictionary[i]["PMId"], out int cnt);
                DateTime parsedDateStart = DateTime.ParseExact((dictionary[i]["DateStart"]).ToString(), "MM/dd/yyyy HH:mm:ss", null);
                DateTime parsedDateEnd = DateTime.ParseExact((dictionary[i]["DateEnd"]).ToString(), "MM/dd/yyyy HH:mm:ss", null);

                if ((parsedDateStart <= workerHoliday.DateStart && workerHoliday.DateStart <= parsedDateEnd)
                   || (parsedDateStart <= workerHoliday.DateEnd && workerHoliday.DateEnd <= parsedDateEnd))
                {
                    schetchik(dictionary[i]["Position"]);
                    if (cnt == workerHoliday.PMId)
                        selfself++;
                }
                else if ((workerHoliday.DateStart <= parsedDateStart && parsedDateStart <= workerHoliday.DateEnd)
                 || (workerHoliday.DateStart <= parsedDateEnd && parsedDateEnd <= workerHoliday.DateEnd))
                {
                    schetchik(dictionary[i]["Position"]);
                    if (cnt == workerHoliday.PMId)
                        selfself++;
                }
            }
        }
        private bool psevd(WorkerHoliday woker)
        {
            bool res = false;
            switch (woker.Position)
            {
                case "QA":
                    countingWorkers(woker);
                    if (dev == 0 && selfself == 0)
                    {
                        Console.WriteLine("QA   dev == 0 && selfself == 0\n");
                        if (qa < 3)
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
                        Console.WriteLine(" !!! dev == 0 && selfself == 0\n");
                        if (qa < 1)
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
                    countingWorkers(woker);
                    if (tm == 0 && selfself == 0)
                    {
                        Console.WriteLine(" DEV tm == 0 && selfself == 0\n");
                        if (qa < 2)
                        {
                            Console.WriteLine(" DEV  dev < 2\n");
                            if (dev < 2)
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
                            Console.WriteLine(" DEV !!!! dev < 2\n");
                            if (dev == 0)
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
                        Console.WriteLine(" DEV !!! tm == 0 && selfself == 0\n");
                        res = false;
                    }
                    break;
                case "TeamLead":
                    countingWorkers(woker);
                    if (dev == 0 && selfself == 0)
                    {
                        Console.WriteLine(" TL tm == 0 && selfself == 0\n");
                        if (tm < 1)
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
                        Console.WriteLine(" TL !!!! tm == 0 && selfself == 0\n");
                        res = false;
                    }
                    break;
                default: break;
            }
            return res;
        }

        public bool HolidayCalc()
        {
            bool res = false;
            getDictOfH(WorkerHolidaysGetRequest());
            content();
            if (psevd(workerHoliday))
            { res = true; }

            return res;
        }

    }
}
