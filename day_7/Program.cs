﻿namespace day_7
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
                ["T"] = 10,
                ["9"] = 9,
                ["8"] = 8,
                ["7"] = 7,
                ["6"] = 6,
                ["5"] = 5,
                ["4"] = 4,
                ["3"] = 3,
                ["2"] = 2,
                ["J"] = 1
            };

            Dictionary<string, int> typeValue = new()
            {
                { "5,0,0,0,0", 7 },
                { "4,1,0,0,0", 6 },
                { "3,2,0,0,0", 5 },
                { "3,1,1,0,0", 4 },
                { "2,2,1,0,0", 3 },
                { "2,1,1,1,0", 2 },
                { "1,1,1,1,1", 1 }
            };

            {
                string filePath = "./input.txt";
                string[] rows = File.ReadAllLines(filePath);

                Dictionary<string, (List<int> labelValues, int multiplier, int type, int rank)> cardDictionary = [];

                foreach (string row in rows)
                {
                    string card = row[..5];
                    int multiplier = int.Parse(row[5..].Trim());
                    List<int> labelValues = [];

                    foreach (char c in card)
                    {
                        string label = c.ToString();
                        if (cardValue.TryGetValue(label, out int value))
                        {
                            labelValues.Add(value);
                        }
                    }

                    cardDictionary[card] = (labelValues, multiplier, 0, 0);
                }

                foreach (var kvp in cardDictionary)
                {
                    string card = kvp.Key;
                    Dictionary<char, int> labelCount = [];

                    foreach (char label in card)
                    {
                        if (labelCount.TryGetValue(label, out int value) && label != 'J')
                        {
                            labelCount[label] = ++value;
                        }
                        else if (label != 'J')
                        {
                            labelCount[label] = 1;
                        }
                    }

                    var orderedValues = labelCount.OrderByDescending(label => label.Value).Select(label => label.Value).ToArray();
                    int[] resultArray = new int[5];
                    Array.Copy(orderedValues, resultArray, Math.Min(5, orderedValues.Length));

                    if (card.Contains('J'))
                    {
                        int countOfJ = card.Count(c => c == 'J');

                        if (countOfJ == 5)
                        {
                            resultArray = [5, 0, 0, 0, 0];
                            countOfJ = 0;
                        }

                        else
                        {
                            resultArray[0] += countOfJ;
                        }
                    }

                    string resultKey = string.Join(",", resultArray);
                    int typeRank = typeValue[resultKey];

                    cardDictionary[card] = (cardDictionary[card].labelValues, cardDictionary[card].multiplier, typeRank, cardDictionary[card].rank);
                }

                int currentRank = 1;
                var groupedByType = cardDictionary.OrderBy(card => card.Value.type)
                    .GroupBy(card => card.Value.type)
                    .ToList();

                foreach (var typeGroup in groupedByType)
                {
                    if (typeGroup.Count() == 1)
                    {
                        var singleCard = typeGroup.First();
                        cardDictionary[singleCard.Key] = (singleCard.Value.labelValues, singleCard.Value.multiplier, singleCard.Value.type, currentRank);
                        currentRank++;
                    }
                    else
                    {
                        var sortedGroup = typeGroup.OrderBy(card => card.Value.labelValues, Comparer<List<int>>.Create((x, y) =>
                        {
                            int minLength = Math.Min(x.Count, y.Count);
                            for (int i = 0; i < minLength; i++)
                            {
                                if (x[i] != y[i])
                                {
                                    return x[i].CompareTo(y[i]);
                                }
                            }
                            return x.Count.CompareTo(y.Count);
                        })).ToArray();

                        foreach (var card in sortedGroup)
                        {
                            cardDictionary[card.Key] = (card.Value.labelValues, card.Value.multiplier, card.Value.type, currentRank);
                            currentRank++;
                        }
                    }
                }

                int totalWinnings = 0;

                foreach (var kvp in cardDictionary)
                {
                    var (labelValues, multiplier, type, rank) = kvp.Value;
                    totalWinnings += multiplier * rank;
                }

                Console.WriteLine($"Total Winnings: {totalWinnings}");
            }
        }
    }
}