using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day02
{
    internal class Game
    {
        public int ID { get; set; }
        public List<Set> Sets { get; set; } = new();

        public Game(int iD, List<Set> sets)
        {
            ID = iD;
            Sets = sets;
        }


    }
}
