namespace day_9;

class Program
{
    static void Main(string[] args)
    {
        string filePath = "./testinput.txt";
        string[] rows = File.ReadAllLines(filePath);
        int[][] arrayOfIntegers = new int[rows.Length][];

        for (int i = 0; i < rows.Length; i++)
        {
            string[] values = rows[i].Split(' ');
            arrayOfIntegers[i] = Array.ConvertAll(values, int.Parse);
        }

        foreach (int[] integersArray in arrayOfIntegers)
        {
            var numbers = new List<int>(integersArray);
            var histories = new List<List<int>>();

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

            foreach (var history in histories)
            {
                Console.WriteLine(string.Join(" ", history));
            }
        }
    }
}
