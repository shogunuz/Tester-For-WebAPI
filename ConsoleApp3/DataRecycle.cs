
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

        private int[] numberOfMonth = new int[365]; // 365
        public int numberOfWorkers { get; private set; } // 365
        private string workers { get; set; }
        Dictionary<int, Dictionary<string, string>> myDict = new Dictionary<int, Dictionary<string, string>>();
        //Item item = new Item();
        public string RecyclingDate(string str)
        {
            str = str.Remove(0, 4).Remove(12, 54).Remove(24);
            //string[] time = str.Split(' ').ToArray();
            /* time[0] - месяц, time[1] - день, time[2] - год
             * time[4] - month, time[5] - day, time[6] - year
              Sometmp = months(time[0].ToString()); // (String.Join(time[0]))
              time[0] = time[1];
              time[1] = Sometmp;
              time[2] = time[2].ToString() + " /";

              Sometmp = months(time[4].ToString()); // (String.Join(time[0]))
              time[4] = time[5];
              time[5] = Sometmp;
              */
            //str = string.Join(" ", time);
            return str.Trim();
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
        public Dictionary<int, Dictionary<string, string>> getDictOfH(string jsonInput)
        {
            Console.WriteLine(jsonInput +"\n\n");
            var objects = JsonConvert.DeserializeObject<List<object>>(jsonInput);
            var result = objects.Select(obj => JsonConvert.SerializeObject(obj)).ToArray();
            numberOfWorkers = result.Length;
            JObject jsonObj;
            for (int i=0; i< numberOfWorkers; i++)
            {
                jsonObj = JObject.Parse(result[i]);
                Dictionary<string, string> dictObj = jsonObj.ToObject<Dictionary<string, string>>();
                myDict.Add(i, new Dictionary<string, string>(dictObj));
            }

            return myDict;
        }

    }
}
