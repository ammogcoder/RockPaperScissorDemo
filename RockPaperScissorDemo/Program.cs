using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorDemo
{
    class Program
    {
        static void Main(string[] args)
        {
                RockPaperScissor gamer = new RockPaperScissor();
                bool ContinuePlaying = false;
                int gameRound = 0;
                do
                {
                    //Game round
                    gamer.ResetCycle();
                    Console.WriteLine("\n==================New Round====================");
                    gameRound = 1;

                    do
                    {
                        Console.WriteLine($"\n-----Round {gameRound.ToString()}-------");
                        Console.WriteLine("\nType Rock, Paper or Scisssors?");
                        string userChoice = Console.ReadLine();
                        bool res = gamer.ProcessGame(userChoice);
                        if (res)
                        {
                            Console.WriteLine(gamer.Info);
                            gameRound += 1;
                        }
                        else
                        {
                            Console.WriteLine(gamer.Info);
                        }
                    } while (gameRound < 4);

                    Console.WriteLine("\n-------Summary-------");

                    //style the color for display
                    if (gamer.HumanWin > gamer.ComputerWin)
                        Console.ForegroundColor = ConsoleColor.Blue;
                    else if (gamer.HumanWin < gamer.ComputerWin)
                        Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine((gamer.HumanWin == gamer.ComputerWin) ? "Draw Match" : ((gamer.HumanWin > gamer.ComputerWin) ? "You Won" : "Computer Won"));
                    Console.ResetColor();

                    Console.WriteLine("\nDo you  want to Play another Round? y/n ");
                    var enteredk = Console.ReadKey();
                    ContinuePlaying = enteredk.Key.ToString().ToLower() == "y";

                } while (ContinuePlaying);
         }
    }
}
