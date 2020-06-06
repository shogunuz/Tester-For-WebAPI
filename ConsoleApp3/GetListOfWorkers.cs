using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace ConsoleApp3
{
    // sealed - невозможно создать наследника для GetListOfWorkers
    sealed public class GetListOfWorkers 
    {
        public GetListOfWorkers()
        {
            NumberOfWorkers = 0;
        }
        private int numberOfWorkers;
        public int NumberOfWorkers
        {
            get { return numberOfWorkers; }
            set
            {
                numberOfWorkers = value;
            }
        }
        private Dictionary<int, Dictionary<string, string>> GetListOfHolidaysTew()
        {
            Dictionary<int, Dictionary<string, string>> dictionary = new Dictionary<int, Dictionary<string, string>>();
            WebRequest request = WebRequest.Create("https://localhost:44342/api/WorkerHolidays");
            using(WebResponse response = request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader streamReader = new StreamReader(stream))
            using (JsonTextReader reader = new JsonTextReader(streamReader))
            {
                reader.SupportMultipleContent = true;

                var serializer = new JsonSerializer();
                while (reader.Read())
                {
                    if (reader.TokenType == JsonToken.StartObject)
                    {
                        WorkerHoliday worker = serializer.Deserialize<WorkerHoliday>(reader);
                        dictionary.Add(NumberOfWorkers, new Dictionary<string, string>
                        {
                            ["PMId"] = (worker.PMId).ToString(),
                            ["IdForH"] = (worker.IdForH).ToString(),
                            ["FIO"] = (worker.FIO),
                            ["Position"] = (worker.Position),
                            ["DateStart"] = (worker.DateStart).ToString(),
                            ["DateEnd"] = (worker.DateEnd).ToString()
                        });
                        NumberOfWorkers++;
                    }
                }
            }
            request = null;
            return dictionary;
        }

        public Dictionary<int, Dictionary<string, string>> GetListOfHolidaysPublic()
        {
          return GetListOfHolidaysTew();
        }
    }
}
