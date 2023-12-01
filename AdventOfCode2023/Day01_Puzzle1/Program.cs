// See https://aka.ms/new-console-template for more information

using System.Linq;

var inputPath = "input.txt";
string[] lines = File.ReadAllLines(inputPath);

var spelledNumbers = new Dictionary<string, int>() { { "zero", 0},
{ "one", 1},
{ "two", 2},
{ "three", 3},
{ "four", 4},
{ "five", 5},
{ "six", 6},
{ "seven", 7},
{ "eight", 8},
{ "nine", 9}};

int sumOfCalibrationValues = 0;

foreach (string line in lines)
{
    int firstDigitCharIndex = int.MaxValue;
    int firstDigitSpelledIndex = int.MaxValue;
    int lastDigitCharIndex = int.MinValue;
    int lastDigitSpelledIndex = int.MinValue;

    var characterLine = line.ToCharArray();
    if (characterLine.Any(_ => Char.IsDigit(_)))
    {
        var firstDigitChar = characterLine.First(_ => Char.IsDigit(_));
        firstDigitCharIndex = Array.IndexOf(characterLine, firstDigitChar);

        var lastDigitChar = characterLine.Last(_ => Char.IsDigit(_));
        lastDigitCharIndex = Array.IndexOf(characterLine, lastDigitChar);
    }

    if (ContainsSpelledDigit(line))
    {
        firstDigitSpelledIndex = GetFirstSpelledIndex(line);
        lastDigitSpelledIndex = GetLastSpelledIndex(line);
    }

    var firstToParse = firstDigitCharIndex < firstDigitSpelledIndex ? firstDigitCharIndex : firstDigitSpelledIndex;
    int firstDigit = GetFirstDigit(firstDigitCharIndex, firstDigitSpelledIndex, line);
   
    var lastToParse = lastDigitCharIndex < lastDigitSpelledIndex ? lastDigitCharIndex : lastDigitSpelledIndex;
    int lastDigit = GetLastDigit(lastDigitCharIndex, lastDigitSpelledIndex, line);

    string combinedChars = $"{firstDigit}{lastDigit}";

    var combinedNumber = int.Parse(combinedChars);

    sumOfCalibrationValues += combinedNumber;


}

int GetFirstSpelledIndex(string line)
{
    var minIndex = int.MaxValue;

    foreach (var spelledNumber in spelledNumbers)
    {
        var number = spelledNumber.Key;
        if (line.Contains(spelledNumber.Key))
        {
            int start;
            start = line.IndexOf(number, StringComparison.Ordinal);
            minIndex = start < minIndex ? start : minIndex;
        }
    }

    return minIndex; 
}

int GetLastSpelledIndex(string line)
{
    var maxIndex = int.MinValue;
    foreach (var spelledNumber in spelledNumbers)
    {
        var number = spelledNumber.Key;
        if (line.Contains(spelledNumber.Key))
        {
            int start;
            start = line.IndexOf(number, 0);
            maxIndex = start > maxIndex ? start : maxIndex;
        }
    }

    return maxIndex;
}

int GetFirstDigit(int firstDigitCharIndex, int firstDigitSpelledIndex, string line)
{
    
    if(firstDigitCharIndex < firstDigitSpelledIndex)
    {
        var characterLine = line.ToCharArray();
        return int.Parse(characterLine[firstDigitCharIndex].ToString());
    }

    return GetSpelledNumber(line, firstDigitSpelledIndex);

}

int GetSpelledNumber(string line, int index)
{
    var source = line.Substring(index).ToLower();
    foreach (var spelledNumber in spelledNumbers)
    {
        if (source.StartsWith(spelledNumber.Key))
        {
            return spelledNumber.Value;
        }
    }

    throw new Exception();
}

int GetLastDigit(int lastDigitCharIndex, int lastDigitSpelledIndex, string line)
{
    if(lastDigitCharIndex > lastDigitSpelledIndex)
    {
        var characterLine = line.ToCharArray();
        return int.Parse(characterLine[lastDigitCharIndex].ToString());
    }

    return GetSpelledNumber(line, lastDigitSpelledIndex);
}

bool ContainsSpelledDigit(string line)
{
    foreach (var spelledNumber in spelledNumbers)
    {
        if (line.ToLower().Contains(spelledNumber.Key))
        {
            return true;
        }
    }
    return false;
}


Console.WriteLine(sumOfCalibrationValues);
