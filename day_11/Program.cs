namespace day_11
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "./testinput.txt";
            char[][] arrayOfStars = ReadAndProcessFile(filePath);

            var starCoords = FindStarCoordinates(arrayOfStars);
            var emptyRows = FindEmptyRows(arrayOfStars);
            var emptyCols = FindEmptyColumns(arrayOfStars);
            var allCombinations = FindCombinations(starCoords, 2);
            var distancesBetweenStars = FindDistances(allCombinations, emptyRows, emptyCols);
            sumDistances(distancesBetweenStars);
        }

        static void sumDistances(List<int> distances)
        {
            int sum = 0;
            foreach (int distance in distances)
            {
                sum += distance;
            }
            Console.WriteLine(sum);
        }

        static List<int> FindDistances
        (
            IEnumerable<IEnumerable<(int row, int col)>> combinations,
            List<int> emptyRows,
            List<int> emptyCols
        )
        {
            Console.WriteLine(combinations.Count());
            var distances = combinations.Select(combination =>
            {
                var coords = combination.ToList();
                var (firstRow, firstCol) = coords[0];
                var (secondRow, secondCol) = coords[1];

                var minRow = Math.Min(firstRow, secondRow);
                var maxRow = Math.Max(firstRow, secondRow);
                var countEmptyRowsInRange = emptyRows.Count(row => row >= minRow && row <= maxRow);

                var minCol = Math.Min(firstCol, secondCol);
                var maxCol = Math.Max(firstCol, secondCol);
                var countEmptyColsInRange = emptyCols.Count(row => row >= minCol && row <= maxCol);

                return Math.Abs(maxRow - minRow) + Math.Abs(maxCol - minCol);
            }).ToList();

            return distances;
        }

        static char[][] ReadAndProcessFile(string filePath)
        {
            string[] rows = File.ReadAllLines(filePath);
            char[][] arrayOfStars = new char[rows.Length][];
            for (int i = 0; i < rows.Length; i++)
            {
                arrayOfStars[i] = rows[i].ToCharArray();
            }
            return arrayOfStars;
        }

        static List<(int row, int col)> FindStarCoordinates(char[][] arrayOfStars)
        {
            List<(int row, int col)> starCoords = new List<(int row, int col)>();
            for (int i = 0; i < arrayOfStars.Length; i++)
            {
                for (int j = 0; j < arrayOfStars[i].Length; j++)
                {
                    if (arrayOfStars[i][j] == '#')
                    {
                        starCoords.Add((i, j));
                    }
                }
            }
            return starCoords;
        }

        static List<int> FindEmptyRows(char[][] arrayOfStars)
        {
            List<int> emptyRows = new List<int>();
            for (int i = 0; i < arrayOfStars.Length; i++)
            {
                if (arrayOfStars[i].All(c => c == '.'))
                {
                    emptyRows.Add(i);
                }
            }
            return emptyRows;
        }

        static List<int> FindEmptyColumns(char[][] arrayOfStars)
        {
            List<int> emptyCols = new List<int>();
            for (int j = 0; j < arrayOfStars[0].Length; j++)
            {
                bool colIsEmpty = true;
                for (int i = 0; i < arrayOfStars.Length; i++)
                {
                    if (arrayOfStars[i][j] != '.')
                    {
                        colIsEmpty = false;
                        break;
                    }
                }
                if (colIsEmpty)
                {
                    emptyCols.Add(j);
                }
            }
            return emptyCols;
        }

        static IEnumerable<IEnumerable<T>> FindCombinations<T>(IEnumerable<T> elements, int k)
        {
            if (k == 0) yield return Enumerable.Empty<T>();

            int i = 0;
            foreach (T element in elements)
            {
                if (elements.Skip(i + 1).Any())
                {
                    foreach (var combination in FindCombinations(elements.Skip(i + 1), k - 1))
                    {
                        yield return new T[] { element }.Concat(combination);
                    }
                }
                i++;
            }
        }
    }
}
