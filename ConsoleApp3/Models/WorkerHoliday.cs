using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
    class WorkerHoliday
    {
        private int IdH;
        private int Id;
        private string Fio;
        private string position;
        private DateTime startDate;
        private DateTime endDate;

        public int IdForH { get => IdH; set => IdH = value; }
        public int PMId { get => Id; set => Id = value; }
        public string FIO { get => Fio; set => Fio = value; }
        public string Position { get => position; set => position = value; }
        public DateTime DateStart { get => startDate; set => startDate = value; }
        public DateTime DateEnd { get => endDate; set => endDate = value; }
    }
}
