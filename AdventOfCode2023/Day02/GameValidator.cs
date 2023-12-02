using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day02
{
    internal static class GameValidator
    {

        public static bool IsValid(Game game, Set bagConfiguration)
        {
            foreach (var playedSet in game.Sets)
            { 
                if(playedSet.Reds > bagConfiguration.Reds ||
                    playedSet.Greens > bagConfiguration.Greens ||
                    playedSet.Blues > bagConfiguration.Blues)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
