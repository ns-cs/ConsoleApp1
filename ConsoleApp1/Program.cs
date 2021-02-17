using iMORPHr.JellyFishTank.Contract;
using iMORPHr.JellyFishTank.Contract.Interfaces;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Tank tank = null;
            Orientation direction;
            string userInput;
            string[] userInputTokens;
            int right = 0, top = 0, x = 0, y = 0;
            char orientation = 'N';

            Console.Write("Please enter Grid Max Coordinates (X Y):");
            userInput = Console.ReadLine();
            if (userInput.Length > 100)
                Console.WriteLine("Invalid length of input");
            userInputTokens = userInput.Split(' ');
            if (userInputTokens.Length != 2)
                Console.WriteLine("Invalid size");
            if(!Int32.TryParse(userInputTokens[0],out right) || !Int32.TryParse(userInputTokens[1], out top))
            {
                Console.WriteLine("Invalid max coordinates specified");
            }

            try
            {
                tank = new Tank(top, right);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            if (tank != null)
            {

                Console.Write("Please enter Grid size (Left(integer) Top(integer) Orientation(N/S/E/W)):");
                userInput = Console.ReadLine();
                while (userInput.Trim().ToLower() != "exit")
                {
                    if (userInput.Length > 100)
                        Console.WriteLine("Invalid length of input");
                    userInputTokens = userInput.Split(' ');
                    if (userInputTokens.Length != 3)
                        Console.WriteLine("Invalid size");
                    if (!Int32.TryParse(userInputTokens[0], out x) || !Int32.TryParse(userInputTokens[1], out y) || !char.TryParse(userInputTokens[2], out orientation))
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
                            direction = Orientation.North;
                            break;
                        case 'S':
                            direction = Orientation.South;
                            break;
                        case 'E':
                            direction = Orientation.East;
                            break;
                        case 'W':
                            direction = Orientation.West;
                            break;
                        default:
                            direction = Orientation.North;
                            break;
                    }

                    IJellyFish j = tank.AddJellyFish(new Coordinates(x, y), direction);

                    Console.Write("Please enter instructions to move (L to turn left, R to turn right, F to move forward):");
                    userInput = Console.ReadLine();

                    j.ProcessInstruction(userInput);


                    Console.WriteLine("Output: {0} {1} {2} {3}", j.CurrentCell.Position.X, j.CurrentCell.Position.Y, j.Direction.ToString(), j.IsLost ? " LOST" : "");
                    Console.Write("Please enter Grid size (Left(integer) Top(integer) Orientation(N/S/E/W)):");
                    userInput = Console.ReadLine();
                }
            }
            Console.ReadLine();
        }
    }
}
