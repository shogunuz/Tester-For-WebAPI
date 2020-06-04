﻿using System;
using System.Collections.Generic;

namespace ConsoleApp3
{
    public class DateRecycle
    {
        
        
        private int NumberOfWorkers;

        private NumbersOfPositions numOfWorkers = new NumbersOfPositions();

        private readonly GetListOfWorkers getListOfWorkers = new GetListOfWorkers();
        private Dictionary<int, Dictionary<string, string>> dictionary = new Dictionary<int, Dictionary<string, string>>();

        private WorkerHoliday workerHoliday = new WorkerHoliday();
        private void content()
        {
            workerHoliday.IdForH = 5;
            workerHoliday.PMId = 5;
            workerHoliday.FIO = "Figo Fbio";
            workerHoliday.Position = "QA";
            workerHoliday.DateStart = DateTime.Parse("2020-06-01T12:39:38");
            workerHoliday.DateEnd = DateTime.Parse("2020-06-11T12:39:38");
        }
        private void Schetchik(string position)
        {
            switch (position)
            {
                case "QA":
                    numOfWorkers.QA++;
                    break;
                case "Developer":
                    numOfWorkers.Dev++;
                    break;
                case "TeamLead":
                    numOfWorkers.TL++;
                    break;
                default: break;
            }
        }
        private void CountingWorkers(WorkerHoliday workerHoliday)
        {
            for (int i = 0; i < NumberOfWorkers; i++)
            {
                 Int32.TryParse((dictionary[i]["PMId"]), out int cnt);
                //DateTime parsedDateStart = DateTime.ParseExact(dictionary[i]["DateStart"], "MM/dd/yyyy HH:mm:ss", null);
                DateTime parsedDateStart = DateTime.Parse(dictionary[i]["DateStart"]);
                //DateTime parsedDateEnd = DateTime.ParseExact(dictionary[i]["DateEnd"], "MM/dd/yyyy HH:mm:ss", null);
                DateTime parsedDateEnd = DateTime.Parse(dictionary[i]["DateEnd"]);
                if ((parsedDateStart <= workerHoliday.DateStart && workerHoliday.DateStart <= parsedDateEnd)
                   || (parsedDateStart <= workerHoliday.DateEnd && workerHoliday.DateEnd <= parsedDateEnd))
                {
                    /*
                     * Каждый раз включаю счётчик чтобы в итоге знать сколько всего сотрудников
                     * отправлено на отпуск в том периоде, в который собираемся добавить текущего(нового)
                     * сотрудника.
                     */
                    Schetchik(dictionary[i]["Position"]);

                    //Проверяем добавили ли сотрудника, которого уже отправили в отпуск в этом периоде
                    if (cnt == workerHoliday.PMId)
                        numOfWorkers.Selfself++;
                }
                else if ((workerHoliday.DateStart <= parsedDateStart && parsedDateStart <= workerHoliday.DateEnd)
                 || (workerHoliday.DateStart <= parsedDateEnd && parsedDateEnd <= workerHoliday.DateEnd))
                {
                    Schetchik(dictionary[i]["Position"]);
                    if (cnt == workerHoliday.PMId)
                        numOfWorkers.Selfself++;
                }
            }
        }
        private bool Proverka(WorkerHoliday worker)
        {
            bool res = false;
            switch (worker.Position)
            {
                case "QA":
                    CountingWorkers(worker);
                    if (numOfWorkers.Dev == 0 && numOfWorkers.Selfself == 0)
                    {
                        if (numOfWorkers.QA < 3)
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
                        if (numOfWorkers.QA < 1)
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
                    CountingWorkers(worker);
                    if (numOfWorkers.TL == 0 && numOfWorkers.Selfself == 0)
                    {
                        if (numOfWorkers.QA < 2)
                        {
                            if (numOfWorkers.Dev < 2)
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
                            if (numOfWorkers.Dev == 0)
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
                    CountingWorkers(worker);
                    if (numOfWorkers.Dev == 0 && numOfWorkers.Selfself == 0)
                    {
                        if (numOfWorkers.TL < 1)
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

        public bool HolidayCalc()
        {
            bool res = false;
            try
            {
                dictionary = getListOfWorkers.GetListOfHolidaysPublic();
                NumberOfWorkers = getListOfWorkers.NumberOfWorkers;
            }
            catch (Exception) { }
            content();
           if (Proverka(workerHoliday) == true)
            { res = true; }
            Console.WriteLine("Все сотрудника из отпуска:\n" + "QA: " + numOfWorkers.QA + " Dev:" +
                numOfWorkers.Dev + " TM:" + numOfWorkers.TL);
            return res;
        }

    }
}
