class Program
{
    static async Task Main()
    {
        string filePath = "./input.txt";

        try
        {
            string[] lines = await File.ReadAllLinesAsync(filePath);
            int sum = 0;
            int power = 0;

            foreach (string line in lines)
            {
                int colonIndex = line.IndexOf(':');
                string gameString = line[(colonIndex + 1)..];
                if (ValidGame(gameString))
                {
                    sum += GameID(line, colonIndex);
                }
                var minValues = MinimumValues(gameString);
                power += Power(minValues);
            }
            Console.WriteLine("sum: " + sum);
            Console.WriteLine("power: " + power);
        }
        catch (IOException e)
        {
            Console.WriteLine("An error occurred while reading the file: " + e.Message);
        }
    }

    static int GameID(string line, int colonIndex)
    {
        string game = line.Substring(0, colonIndex);
        int whiteSpaceIndex = game.IndexOf(' ');
        string gameID = game[whiteSpaceIndex..];
        return int.Parse(gameID);
    }

    static Dictionary<string, int> RGB = new()
    {
        {"red", 12},
        {"green", 13},
        {"blue", 14}
    };

    static bool ValidGame(string gameString)
    {
        string[] gameValues = gameString.Split(new char[] { ',', ';' });
        foreach (var value in gameValues)
        {
            string colour = value.Split(' ').Last();
            int colourValue = int.Parse(value.TrimStart().Split(' ').First());
            if (RGB[colour] < colourValue)
            {
                return false;
            }
        }
        return true;
    }

    static Dictionary<string, int> MinimumValues(string gameString)
    {
        Dictionary<string, int> RGBMinValues = new()
        {
            {"red", 0},
            {"green", 0},
            {"blue", 0}
        };

        string[] gameValues = gameString.Split(new char[] { ',', ';' });
        foreach (var value in gameValues)
        {
            string colour = value.Split(' ').Last();
            int colourValue = int.Parse(value.TrimStart().Split(' ').First());
            if (RGBMinValues[colour] < colourValue)
            {
                RGBMinValues[colour] = colourValue;
            }
        }
        return RGBMinValues;
    }

    static int Power(Dictionary<string, int> minValues)
    {
        return minValues["red"] * minValues["green"] * minValues["blue"];
    }
}
