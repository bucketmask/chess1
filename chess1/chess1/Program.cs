using System;
using System.Text;

namespace chess1
{
    class Program
    {
        static void Main(string[] args)
        {
            Genral();
            Console.ReadKey();
        }
        static void Genral()
        {
            string FEN_StartPostition = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR";
            chessBoard Board = new chessBoard(FEN_StartPostition);
            while (true)
            {
                Board.Draw();
                Console.Write("square>>>");
                string square = Console.ReadLine();
                int[] ValuesXY = Board.ConvertSquareToXY(square);
                Console.WriteLine("The Piece is a: "+Board.GetPiceFromXY(ValuesXY));
            }
        }
    }

    class chessBoard
    {
        public string[] allPices = new string[64];


        public chessBoard(string FEN)
        {
            string[] FENsplit = FEN.Split("/");
            int placeValue = 0;
            for (int line = 0; line < FENsplit.Length; line++)
            {
                for (int characterPlace = 0; characterPlace < FENsplit[line].Length; characterPlace++)
                {
                    int number;
                    if (int.TryParse(FENsplit[line][characterPlace].ToString(), out number))
                    {
                        for (int i = 0; i < number; i++)
                        {
                            allPices[placeValue] = "#";
                            placeValue++;
                        }
                    }
                    else
                    {
                        allPices[placeValue] = FENsplit[line][characterPlace].ToString();
                        placeValue++;
                    }
                }
            }
        }
        public void Draw()
        {
            int lineNumber = 1;
            Console.Write("\n_________________\n");
            for (int i = 0; i < allPices.Length; i++)
            {
                if ((i + 1) % 8 == 0)
                {
                    Console.Write("|" + allPices[i] + "|" + lineNumber.ToString() + "\n_________________\n");
                    lineNumber++;
                }
                else
                {
                    Console.Write("|" + allPices[i]);
                }
            }
            Console.WriteLine(" a b c d e f g h");
        }

        public int[] ConvertSquareToXY(string square)
        {
            int[] ValuesXY = new int[2];
            int y;
            char[] col = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
            int.TryParse(square[1].ToString(), out ValuesXY[1]);
            ValuesXY[0] = Array.IndexOf(col, square[0]) + 1;
            return ValuesXY;

        }

        public string GetPiceFromXY(int[] ValuesXY)
        {
            int Coord = ((ValuesXY[1] - 1) * 8) + ValuesXY[0];
            string piece = allPices[Coord - 1];
            return piece;
        }
    }

}
