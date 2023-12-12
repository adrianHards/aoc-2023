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

            List<int>[] starCoords = new List<int>[arrayOfStars.Length];

            for (int i = 0; i < arrayOfStars.Length; i++)
            {
                starCoords[i] = new List<int>();
                for (int j = 0; j < arrayOfStars[i].Length; j++)
                {
                    starCoords[i].Add(j);
                }
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
