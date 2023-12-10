namespace day_10;

class Program
{
    static void Main(string[] args)
    {
        string filePath = "./testinput.txt";
        string[] rows = File.ReadAllLines(filePath);

        char[][] arraysOfChars = new char[rows.Length][];
        for (int i = 0; i < rows.Length; i++)
        {
            arraysOfChars[i] = rows[i].ToCharArray();
        }

        int rowIndexS = 0;
        int columnIndexS = 0;

        for (int i = 0; i < arraysOfChars.Length; i++)
        {
            for (int j = 0; j < arraysOfChars[i].Length; j++)
            {
                if (arraysOfChars[i][j] == 'S')
                {
                    rowIndex = i;
                    columnIndex = j;
                    break;
                }
            }
        }
    }
}