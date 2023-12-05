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

            {
                Console.WriteLine(seedContent);
            }

        }
        catch (IOException e)
        {
            Console.WriteLine("An error occurred while reading the file: " + e.Message);
        }
    }
}

