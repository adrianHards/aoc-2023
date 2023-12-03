class Program
{
    static string[] test_input = new string[]
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
    static string[] partsArray = new string[0];
    static async Task Main()
    {
        string filePath = "./input.txt";

        try
        {
            string[] rows = await File.ReadAllLinesAsync(filePath);
            partsArray = partsArray.Concat(rows).ToArray();

            int sum = 0;

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

        for (int i = 0; i < row.Length; i++)
        {
            char currentChar = row[i];
            if (char.IsDigit(currentChar))
            {
                if (CheckIfPartNum(currentChar, i, row, row_i))
                {
                    int num = GetFullNum(i, row);
                    int end_of_num_i = GetEndOfNumIndex(num);
                    i = end_of_num_i;
                    sum += num;
                }
            }
        }

        return sum;
    }

    static int GetEndOfNumIndex(num)
    {

    }

    static int GetFullNum(int char_i, string row)
    {
        string num_string = "";
        int startIndex = char_i;

        while (startIndex >= 0 && !char.IsDigit(row[startIndex]))
        {
            startIndex--;
        }

        while (char.IsDigit(row[startIndex]))
        {
            num_string += row[startIndex];
            startIndex++;
        }

        return int.Parse(num_string);
    }


    static bool CheckIfPartNum(char currentChar, int char_i, string row, int row_i)
    {
        try
        {
            char charToLeft = row[char_i - 1];
            if (charToLeft == '*')
            {
                return true;
            }
        }
        catch (IndexOutOfRangeException)
        {
        }

        try
        {
            char charToRight = row[char_i + 1];
            if (charToRight == '*')
            {
                return true;
            }
        }
        catch (IndexOutOfRangeException)
        {
        }

        try
        {
            char charAbove = test_input[row_i - 1][char_i];
            if (charAbove == '*')
            {
                return true;
            }
        }
        catch (IndexOutOfRangeException)
        {
        }

        try
        {
            char charBelow = test_input[row_i + 1][char_i];
            if (charBelow == '*')
            {
                return true;
            }
        }
        catch (IndexOutOfRangeException)
        {
        }

        try
        {
            char charAboveToRight = test_input[row_i - 1][char_i - 1];
            if (charAboveToRight == '*')
            {
                return true;
            }
        }
        catch (IndexOutOfRangeException)
        {
        }

        try
        {
            char charAboveToLeft = test_input[row_i - 1][char_i + 1];
            if (charAboveToLeft == '*')
            {
                return true;
            }
        }
        catch (IndexOutOfRangeException)
        {
        }

        try
        {
            char charBelowToLeft = test_input[row_i + 1][char_i - 1];
            if (charBelowToLeft == '*')
            {
                return true;
            }
        }
        catch (IndexOutOfRangeException)
        {
        }

        try
        {
            char charBelowToRight = test_input[row_i + 1][char_i + 1];
            if (charBelowToRight == '*')
            {
                return true;
            }
        }
        catch (IndexOutOfRangeException)
        {
        }

        return false;
    }
}
