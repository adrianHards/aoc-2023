namespace day_11
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "./testinput.txt";
            string[] rows = File.ReadAllLines(filePath);
            char[][] arrayOfStars = new char[rows.Length][];

            for (int i = 0; i < rows.Length; i++)
            {
                arrayOfStars[i] = rows[i].ToCharArray();
            }

            List<Tuple<int, int>> starCoords = new();

            for (int i = 0; i < arrayOfStars.Length; i++)
            {
                int row = i;
                for (int j = 0; j < arrayOfStars[row].Length; j++)
                {
                    int col = j;
                    if (arrayOfStars[row][col] == '#')
                    {
                        starCoords.Add(new Tuple<int, int>(row, col));
                    }
                }
            }

            var allCombinations = Combinations(starCoords, 2);

            foreach (var combination in allCombinations)
            {
                foreach (var coord in combination)
                {
                    Console.Write($"{coord} ");
                }
                Console.WriteLine();
            }
        }

        static IEnumerable<IEnumerable<T>> Combinations<T>(IEnumerable<T> elements, int k)
        {
            if (k == 0) yield return Enumerable.Empty<T>();

            int i = 0;
            foreach (T element in elements)
            {
                if (elements.Skip(i + 1).Any())
                {
                    foreach (var combination in Combinations(elements.Skip(i + 1), k - 1))
                    {
                        yield return new T[] { element }.Concat(combination);
                    }
                }
                i++;
            }
        }
    }
}
