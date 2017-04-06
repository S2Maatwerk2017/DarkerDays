using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    public class Dialog
    {
        public List<string> Lines { get; private set; }

        public Dialog(List<string> lines )
        {
            Lines = lines;
        }
    }
}
