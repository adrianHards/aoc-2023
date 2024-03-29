﻿namespace day_10;

class Program
{
    static void Main(string[] args)
    {
        string filePath = "./input.txt";
        string[] rows = File.ReadAllLines(filePath);

        char[][] arraysOfChars = new char[rows.Length][];
        for (int i = 0; i < rows.Length; i++)
        {
            arraysOfChars[i] = rows[i].ToCharArray();
        }

        int startRowIndex = 0;
        int startColumnIndex = 0;

        for (int i = 0; i < arraysOfChars.Length; i++)
        {
            for (int j = 0; j < arraysOfChars[i].Length; j++)
            {
                if (arraysOfChars[i][j] == 'S')
                {
                    startRowIndex = i;
                    startColumnIndex = j;
                    break;
                }
            }
        }

        Dictionary<(int row, int col), Dictionary<char, (int row, int col)>> directionDict = new()
        {
            {
                // from left
                (row: 0, col: 1), new Dictionary<char, (int row, int col)>
                {
                    { 'J', (row: -1, col: 0) },
                    { '7', (row: 1, col: 0) },
                    { '-', (row: 0, col: 1) }
                }
            },
            {
                // from right
                (row: 0, col: -1), new Dictionary<char, (int row, int col)>
                {
                    { 'F', (row: 1, col: 0) },
                    { 'L', (row: -1, col: 0) },
                    { '-', (row: 0, col: -1) }
                }
            },
            {
                // from top
                (row: 1, col: 0), new Dictionary<char, (int row, int col)>
                {
                    { '|', (row: 1, col: 0) },
                    { 'L', (row: 0, col: 1) },
                    { 'J', (row: 0, col: -1) }
                }
            },
            {
                // from bottom
                (row: -1, col: 0), new Dictionary<char, (int row, int col)>
                {
                    { '|', (row: -1, col: 0) },
                    { 'F', (row: 0, col: 1) },
                    { '7', (row: 0, col: -1) }
                }
            }
        };

        int count = 1;
        (int row, int col) direction = (row: 1, col: 0);
        int rowIndex = startRowIndex + direction.row;
        int colIndex = startColumnIndex + direction.col;
        char currentChar = arraysOfChars[rowIndex][colIndex];

        while (currentChar != 'S')
        {
            count++;

            rowIndex += direction.row;
            colIndex += direction.col;
            currentChar = arraysOfChars[rowIndex][colIndex];

            if (currentChar == 'S')
            {
                break;
            }

            direction = directionDict[direction][currentChar];
            Console.WriteLine(currentChar + " " + direction + "row " + rowIndex + "col " + colIndex);
            Console.WriteLine(direction);
        }

        Console.WriteLine(count / 2);
    }
}