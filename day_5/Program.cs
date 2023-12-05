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

            Dictionary<int, int> SeedValueDict = new Dictionary<int, int>();

            foreach (int element in seedsArray)
            {
                SeedValueDict[element] = element;
            }
            // Dictionary<int, int> SeedValueDict = seedsArray.ToDictionary(key => key, value => value);
            Dictionary<int, int> seedToSoilDict = MakeDict(seedToSoilMap);
            Dictionary<int, int> soilToFertDict = MakeDict(soilToFertMap);
            Dictionary<int, int> fertToWaterDict = MakeDict(fertToWaterMap);
            Dictionary<int, int> waterToLightDict = MakeDict(waterToLightMap);
            Dictionary<int, int> lightToTempDict = MakeDict(lightToTempMap);
            Dictionary<int, int> tempToHumidDict = MakeDict(tempToHumidMap);
            Dictionary<int, int> humidToLocationDict = MakeDict(humidToLocationMap);




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
        foreach (var kvp in newDict)
        {
            Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
        }
        return newDict;
    }

    static bool IfKeyPresentReassign(string mapString)
    {
        return mapString.Split(':')[1].Trim().Split('\n')
            .Select(line => line.Split(' ')
            .Select(int.Parse).ToArray())
            .ToArray();
    }
}

