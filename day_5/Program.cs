using System.Numerics;

namespace day_5
{
    class Program
    {
        static void Main()
        {
            // string filePath = "./input.txt";
            string filePath = "./testData.txt";

            try
            {
                string seedContent = File.ReadAllText(filePath);
                string[] sections = seedContent.Split("\n\n");

                string seedString = sections[0].Split(":")[1].Trim();
                long[] seedsArray = Array.ConvertAll(seedString.Split(' '), long.Parse);

                long[][] seedToSoilMap = GetMap(sections[1]);
                long[][] soilToFertMap = GetMap(sections[2]);
                long[][] fertToWaterMap = GetMap(sections[3]);
                long[][] waterToLightMap = GetMap(sections[4]);
                long[][] lightToTempMap = GetMap(sections[5]);
                long[][] tempToHumidMap = GetMap(sections[6]);
                long[][] humidToLocationMap = GetMap(sections[7]);

                Dictionary<long, long> seedValueDict = [];

                foreach (long element in seedsArray)
                {
                    seedValueDict[element] = element;
                }

                Dictionary<long, long>[] dicts =
                [
                    MakeDict(seedToSoilMap),
                    MakeDict(soilToFertMap),
                    MakeDict(fertToWaterMap),
                    MakeDict(waterToLightMap),
                    MakeDict(lightToTempMap),
                    MakeDict(tempToHumidMap),
                    MakeDict(humidToLocationMap)
                ];

                for (int i = 0; i < seedsArray.Length; i++)
                {
                    long startingValue = seedsArray[i];

                    foreach (Dictionary<long, long> dict in dicts)
                    {
                        if (dict.TryGetValue(startingValue, out long value))
                        {
                            startingValue = value;
                        }
                    }
                    seedValueDict[seedsArray[i]] = startingValue;
                }
                Console.WriteLine("lowest value: " + seedValueDict.Values.Min());
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred while reading the file: " + e.Message);
            }
        }
        static long[][] GetMap(string mapString)
        {
            return mapString.Split(':')[1].Trim().Split('\n')
                .Select(line => line.Split(' ')
                .Select(long.Parse).ToArray())
                .ToArray();
        }

        static Dictionary<long, long> MakeDict(long[][] mapArray)
        {
            Dictionary<long, long> newDict = [];

            foreach (long[] row in mapArray)
            {
                long value = row[0];
                long key = row[1];
                long rangeLength = row[2];
                long modifier = 0;

                for (long i = key; i < (key + rangeLength); i++)
                {
                    if (!newDict.ContainsKey(i))
                    {
                        newDict[i] = value + modifier;
                    }
                    modifier++;
                }
            }
            return newDict;
        }
    }
}
