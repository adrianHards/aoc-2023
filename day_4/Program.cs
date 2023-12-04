namespace day_4;

class Program
{
    // static string[] cardsArray = new string[]
    // {
    //     "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53",
    //     "Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19",
    //     "Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1",
    //     "Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83",
    //     "Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36",
    //     "Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11"
    // };

    static async Task Main()
    {
        string filePath = "./input.txt";

        try
        {
            string[] cardsArray = new string[0];
            string[] rows = await File.ReadAllLinesAsync(filePath);
            cardsArray = cardsArray.Concat(rows).ToArray();

            Dictionary<int, int> scratchCardDict = Enumerable.Range(1, cardsArray.Count()).ToDictionary(key => key, value => 1);

            for (int i = 0; i < cardsArray.Length; i++)
            {
                string game = cardsArray[i];
                int commonCards = CommonCards(game);
                int nextCardIndex = i + 2;
                int iterations = scratchCardDict[i + 1];

                for (int j = 0; j < iterations; j++)
                {
                    foreach (int num in Enumerable.Range(nextCardIndex, commonCards))
                    {
                        try
                        {
                            scratchCardDict[num] += 1;
                        }
                        catch (KeyNotFoundException)
                        {
                        }
                    }
                }
            }

            int sum = scratchCardDict.Values.Sum();
            foreach (var kvp in scratchCardDict)
            {
                Console.WriteLine(kvp.Value);
            }
            Console.WriteLine("sum: " + sum);
        }
        catch (IOException e)
        {
            Console.WriteLine("An error occurred while reading the file: " + e.Message);
        }

        static int CommonCards(string cards)
        {
            string[] cardArray = cards.Split(':', '|');
            // int cardNumber = int.Parse(cardArray[0].Split(' ')[1]);
            string[] winningCards = cardArray[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] playerCards = cardArray[2].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            return winningCards.Intersect(playerCards).Count();
        }
    }
}
