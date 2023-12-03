class Program
{
    static string[] partsArray = new string[0];
    static async Task Main()
    {
        string filePath = "./input.txt";

        try
        {
            string[] rows = await File.ReadAllLinesAsync(filePath);
            partsArray = partsArray.Concat(rows).ToArray();

            int sum = 0;

            string[] test_input = new string[]
            {
                "467..114..",
                "...*......",
                "..35..633.",
                "......#...",
                "617*......",
                ".....+.58.",
                "..592.....",
                "......755.",
                "...$.*....",
                ".664.598..",
            };

            foreach (string row in test_input)
            {
                {
                    sum += PartNumber(row);
                }
            }
            Console.WriteLine("sum: " + sum);
        }
        catch (IOException e)
        {
            Console.WriteLine("An error occurred while reading the file: " + e.Message);
        }
    }

    static int PartNumber(string row)
    {

        foreach (char chr in row)
        {
            Console.WriteLine(chr);
        }

        return 0;
    }
}
