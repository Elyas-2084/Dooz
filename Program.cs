using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dooz
{
    class Program
    {
        static char[,] board = new char[3, 3];
        static char firstplayer = 'X';

        static void Main(string[] args)
        {
            //قسمت پایان بازی
            Board();
            PlayGame();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Game over...");
        }

        static void Board()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = ' ';
                }
            }
        }

        static void PlayGame()
        {
            bool gameEnded = false;

            while (!gameEnded)
            {
                // عنوان های بازی 
                Console.Clear();
                DisplayBoard();

                Console.WriteLine("Player {0} turn. Enter row number (0-2):", firstplayer);
                int row = Input();

                Console.WriteLine("Enter column number (0-2):");
                int col = Input();

                if (board[row, col] != ' ')
                {
                    Console.WriteLine("This cell is already taken. Press any key to try again...");
                    Console.ReadKey();
                    continue;
                }

                board[row, col] = firstplayer;

                if (Checkgame())
                {//قسمت چک کردن بازی
                    Console.Clear();
                    DisplayBoard();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Player {0} wins!", firstplayer);
                    gameEnded = true;
                }
                else if (IsBoardFull())
                {
                    Console.Clear();
                    DisplayBoard();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("It's a Full!");
                    gameEnded = true;
                }
                else
                {
                    SwitchPlayer();
                }
            }
        }

        static int Input()
        {
            int num;
            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out num) && num >= 0 && num <= 2)
                {
                    return num;
                }
                else
                {
                    Console.WriteLine("Invalid input! Please enter  number between 0 and 2:");
                }
            }
        }

        static void DisplayBoard()
        {
            //قسمت صفحه بازی
            Console.WriteLine("_____________");
            for (int i = 0; i < 3; i++)
            {
                Console.Write("| ");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(board[i, j] + " | ");
                }
                Console.WriteLine();
                Console.WriteLine("_____________");
            }
        }

        static void SwitchPlayer()
        {
            firstplayer = (firstplayer == 'X') ? 'O' : 'X';
        }

        static bool IsBoardFull()
        {
            foreach (char cell in board)
            {
                if (cell == ' ')
                    return false;
            }
            return true;
        }

        static bool Checkgame()
        {
            // بررسی ردیفها
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] == firstplayer && board[i, 1] == firstplayer && board[i, 2] == firstplayer)
                    return true;
            }

            // بررسی ستون ها 
            for (int i = 0; i < 3; i++)
            {
                if (board[0, i] == firstplayer && board[1, i] == firstplayer && board[2, i] == firstplayer)
                    return true;
            }

            // بررسی قطرهای اصلی
            if (board[0, 0] == firstplayer && board[1, 1] == firstplayer && board[2, 2] == firstplayer)
                return true;

            // بررسی قطرهای فرعی  
            if (board[0, 2] == firstplayer && board[1, 1] == firstplayer && board[2, 0] == firstplayer)
                return true;

            return false;
        }
    }
}

