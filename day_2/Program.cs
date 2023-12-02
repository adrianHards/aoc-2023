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
                if (ValidGame(line))
                {
                    sum += GameID(line);
                }
            }
            Console.WriteLine(sum);
        }
        catch (IOException e)
        {
            Console.WriteLine("An error occurred while reading the file: " + e.Message);
        }
    }

    static int GameID(string line)
    {
        int colonIndex = line.IndexOf(':');
        string game = line.Substring(0, colonIndex);
        int whiteSpaceIndex = game.IndexOf(' ');
        string gameID = game[whiteSpaceIndex..];
        return int.Parse(gameID);
    }

    static bool ValidGame(string line)
    {
    }
}
