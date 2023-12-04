namespace day_4;

class Program
{
    // static string[] gamesArray = new string[]
    // {
    //     "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53",
    //     "Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19",
    //     "Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1",
    //     "Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83",
    //     "Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36",
    //     "Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11"
    // };

    static string[] gamesArray = new string[0];
    static async Task Main()
    {
        string filePath = "./input.txt";

        try
        {
            string[] rows = await File.ReadAllLinesAsync(filePath);
            gamesArray = gamesArray.Concat(rows).ToArray();

            int sum = 0;

            foreach (string row in gamesArray)
            {
                IEnumerable<string> commonCards = CommonCards(row);
                int numSharedCards = commonCards.Count();
                int bonusPoints = numSharedCards >= 1 ? (int)Math.Pow(2, numSharedCards - 1) : 0;
                sum += bonusPoints;
            }

            Console.WriteLine("sum: " + sum);
        }
        catch (IOException e)
        {
            Console.WriteLine("An error occurred while reading the file: " + e.Message);
        }

        static IEnumerable<string> CommonCards(string cards)
        {
            string[] cardArray = cards.Split(':', '|');
            string[] winningCards = cardArray[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] playerCards = cardArray[2].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            return winningCards.Intersect(playerCards);
        }
    }
}
