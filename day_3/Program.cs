class Program
{
    // static string[] partsArray = new string[]
    // {
    //     "467..114..",
    //     "...*......",
    //     "..35..633.",
    //     "......#...",
    //     "617*......",
    //     ".....+.58.",
    //     "..592.....",
    //     "......755.",
    //     "...$.*....",
    //     ".664.598..",
    // };

    static string[] partsArray = new string[0];
    static async Task Main()
    {
        string filePath = "./input.txt";

        try
        {
            string[] rows = await File.ReadAllLinesAsync(filePath);
            partsArray = partsArray.Concat(rows).ToArray();

            int sum = 0;

            for (int i = 0; i < partsArray.Length; i++)
            {
                string row = partsArray[i];
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
            // if (char.IsDigit(currentChar))
            // {
            //     if (CheckIfPartNum(i, row, row_i))
            //     {
            //         (int num, int endIndex) = GetFullNum(i, row);
            //         i = endIndex;
            //         sum += num;
            //     }
            // }
            if (currentChar == '*')
            {
                int num = GearRatio(i, row, row_i);
                sum += num;
            }
        }

        return sum;
    }

    static int GearRatio(int char_i, string row, int row_i)
    {
        int[] numsToMultiply = NumbersAround(char_i, row, row_i);
        foreach (int num in numsToMultiply)
        {
            Console.WriteLine(numsToMultiply.Length);
            Console.WriteLine(num);
        }
        Console.WriteLine(numsToMultiply.Length);
        if (numsToMultiply.Length == 2)
        {
            return numsToMultiply[0] * numsToMultiply[1];
        }
        return 0;
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

        while (startIndex < row.Length && char.IsDigit(row[startIndex]))
        {
            num_string += row[startIndex];
            startIndex++;
        }

        int number = int.Parse(num_string);
        return (number, startIndex);
    }

    static bool CheckIfPartNum(int char_i, string row, int row_i)
    {
        try
        {
            char charToLeft = row[char_i - 1];
            if (!char.IsDigit(charToLeft) && charToLeft != '.' && charToLeft != '*')
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
            if (!char.IsDigit(charToRight) && charToRight != '.' && charToRight != '*')
            {
                return true;
            }
        }
        catch (IndexOutOfRangeException)
        {
        }

        try
        {
            char charAbove = partsArray[row_i - 1][char_i];
            if (!char.IsDigit(charAbove) && charAbove != '.' && charAbove != '*')
            {
                return true;
            }
        }
        catch (IndexOutOfRangeException)
        {
        }

        try
        {
            char charBelow = partsArray[row_i + 1][char_i];
            if (!char.IsDigit(charBelow) && charBelow != '.' && charBelow != '*')
            {
                return true;
            }
        }
        catch (IndexOutOfRangeException)
        {
        }

        try
        {
            char charAboveToRight = partsArray[row_i - 1][char_i - 1];
            if (!char.IsDigit(charAboveToRight) && charAboveToRight != '.' && charAboveToRight != '*')
            {
                return true;
            }
        }
        catch (IndexOutOfRangeException)
        {
        }

        try
        {
            char charAboveToLeft = partsArray[row_i - 1][char_i + 1];
            if (!char.IsDigit(charAboveToLeft) && charAboveToLeft != '.' && charAboveToLeft != '*')
            {
                return true;
            }
        }
        catch (IndexOutOfRangeException)
        {
        }

        try
        {
            char charBelowToLeft = partsArray[row_i + 1][char_i - 1];
            if (!char.IsDigit(charBelowToLeft) && charBelowToLeft != '.' && charBelowToLeft != '*')
            {
                return true;
            }
        }
        catch (IndexOutOfRangeException)
        {
        }

        try
        {
            char charBelowToRight = partsArray[row_i + 1][char_i + 1];
            if (!char.IsDigit(charBelowToRight) && charBelowToRight != '.' && charBelowToRight != '*')
            {
                return true;
            }
        }
        catch (IndexOutOfRangeException)
        {
        }

        return false;
    }

    static int[] NumbersAround(int char_i, string row, int row_i)
    {
        HashSet<int> numSet = new HashSet<int>();

        try
        {
            char charToLeft = row[char_i - 1];
            if (char.IsDigit(charToLeft))
            {
                int index = char_i - 1;
                var (num, endIndex) = GetFullNum(index, row);
                numSet.Add(num);
            }
        }
        catch (IndexOutOfRangeException)
        {
        }

        try
        {
            char charToRight = row[char_i + 1];
            if (char.IsDigit(charToRight))
            {
                int index = char_i + 1;
                var (num, endIndex) = GetFullNum(index, row);
                numSet.Add(num);
            }
        }
        catch (IndexOutOfRangeException)
        {
        }

        try
        {
            char charAbove = partsArray[row_i - 1][char_i];
            if (char.IsDigit(charAbove))
            {
                int index = char_i;
                var (num, endIndex) = GetFullNum(index, partsArray[row_i - 1]);
                numSet.Add(num);
            }
        }
        catch (IndexOutOfRangeException)
        {
        }

        try
        {
            char charBelow = partsArray[row_i + 1][char_i];
            if (char.IsDigit(charBelow))
            {
                int index = char_i;
                var (num, endIndex) = GetFullNum(index, partsArray[row_i + 1]);
                numSet.Add(num);
            }
        }
        catch (IndexOutOfRangeException)
        {
        }

        try
        {
            char charAboveToRight = partsArray[row_i - 1][char_i - 1];
            if (char.IsDigit(charAboveToRight))
            {
                int index = char_i - 1;
                var (num, endIndex) = GetFullNum(index, partsArray[row_i - 1]);
                numSet.Add(num);
            }
        }
        catch (IndexOutOfRangeException)
        {
        }

        try
        {
            char charAboveToLeft = partsArray[row_i - 1][char_i + 1];
            if (char.IsDigit(charAboveToLeft))
            {
                int index = char_i + 1;
                var (num, endIndex) = GetFullNum(index, partsArray[row_i - 1]);
                numSet.Add(num);
            }
        }
        catch (IndexOutOfRangeException)
        {
        }

        try
        {
            char charBelowToLeft = partsArray[row_i + 1][char_i - 1];
            if (char.IsDigit(charBelowToLeft))
            {
                int index = char_i - 1;
                var (num, endIndex) = GetFullNum(index, partsArray[row_i + 1]);
                numSet.Add(num);
            }
        }
        catch (IndexOutOfRangeException)
        {
        }

        try
        {
            char charBelowToRight = partsArray[row_i + 1][char_i + 1];
            if (char.IsDigit(charBelowToRight))
            {
                int index = char_i + 1;
                var (num, endIndex) = GetFullNum(index, partsArray[row_i + 1]);
                numSet.Add(num);
            }
        }
        catch (IndexOutOfRangeException)
        {
        }

        return numSet.ToArray();
    }
}
