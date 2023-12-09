namespace day_9;

class Program
{
    static void Main(string[] args)
    {
        string filePath = "./input.txt";
        string[] rows = File.ReadAllLines(filePath);
        int[][] arrayOfIntegers = new int[rows.Length][];
        int sum = 0;

        for (int i = 0; i < rows.Length; i++)
        {
            string[] values = rows[i].Split(' ');
            arrayOfIntegers[i] = Array.ConvertAll(values, int.Parse);
        }

        foreach (int[] integersArray in arrayOfIntegers)
        {
            var numbers = new List<int>(integersArray);
            var histories = new List<List<int>>();
            histories.Add(numbers);

            while (true)
            {
                var differences = new List<int>();

                for (int i = 0; i < numbers.Count - 1; i++)
                {
                    differences.Add(numbers[i + 1] - numbers[i]);
                }

                histories.Add(differences);

                if (differences.TrueForAll(d => d == 0)) break;

                numbers = differences;
            }

            for (int i = histories.Count - 2; i >= 0; i--)
            {
                histories[i].Add(histories[i + 1][^1] + histories[i][^1]);
                // Console.WriteLine(string.Join(" ", histories[i]));
            }
            sum += histories[0][^1];
        }
        Console.WriteLine(sum);
    }
}
