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

            Dictionary<string, int> typeValue = new Dictionary<string, int>
            {
                { "5,0,0,0,0", 7 },
                { "4,1,0,0,0", 6 },
                { "3,2,0,0,0", 5 },
                { "3,1,1,0,0", 4 },
                { "2,2,1,0,0", 3 },
                { "2,1,1,1,0", 2 },
                { "1,1,1,1,1", 1 },
            };

            {
                string filePath = "./testinput.txt";
                string[] rows = File.ReadAllLines(filePath);

                Dictionary<string, (int labelsAsInts, int multiplier, int type, int rank)> cardDictionary = new();

                foreach (string row in rows)
                {
                    string card = row.Substring(0, 5);
                    int multiplier = int.Parse(row.Substring(5).Trim());
                    string labelsAsString = "";

                    foreach (char c in card)
                    {
                        string label = c.ToString();
                        if (cardValue.TryGetValue(label, out int value))
                        {
                            labelsAsString += value.ToString();
                        }
                    }

                    int labelsAsInts = int.Parse(labelsAsString);
                    cardDictionary[card] = (labelsAsInts, multiplier, 0, 0);
                }

                foreach (var kvp in cardDictionary)
                {
                    string card = kvp.Key;
                    Dictionary<char, int> labelCount = new();

                    foreach (char label in card)
                    {

                        if (labelCount.ContainsKey(label))
                        {
                            labelCount[label]++;
                        }
                        else
                        {
                            labelCount[label] = 1;
                        }
                    }
                    var orderedValues = labelCount.OrderByDescending(label => label.Value).Select(label => label.Value).ToArray();
                    int[] resultArray = new int[5];
                    Array.Copy(orderedValues, resultArray, Math.Min(5, orderedValues.Length));

                    string resultKey = string.Join(",", resultArray);
                    int typeRank = typeValue[resultKey];

                    cardDictionary[card] = (cardDictionary[card].labelsAsInts, cardDictionary[card].multiplier, typeRank, cardDictionary[card].rank);
                }

                foreach (var kvp in cardDictionary)
                {
                    var (labelsAsInts, multiplier, type, rank) = kvp.Value;
                    Console.WriteLine($"Card: {kvp.Key}, Num: {labelsAsInts}, Multiplier: {multiplier}, Type: {type}, Rank: {rank}");
                }
            }
        }
    }
}