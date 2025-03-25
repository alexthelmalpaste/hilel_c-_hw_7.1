using System;

class TicTacToe
{
    static char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
    static char currentPlayer = 'X';

    static void Main()
    {
        int moves = 0;

        while (true)
        {
            Console.Clear();
            DisplayBoard();

            Console.WriteLine($"Гравець {currentPlayer}, введіть номер клітинки:");
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int cell) && cell >= 1 && cell <= 9 && board[cell - 1] != 'X' && board[cell - 1] != 'O')
            {
                board[cell - 1] = currentPlayer;
                moves++;

                if (CheckWin())
                {
                    Console.Clear();
                    DisplayBoard();
                    Console.WriteLine($"Гравець {currentPlayer} виграв!");
                    break;
                }
                else if (moves == 9)
                {
                    Console.Clear();
                    DisplayBoard();
                    Console.WriteLine("Нічия!");
                    break;
                }

                currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
            }
            else
            {
                Console.WriteLine("Недійсний хід. Спробуйте ще раз.");
            }
        }
    }

    static void DisplayBoard()
    {
        Console.WriteLine($"{board[0]} | {board[1]} | {board[2]}");
        Console.WriteLine("--+---+--");
        Console.WriteLine($"{board[3]} | {board[4]} | {board[5]}");
        Console.WriteLine("--+---+--");
        Console.WriteLine($"{board[6]} | {board[7]} | {board[8]}");
    }

    static bool CheckWin()
    {
        int[,] winningCombinations = new int[,]
        {
            { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 }, // Горизонтальные
            { 0, 3, 6 }, { 1, 4, 7 }, { 2, 5, 8 }, // Вертикальные
            { 0, 4, 8 }, { 2, 4, 6 }              // Диагональные
        };

        for (int i = 0; i < winningCombinations.GetLength(0); i++)
        {
            if (board[winningCombinations[i, 0]] == currentPlayer &&
                board[winningCombinations[i, 1]] == currentPlayer &&
                board[winningCombinations[i, 2]] == currentPlayer)
            {
                return true;
            }
        }

        return false;
    }
}
