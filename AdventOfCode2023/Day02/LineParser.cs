using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day02
{
    internal static class LineParser
    {
        public const string RED = "red";
        public const string GREEN = "green";
        public const string BLUE = "blue";
        public static Game ParseLine(string line)
        {
            var splits = line.Split(':');
            var idSplit = splits[0];
            var outcomeSplit = splits[1];
            var gameId = GetGameId(idSplit);
            var sets = GetSets(outcomeSplit);

            return new Game(gameId, sets);
        }

        private static int GetGameId(string idSplit)
        {
            var idString = idSplit.Split("Game ")[1];
            return int.Parse(idString);
        }

        private static List<Set> GetSets(string outcomeSplit)
        {
            var sets = new List<Set>();
            var setSplits = outcomeSplit.Split(";");
            foreach (var setSplit in setSplits)
            {
                int reds = 0;
                int greens = 0;
                int blues = 0;

                var colors = setSplit.Split(',');
                foreach (var color in colors)
                {
                    if (color.Contains(RED))
                    {
                        reds += GetNumberToColor(color, RED);
                    }
                    if (color.Contains(GREEN))
                    {
                        greens += GetNumberToColor(color, GREEN);
                    }
                    if (color.Contains(BLUE))
                    {
                        blues += GetNumberToColor(color, BLUE);
                    }
                }

                sets.Add(new Set(reds, greens, blues));
            }

            return sets;
        }

        private static int GetNumberToColor(string colorString, string targetColor)
        {
            var splits = colorString.Split($" {targetColor}");
            return int.Parse(splits[0]);
        }
    }
}
