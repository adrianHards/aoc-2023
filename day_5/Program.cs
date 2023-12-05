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

            string seedToSoilString = sections[1].Split(':')[1].Trim();
            int[][] seedToSoilMap = seedToSoilString.Split('\n')
                .Select(line => line.Split(' ')
                .Select(int.Parse).ToArray())
                .ToArray();

        }
        catch (IOException e)
        {
            Console.WriteLine("An error occurred while reading the file: " + e.Message);
        }
    }
}

