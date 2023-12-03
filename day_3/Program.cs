﻿class Program
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
                    return 0;
                }
            }
        }

        return sum;
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

        return false;
    }
}
