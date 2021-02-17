using iMORPHr.JellyFishTank.Contract;
using iMORPHr.JellyFishTank.Contract.Interfaces;
using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Tank g;
            //Cell c;
            Orientation o;
            string str;
            string[] size;
            int right=0, top=0, x=0, y=0;
            char orientation='A';

            Console.Write("Please enter Grid size (Width Height):");
            str = Console.ReadLine();
            if (str.Length > 100)
                Console.WriteLine("Invalid length of input");
            size = str.Split(' ');
            if (size.Length != 2)
                Console.WriteLine("Invalid size");
            if(!Int32.TryParse(size[0],out right) || !Int32.TryParse(size[1], out top))
            {
                Console.WriteLine("Invalid height or width specified");
            }
            g = new Tank(top, right);


            
            Console.Write("Please enter Grid size (Left(integer) Top(integer) Orientation(N/S/E/W)):");
            str = Console.ReadLine();
            while (str.Trim().ToLower() != "exit")
            {
                if (str.Length > 100)
                    Console.WriteLine("Invalid length of input");
                size = str.Split(' ');
                if (size.Length != 3)
                    Console.WriteLine("Invalid size");
                if (!Int32.TryParse(size[0], out x) || !Int32.TryParse(size[1], out y) || !char.TryParse(size[2], out orientation))
                {
                    if (orientation != 'N' || orientation != 'S' || orientation != 'E' || orientation != 'W')
                    {
                        Console.WriteLine("Invalid input");
                    }
                }

                //c = g.Grid[x, y];

                switch (orientation)
                {
                    case 'N':
                        o = Orientation.North;
                        break;
                    case 'S':
                        o = Orientation.South;
                        break;
                    case 'E':
                        o = Orientation.East;
                        break;
                    case 'W':
                        o = Orientation.West;
                        break;
                    default:
                        o = Orientation.North;
                        break;
                }

                IJellyFish j = g.AddJellyFish(new Coordinates(x, y), o);

                Console.Write("Please enter instructions to move (L to turn left, R to turn right, F to move forward):");
                str = Console.ReadLine();

                j.ProcessInstruction(str);


                Console.WriteLine("Output: {0} {1} {2} {3}", j.CurrentCell.Position.X, j.CurrentCell.Position.Y, j.Direction.ToString(), j.IsLost ? " LOST" : "");
                Console.Write("Please enter Grid size (Left(integer) Top(integer) Orientation(N/S/E/W)):");
                str = Console.ReadLine();
            }

            Console.ReadLine();
        }
    }
}
