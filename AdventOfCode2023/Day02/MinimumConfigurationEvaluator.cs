using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day02
{
    internal class MinimumConfigurationEvaluator
    {
        public static Set MinimumConfiguration(Game game)
        {
            int minimumReds = int.MinValue;
            int minimumGreens = int.MinValue;
            int minimumBlues = int.MinValue;

            foreach (var set in game.Sets)
            {
                minimumReds = set.Reds > minimumReds ? set.Reds : minimumReds;
                minimumGreens = set.Greens > minimumGreens ? set.Greens : minimumGreens;
                minimumBlues = set.Blues > minimumBlues ? set.Blues : minimumBlues;
            }

            return new Set(minimumReds, minimumGreens, minimumBlues);
        }
    }
}
