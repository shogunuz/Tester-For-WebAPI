﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
    class NumbersOfPositions
    {
        private int _qa;
        private int _dev;
        private int _tl;
        private int _selfself;
        public int QA
        {
            get => _qa; 
            set => _qa = value;
        }
        public int Dev
        {
            get => _dev;
            set => _dev = value;
        }
        public int TL
        {
            get => _tl;
            set => _tl = value;
        }
        public int Selfself
        {
            get => _selfself;
            set => _selfself = value;
        }
        public NumbersOfPositions():this(0,0,0,0){ }
        public NumbersOfPositions(int numbersOfQA, int numbersOfDev, int numbersOfTL, int selfelf)
        {
            QA = numbersOfQA;
            Dev = numbersOfDev;
            TL = numbersOfTL;
            Selfself = selfelf;
        }
    }
}
