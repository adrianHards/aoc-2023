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
            int[] seeds = Array.ConvertAll(seedString.Split(' '), int.Parse);

            foreach (int seed in seeds)
            {
                Console.WriteLine(seed);
            }
        }
        catch (IOException e)
        {
            Console.WriteLine("An error occurred while reading the file: " + e.Message);
        }
    }
}

