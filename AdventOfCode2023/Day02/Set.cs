using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day02
{
    internal class Set
    {
        public int Reds { get; set; }
        public int Greens { get; set; }
        public int Blues { get; set; }

        public Set(int reds, int greens, int blues)
        {
            Reds = reds;
            Greens = greens;
            Blues = blues;
        }
    }
}
