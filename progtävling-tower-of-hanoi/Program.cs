using System;

namespace progtävling_tower_of_hanoi
{
    class Program
    {
        static int size = 3;

        static void Main(string[] args)
        {
            //Instansiera ett nytt Tower of Hanoi -spel
            TowerOfHanoi tOH = new TowerOfHanoi();

            //Sätter storlek till ovan specificerade size, detta är alltså hur många "Brick" det finns i spelet.
            tOH.SetBoardSize(size);

            int move;

            //Rita ut brädet, metoden finns längre ner i denna fil
            DrawBoard(tOH);

            //Läs in en ett "move" från spelaren medans spelet inte är uppnått.
            //Antingen så väljs en brick från det toweret som väljs av spelaren eller så läggs en brick ner på det toweret som spelaren valt om det är enligt spelreglerna.
            //Denna do-while sats kan vara intressant att ändra på om man vill ändra hur ens interface ska fungera.
            do
            {
                int.TryParse(Console.ReadLine(), out move);
                tOH.MakeMove(move);
                Console.Clear();
                DrawBoard(tOH);
            }
            while (!tOH.IsGameCompleted());
            Console.Write("YOU WIN!");
            Console.Read();
        }

        //Metod som ritar ut spelbrädet. Detta är den viktigaste metoden att ändra i om du vill uppnå visuell förändring.
        public static void DrawBoard(TowerOfHanoi tOH)
        {
            //Plockar ut "Game State" från spelet. Detta representeras av en int array av int arrayer.
            //Denna array kan exempelvis se ut såhär: [[2,1,0],[],[],[]]
            //Vilket representerar ett "Game State" som har 3 bricks på första "Tower", inga bricks på de andra två tornen och ingen "Brick" vald.
            //En spelare plockar upp första "Brick" från första "Tower", då blir det nya "Game State" [[2,1],[],[],[0]], där den minsta och översta "Brick" flyttats bort från det första "Tower".
            //Och hamnat i "selected".
            int[][] board = tOH.GetGameState();

            //Om "Selected" inte är tom, alltså att en "Brick" är vald så skrivs den ut med färg annars skrivs en tom linje ut.
            if (board[3].Length != 0)
            {
                int brick = board[3][0];
                Console.Write(brick);
            }
            Console.WriteLine();

            //En nästlad for loop som skriver ut varje rad i konsollen.
            for (int i = size; i >= 0; i--)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (i < board[j].Length)
                    {
                        int brick = board[j][i];
                        //Fylld plats i ett "Tower"
                        Console.Write(" " + brick + "  ");
                    }
                    else
                        //Tom plats i ett "Tower" som
                        Console.Write(" |  ");
                }
                Console.WriteLine();
            }
            //Grunden i spelbrädet, raden längst ner som "Towers" sticker upp ifrån
            Console.WriteLine("¯¯¯ ¯¯¯ ¯¯¯");
        }
    }
}
