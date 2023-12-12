namespace day_11;

class Program
{
    static void Main(string[] args)
    {
        string filePath = "./testinput.txt";
        string[] rows = File.ReadAllLines(filePath);
        string[][] arrayOfStars = new string[rows.Length][];
    }

    IEnumerable<IEnumerable<T>> Combinations<T>(IEnumerable<T> elements, int k)
    {
        int i = 0;
        foreach (T element in elements)
        {
            foreach (var combination in Combinations(elements.Skip(i + 1), k - 1))
            {
                yield return new T[] { element }.Concat(combination);
            }
            i++;
        }
    }
}

