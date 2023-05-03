using System;

class TicTacToe
{
    static void Main(string[] args)
    {
        char[,] board = new char[3, 3] { { '-', '-', '-' }, { '-', '-', '-' }, { '-', '-', '-' } };

        char currentPlayer = 'X';
        bool gameOver = false;
        int moveCount = 0;

        Console.WriteLine("Let's play Tic Tac Toe!");

        while (!gameOver)
        {
            DrawBoard(board);
            Console.WriteLine($"It's player {currentPlayer}'s turn.");
            Console.Write("Enter row (0-2): ");
            int row = int.Parse(Console.ReadLine());
            Console.Write("Enter column (0-2): ");
            int col = int.Parse(Console.ReadLine());

            if (board[row, col] == '-')
            {
                board[row, col] = currentPlayer;
                moveCount++;

                if (CheckWin(board, currentPlayer))
                {
                    Console.WriteLine($"Player {currentPlayer} wins!");
                    gameOver = true;
                }
                else if (moveCount == 9)
                {
                    Console.WriteLine("It's a tie!");
                    gameOver = true;
                }
                else
                {
                    currentPlayer = currentPlayer == 'X' ? 'O' : 'X';
                }
            }
            else
            {
                Console.WriteLine("That spot is already taken. Try again.");
            }
        }

        DrawBoard(board);
        Console.WriteLine("Game over.");
    }

    static void DrawBoard(char[,] board)
    {
        Console.WriteLine("   0  1  2");
        for (int row = 0; row < 3; row++)
        {
            Console.Write($"{row} ");
            for (int col = 0; col < 3; col++)
            {
                Console.Write($" {board[row, col]} ");
                if (col < 2)
                {
                    Console.Write("|");
                }
            }
            Console.WriteLine();
            if (row < 2)
            {
                Console.WriteLine("  -----------");
            }
        }
    }

    static bool CheckWin(char[,] board, char player)
    {
        for (int row = 0; row < 3; row++)
        {
            if (board[row, 0] == player && board[row, 1] == player && board[row, 2] == player)
            {
                return true;
            }
        }


        for (int col = 0; col < 3; col++)
        {
            if (board[0, col] == player && board[1, col] == player && board[2, col] == player)
            {
                return true;
            }
        }

        if (board[0, 0] == player && board[1, 1] == player && board[2, 2] == player)
        {
            return true;
        }

        if (board[0, 2] == player && board[1, 1] == player && board[2, 0] == player)
        {
            return true;
        }

        return false;
    }
}
