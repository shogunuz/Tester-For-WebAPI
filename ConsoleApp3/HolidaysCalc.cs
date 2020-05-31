using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
    class HolidaysCalc
    {
        private  DateRecycle dateRecycle = new DateRecycle();
        private  Dictionary<int, Dictionary<string, string>> dictionary = new Dictionary<int, Dictionary<string, string>>();
        public bool HolidayCalc()
        {
            bool res = false;
            dictionary = dateRecycle.getDictOfH(dateRecycle.WorkerHolidaysGetRequest());

            Console.WriteLine(dictionary[0]["Date"]);
            Console.ReadLine();

            private string months(string month)
            {
                switch (month)
                {
                    case "Jan":
                        month = "01";
                        for (int i = 1; i <= 31; i++)
                        {
                            numberOfMonth[i] = i;
                        }
                        break;
                    case "Feb":
                        month = "02";
                        break;
                    case "Mar":
                        month = "03";
                        break;
                    case "Apr":
                        month = "04";
                        break;
                    case "May":
                        month = "05";
                        break;
                    case "Jun":
                        month = "06";
                        break;
                    case "Jul":
                        month = "07";
                        break;
                    case "Aug":
                        month = "08";
                        break;
                    case "Sep":
                        month = "09";
                        break;
                    case "Oct":
                        month = "10";
                        break;
                    case "Nov":
                        month = "11";
                        break;
                    case "Dec":
                        month = "12";
                        break;
                    default:
                        break;
                }
                return month;
            }
            return res;
        }
        private string months(string month)
        {
            switch (month)
            {
                case "Jan":
                    month = "01";
                    for (int i = 1; i <= 31; i++)
                    {
                        numberOfMonth[i] = i;
                    }
                    break;
                case "Feb":
                    month = "02";
                    break;
                case "Mar":
                    month = "03";
                    break;
                case "Apr":
                    month = "04";
                    break;
                case "May":
                    month = "05";
                    break;
                case "Jun":
                    month = "06";
                    break;
                case "Jul":
                    month = "07";
                    break;
                case "Aug":
                    month = "08";
                    break;
                case "Sep":
                    month = "09";
                    break;
                case "Oct":
                    month = "10";
                    break;
                case "Nov":
                    month = "11";
                    break;
                case "Dec":
                    month = "12";
                    break;
                default:
                    break;
            }
            return month;
        }

    }
}
