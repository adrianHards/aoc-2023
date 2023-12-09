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
            string[] values = rows[i].Split(' '); // Assuming values are separated by spaces
            arrayOfIntegers[i] = Array.ConvertAll(values, int.Parse);
        }

        foreach (int[] array in arrayOfIntegers)
        {

        }

        // foreach (int[] array in arrayOfIntegers)
        // {
        //     Console.WriteLine(string.Join(" ", array));
        // }
    }
}
