namespace day_4;

class Program
{
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
                int commonCards = CommonCards(cardsArray[i]);
                int currentCardIndex = i + 1;
                int nextCardIndex = currentCardIndex + 1;
                int iterations = scratchCardDict[currentCardIndex];

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
            Console.WriteLine("sum: " + sum);
        }
        catch (IOException e)
        {
            Console.WriteLine("An error occurred while reading the file: " + e.Message);
        }

        static int CommonCards(string cards)
        {
            string[] cardArray = cards.Split(':', '|');
            string[] winningCards = cardArray[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] playerCards = cardArray[2].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            return winningCards.Intersect(playerCards).Count();
        }
    }
}
