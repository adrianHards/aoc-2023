namespace day_7
{
    class Program
    {
        static void Main()
        {
            Dictionary<string, int> cardValue = new()
            {
                ["A"] = 14,
                ["K"] = 13,
                ["Q"] = 12,
                ["J"] = 11,
                ["10"] = 10,
                ["9"] = 9,
                ["8"] = 8,
                ["7"] = 7,
                ["6"] = 6,
                ["5"] = 5,
                ["4"] = 4,
                ["3"] = 3,
                ["2"] = 2
            };

            {
                string filePath = "./testinput.txt";
                string[] rows = File.ReadAllLines(filePath);

                Dictionary<string, (int multiplier, int count, int rank)> cardDictionary = new();

                foreach (string row in rows)
                {
                    string card = row.Substring(0, 5);
                    int multiplier = int.Parse(row.Substring(5).Trim());
                    cardDictionary[card] = (multiplier, 0, 0);
                }

                foreach (var kvp in cardDictionary)
                {
                    string card = kvp.Key;
                    foreach (char label in card)
                    {
                        Dictionary<char, int> labelCount = new();
                        if (labelCount.ContainsKey(label))
                        {
                            labelCount[label]++;
                        }
                        else
                        {
                            labelCount[label] = 1;
                        }
                    }
                }
            }
        }
    }
}