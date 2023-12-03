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
                if (CheckIfPartNum(i, row, row_i))
                {
                    (int num, int endIndex) = GetFullNum(i, row);
                    i = endIndex;
                    sum += num;
                }
            }
        }

        return sum;
    }

    static (int, int) GetFullNum(int char_i, string row)
    {
        string num_string = "";
        int startIndex = char_i;

        while (true)
        {
            if (startIndex > 0 && char.IsDigit(row[startIndex - 1]))
            {
                startIndex--;
            }
            else
            {
                break;
            }
        }

        while (char.IsDigit(row[startIndex]))
        {
            Console.WriteLine(num_string);
            num_string += row[startIndex];
            Console.WriteLine(num_string);
            startIndex++;
        }

        int number = int.Parse(num_string);
        Console.WriteLine(number);
        return (number, startIndex);
    }

    static bool CheckIfPartNum(int char_i, string row, int row_i)
    {
        try
        {
            char charToLeft = row[char_i - 1];
            if (!char.IsDigit(charToLeft) && charToLeft != '.')
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
            if (!char.IsDigit(charToRight) && charToRight != '.')
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
            if (!char.IsDigit(charAbove) && charAbove != '.')
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
            if (!char.IsDigit(charBelow) && charBelow != '.')
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
            if (!char.IsDigit(charAboveToRight) && charAboveToRight != '.')
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
            if (!char.IsDigit(charAboveToLeft) && charAboveToLeft != '.')
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
            if (!char.IsDigit(charBelowToLeft) && charBelowToLeft != '.')
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
            if (!char.IsDigit(charBelowToRight) && charBelowToRight != '.')
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
