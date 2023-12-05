namespace day_5;

class Program
{
    static async Task Main()
    {
        // string filePath = "./input.txt";
        string filePath = "./testData.txt";

        try
        {
            string seedContent = File.ReadAllText(filePath);
            string[] sections = seedContent.Split("\n\n");

            string seedString = sections[0].Split(":")[1].Trim();
            int[] seedsArray = Array.ConvertAll(seedString.Split(' '), int.Parse);

            int[][] seedToSoilMap = GetMap(sections[1]);
            int[][] soilToFertMap = GetMap(sections[2]);
            int[][] fertToWaterMap = GetMap(sections[3]);
            int[][] waterToLightMap = GetMap(sections[4]);
            int[][] lightToTempMap = GetMap(sections[5]);
            int[][] tempToHumidMap = GetMap(sections[6]);
            int[][] humidToLocationMap = GetMap(sections[7]);

            Dictionary<int, int> seedValueDict = new Dictionary<int, int>();

            foreach (int element in seedsArray)
            {
                seedValueDict[element] = element;
            }

            Dictionary<int, int>[] dicts = new Dictionary<int, int>[]
            {
                MakeDict(seedToSoilMap),
                MakeDict(soilToFertMap),
                MakeDict(fertToWaterMap),
                MakeDict(waterToLightMap),
                MakeDict(lightToTempMap),
                MakeDict(tempToHumidMap),
                MakeDict(humidToLocationMap)
            };

            for (int i = 0; i < seedsArray.Length; i++)
            {
                int startingValue = seedsArray[i];

                foreach (Dictionary<int, int> dict in dicts)
                {
                    if (dict.ContainsKey(startingValue))
                    {
                        startingValue = dict[startingValue];
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
    static int[][] GetMap(string mapString)
    {
        return mapString.Split(':')[1].Trim().Split('\n')
            .Select(line => line.Split(' ')
            .Select(int.Parse).ToArray())
            .ToArray();
    }

    static Dictionary<int, int> MakeDict(int[][] mapArray)
    {
        Dictionary<int, int> newDict = new Dictionary<int, int>();

        foreach (int[] row in mapArray)
        {
            int value = row[0];
            int key = row[1];
            int rangeLength = row[2];
            int modifier = 0;

            for (int i = key; i < (key + rangeLength); i++)
            {
                if (!newDict.ContainsKey(i))
                {
                    newDict[i] = (value + modifier);
                }
                modifier++;
            }
        }
        return newDict;
    }
}

