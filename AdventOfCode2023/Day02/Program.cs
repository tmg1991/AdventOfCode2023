// See https://aka.ms/new-console-template for more information

using Day02;

var inputPath = "puzzleInput.txt";
string[] lines = File.ReadAllLines(inputPath);

var games = new List<Game>();
var bagConfiguration = new Set(12, 13, 14);

foreach (var line in lines)
{
    var game = LineParser.ParseLine(line);
    games.Add(game);
}

var validIDsSum = games.Where(game => GameValidator.IsValid(game, bagConfiguration)).Sum(game => game.ID);

var powerSum = 0;

foreach (var game in games)
{
    var minimumSet = MinimumConfigurationEvaluator.MinimumConfiguration(game);
    powerSum += (minimumSet.Reds * minimumSet.Greens * minimumSet.Blues);
}
Console.WriteLine(validIDsSum);
Console.WriteLine(powerSum);
