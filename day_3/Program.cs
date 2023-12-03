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

            for (int i = 0; i < test_input.Length; i++)
            {
                string row = test_input[i];
                int row_i = i;
                sum += PartNumber(row, row_i);
            }

            Console.WriteLine("sum: " + sum);
        }
        catch (IOException e)
        {
            Console.WriteLine("An error occurred while reading the file: " + e.Message);
        }
    }

    static int PartNumber(string row, int row_i)
    {
        int sum = 0;

        foreach (char chr in row)
        {
            if (char.IsDigit(chr))
            {
                if (CheckIfPartNum(chr, row_i))
                {
                    return 0;
                }
            }
        }

        return sum;
    }

    static bool CheckIfPartNum(char chr, int row_i)
    {

        return false;
    }
}
