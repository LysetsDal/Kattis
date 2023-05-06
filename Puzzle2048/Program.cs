using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


// Opgave: https://open.kattis.com/problems/2048 

class Program
{
    public static void Main()
    {
        int[,] board;
        int move = 0;

        board = parseBoard(4, 4);
        
        string input = Console.ReadLine();
        if (!string.IsNullOrEmpty(input))
        {
            move = int.Parse(input);
        }

        switch (move)
        {
            case 0:
                moveLeft(board);
                break;
            case 1:
                moveUp(board);
                break;
            case 2:
                moveRight(board);
                break;
            case 3:
                moveDown(board);
                break;
            default:
                throw new Exception("Error");
        }
        printBoard(board);
    }


    public static void moveLeft(int[,] board)
    {
        for (int row = 0; row < board.GetLength(0); row++)
        {
            // Combine adjacent values
            bool[] combined = new bool[board.GetLength(1)];
            for (int col = 1; col < board.GetLength(1); col++)
            {
                if (board[row, col] != 0)
                {
                    int currentCol = col;
                    while (currentCol > 0 && board[row, currentCol - 1] == 0)
                    {
                        board[row, currentCol - 1] = board[row, currentCol];
                        board[row, currentCol] = 0;
                        currentCol--;
                    }

                    if (currentCol > 0 && board[row, currentCol - 1] == board[row, currentCol] && !combined[currentCol - 1])
                    {
                        board[row, currentCol - 1] *= 2;
                        board[row, currentCol] = 0;
                        combined[currentCol - 1] = true;
                    }
                    else if (currentCol > 0 && board[row, currentCol - 1] != board[row, currentCol])
                    {
                        combined[currentCol - 1] = false;
                    }
                }
            }
        }
    }


    public static void moveRight(int[,] board)
    {
        var length = board.GetLength(1) - 1;

        for (int row = 0; row < board.GetLength(0); row++)
        {
            // Combine adjacent values
            bool[] combined = new bool[board.GetLength(1)];
            for (int col = length - 1; col >= 0; col--)
            {
                if (board[row, col] != 0)
                {
                    int currentCol = col;
                    while (currentCol < length && board[row, currentCol + 1] == 0)
                    {
                        board[row, currentCol + 1] = board[row, currentCol];
                        board[row, currentCol] = 0;
                        currentCol++;
                    }

                    if (currentCol < length && board[row, currentCol + 1] == board[row, currentCol] && !combined[currentCol + 1])
                    {
                        board[row, currentCol + 1] *= 2;
                        board[row, currentCol] = 0;
                        combined[currentCol + 1] = true;
                    }
                    else if (currentCol < length && board[row, currentCol + 1] != board[row, currentCol])
                    {
                        combined[currentCol + 1] = false;
                    }
                }
            }
        }
    }

    public static void moveUp(int[,] board)
    {
        for (int col = 0; col < board.GetLength(1); col++)
        {
            // Combine adjacent values
            bool[,] merged = new bool[board.GetLength(0), board.GetLength(1)]; // Initialize merged array
            for (int row = 1; row < board.GetLength(0); row++)
            {
                if (board[row, col] != 0)
                {
                    int currentRow = row;
                    while (currentRow > 0 && board[currentRow - 1, col] == 0)
                    {
                        board[currentRow - 1, col] = board[currentRow, col];
                        board[currentRow, col] = 0;
                        currentRow--;
                    }

                    if (currentRow > 0 && board[currentRow - 1, col] == board[currentRow, col] && !merged[currentRow - 1, col])
                    {
                        board[currentRow - 1, col] *= 2;
                        board[currentRow, col] = 0;
                        merged[currentRow - 1, col] = true; // Mark as merged
                    }
                }
            }
        }
    }




    public static void moveDown(int[,] board)
    {
        for (int col = 0; col < board.GetLength(1); col++)
        {
            int lastMergedRow = board.GetLength(0);

            for (int row = board.GetLength(0) - 1; row >= 0; row--)
            {
                if (board[row, col] == 0) continue;

                int currentRow = row;

                while (currentRow < board.GetLength(0) - 1 && board[currentRow + 1, col] == 0)
                {
                    board[currentRow + 1, col] = board[currentRow, col];
                    board[currentRow, col] = 0;
                    currentRow++;
                }

                if (currentRow < board.GetLength(0) - 1 && board[currentRow + 1, col] == board[currentRow, col] && currentRow + 1 < lastMergedRow)
                {
                    board[currentRow + 1, col] *= 2;
                    board[currentRow, col] = 0;
                    lastMergedRow = currentRow + 1;
                }
                else
                {
                    lastMergedRow = currentRow;
                }
            }
        }
    }

    public static int[,] parseBoard(int rows, int cols)
    {
        int[,] board = new int[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            var input = Console.ReadLine();
            var row = new List<int>();

            if (input == null) { return new int[0, 0]; }

            row = input.Trim().Split(" ").Select(int.Parse).ToList();

            for (int j = 0; j < cols; j++)
            {
                board[i, j] = row[j];
            }
        }
        return board;
    }

    public static void printBoard(int[,] board)
    {
        for (int i = 0; i < board.GetLength(0); i++)
        {
            for (int j = 0; j < board.GetLength(1); j++)
            {
                Console.Write(board[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}
