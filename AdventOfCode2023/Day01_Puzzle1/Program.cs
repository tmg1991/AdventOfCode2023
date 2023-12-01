// See https://aka.ms/new-console-template for more information

var inputPath = "input.txt";
string[] lines = File.ReadAllLines(inputPath);

int sumOfCalibrationValues = 0;

foreach (string line in lines)
{
    var characterLine = line.ToCharArray();
    if (!characterLine.Any(_ => Char.IsDigit(_)))
    {
        continue;
    }
    var firstDigitChar = characterLine.First(_ => Char.IsDigit(_));
    int firstDigit = int.Parse(firstDigitChar.ToString());
    var lastDigitChar = characterLine.Last(_ => Char.IsDigit(_));
    int lastDigit = int.Parse(lastDigitChar.ToString());

    string combinedChars = $"{firstDigitChar}{lastDigitChar}";

    var combinecNumber = int.Parse(combinedChars);

    sumOfCalibrationValues += combinecNumber;


}

Console.WriteLine(sumOfCalibrationValues);
