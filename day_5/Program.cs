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
}

