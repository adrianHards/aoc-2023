namespace day_1;

class Program
{
    static async Task Main()
    {
        string filePath = "./input.txt";

        try
        {
            string[] lines = await File.ReadAllLinesAsync(filePath);
            int sum = 0;

            foreach (string line in lines)
            {
                int result = Calibration(line);
                sum += result;
            }
            Console.WriteLine(sum);
        }
        catch (IOException e)
        {
            Console.WriteLine("An error occurred while reading the file: " + e.Message);
        }
    }

    static int Calibration(string uncalibrated)
    {
        Dictionary<string, int> numberWords = new()
        {
            {"one", 1},
            {"two", 2},
            {"three", 3},
            {"four", 4},
            {"five", 5},
            {"six", 6},
            {"seven", 7},
            {"eight", 8},
            {"nine", 9}
        };

        string numberString = "";
        for (int i = 0; i < uncalibrated.Length; i++)
        {
            bool foundMatch = false;
            char currentChar = uncalibrated[i];
            if (char.IsDigit(currentChar))
            {
                numberString += currentChar;
            }
            else {
                foreach (var kvp in numberWords)
                {
                    string wordToFind = kvp.Key;
                    if (uncalibrated[i..].StartsWith(wordToFind))
                    {
                        numberString += kvp.Value;
                        foundMatch = true;
                        break;
                    }
                    if (foundMatch) break;
                }
            }
        }
        // Console.WriteLine(numberString);

        // int windowSize = 5;
        // bool breakFirstLoop = false;
        // for (int i = 0; i <= uncalibrated.Length - windowSize && !breakFirstLoop; i++)
        // {
        //     string window = uncalibrated.Substring(i, windowSize);
        //     foreach (var kvp in numberWords) {
        //         string wordToFind = kvp.Key;
        //         int replacementValue = kvp.Value;

        //         if (window.Contains(wordToFind))
        //         {
        //             uncalibrated = uncalibrated.Replace(wordToFind, replacementValue.ToString());
        //             breakFirstLoop = true;
        //             break;
        //         }
        //         if (breakFirstLoop) break;
        //     }
        // }

        // bool breakSecondLoop = false;
        // for (int i = uncalibrated.Length - windowSize; i >= 0 && !breakSecondLoop; i--)
        // {
        //     string window = uncalibrated.Substring(i, windowSize);
        //     foreach (var kvp in numberWords) {
        //         string wordToFind = kvp.Key;
        //         int replacementValue = kvp.Value;

        //         if (window.Contains(wordToFind))
        //         {
        //             uncalibrated = uncalibrated.Replace(wordToFind, replacementValue.ToString());
        //             breakSecondLoop = true;
        //             break;
        //         }
        //         if (breakSecondLoop) break;
        //     }
        // }
        // Console.WriteLine(numberString);

        char? firstDigit = null;
        char? lastDigit = null;
        int indexStart = 0;
        int indexEnd = numberString.Length - 1;

        while (!firstDigit.HasValue || !lastDigit.HasValue)
        {
            char pointer_a = numberString[indexStart];
            char pointer_b = numberString[indexEnd];

            if (char.IsDigit(pointer_a))
            {
                firstDigit = pointer_a;
            }

            if (char.IsDigit(pointer_b))
            {
                lastDigit = pointer_b;
            }

            if (!char.IsDigit(pointer_a))
            {
                indexStart++;
            }

            if (!char.IsDigit(pointer_b))
            {
                indexEnd--;
            }
        }

        return int.Parse($"{firstDigit}{lastDigit}");
    }
}

