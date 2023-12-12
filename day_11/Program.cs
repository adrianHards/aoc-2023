﻿namespace day_11
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

            var allCombinations = Combinations(starCoords, 2);

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

        static List<Tuple<int, int>> FindStarCoordinates(char[][] arrayOfStars)
        {
            List<Tuple<int, int>> starCoords = new List<Tuple<int, int>>();
            for (int i = 0; i < arrayOfStars.Length; i++)
            {
                for (int j = 0; j < arrayOfStars[i].Length; j++)
                {
                    if (arrayOfStars[i][j] == '#')
                    {
                        starCoords.Add(new Tuple<int, int>(i, j));
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
