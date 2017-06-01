using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    public class Dialog
    {
        public List<DialogLine> Lines { get; private set; }

        public Dialog(List<DialogLine> lines )
        {
            Lines = lines;
        }
    }
}
