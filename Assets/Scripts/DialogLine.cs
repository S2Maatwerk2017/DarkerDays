using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    public class DialogLine
    {
        public string Line { get; private set; }
        public bool HasOptions { get; private set; }
        public bool IsCorrectOption { get; private set; }
        public int GoldToPay { get; private set; }

        public DialogLine(string line,bool hasOptions,bool isCorrectOption,int goldToPay = 0)
        {
            Line = line;
            HasOptions = hasOptions;
            IsCorrectOption = isCorrectOption;
            GoldToPay = goldToPay;
        }
    }
}
