using System;

namespace progtävling_tower_of_hanoi
{
    class Program
    {
        static int size = 3;
        static ConsoleColor defCol = ConsoleColor.White;
        static ConsoleColor[] colors = new ConsoleColor[] { ConsoleColor.Red, ConsoleColor.Cyan, ConsoleColor.Green, ConsoleColor.Yellow, ConsoleColor.Magenta };

        static void Main(string[] args)
        {
            TowerOfHanoi tOH = new TowerOfHanoi();
            tOH.SetBoardSize(size);
            int move;
            DrawBoard(tOH);
            do
            {
                int.TryParse(Console.ReadLine(), out move);
                tOH.MakeMove(move);
                Console.Clear();
                DrawBoard(tOH);
            }
            while (!tOH.IsGameCompleted());
            WriteColoured("YOU WIN!", ConsoleColor.DarkYellow);
            Console.Read();
        }

        public static void DrawBoard(TowerOfHanoi tOH)
        {
            int[][] board = tOH.GetGameState();
            if (board[3].Length != 0)
            {
                int brick = board[3][0];
                WriteColoured(brick.ToString(), colors[brick]);
            }
            Console.WriteLine();

            for (int i = size; i >= 0; i--)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (i < board[j].Length)
                    {
                        int brick = board[j][i];
                        WriteColoured(" " + brick + "  ", colors[brick]);
                    }
                    else
                        Console.Write(" |  ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("¯¯¯ ¯¯¯ ¯¯¯");
        }

        /// <summary>
        /// Skriver ut en text i given färg och återställer därefter consolens standardfärg.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="color"></param>
        public static void WriteColoured(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ForegroundColor = defCol;
        }
    }
}
