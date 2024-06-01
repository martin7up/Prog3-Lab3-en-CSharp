using System.Reflection.Metadata.Ecma335;

namespace proyectoElJuegoDeLaVidaProg3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            byte x = 0,y= 0;
            string snapShot = "";
            do
            {
                 Console.Clear();
                for (byte i = 0; i < 10; i++)
                    {
                    for (byte j = 0; j < 10; j++)
                    {
                        if (i == 0 && j == 0)
                        {
                            snapShot += "#   ";
                            continue;
                        }
                        if (i == 0 && j != 0)
                        {
                            snapShot += char.ConvertFromUtf32(j + 64) + "    ";
                            continue;
                        }
                        if (i != 0 && j == 0) snapShot += "\n" + i + "   ";
                        if (i == x && j == y - 1)
                            snapShot += '1' + "    ";
                        else if (i < 10 && j < 9)
                            snapShot += "0    ";
                    }
                    snapShot += "\n";
                    }
                    Console.WriteLine(snapShot + "\n<Esc> para salir, cualquier otra tecla para continuar.");
                } while (Console.ReadKey().Key != ConsoleKey.Escape) ;
            }
    }
}
//do
//{
//    Console.Clear();
//    for (byte i = 0; i < 10; i++)
//    {
//        for (byte j = 0; j < 10; j++)
//        {
//            if (i == 0 && j == 0)
//            {
//                Console.Write("#   ");
//                continue;
//            }
//            if (i == 0 && j != 0)
//            {
//                Console.Write(char.ConvertFromUtf32(j + 64) + "    ");
//                continue;
//            }
//            if (i != 0 && j == 0) Console.Write("\n" + i + "   ");
//            if (i == x && j == y - 1)
//                Console.Write('1' + "    ");
//            else if (i < 10 && j < 9)
//                Console.Write("0    ");
//        }
//        Console.WriteLine("");
//    }
//} while (Console.ReadKey().Key != ConsoleKey.Escape);