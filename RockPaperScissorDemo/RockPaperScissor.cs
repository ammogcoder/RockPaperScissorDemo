using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorDemo
{
    public enum WinState
    {
        Win,
        Loss,
        Draw
    }
    public class RockPaperScissor
    {
        public int HumanWin { get; set; } = 0;
        public int ComputerWin { get; set; } = 0;
        WinState CurrentRoundOut = WinState.Draw;

        public string Info = "";
        public void ResetCycle()
        {
            HumanWin = 0;
            ComputerWin = 0;
            CurrentRoundOut = WinState.Draw;
            Info = "";
        }
        public bool ProcessGame(string userChoice)
        {
            if (userChoice.ToLower().Equals("rock") || userChoice.ToLower().Equals("paper") || userChoice.ToLower().Equals("scissors"))
            {
                string ComputerChoice = "";
                Random r = new Random();
                int computerChoice = r.Next(1, 4);
                if (computerChoice < 1) computerChoice = 1;

                switch (computerChoice)
                {
                    case 1:
                        ComputerChoice = "paper";
                        break;
                    case 2:
                        ComputerChoice = "rock";
                        break;
                    case 3:
                        ComputerChoice = "scissors";
                        break;
                    default:
                        break;
                }

                if (ComputerChoice.ToLower() == "paper")
                    ComputerChoicePaper(userChoice);
                else if (ComputerChoice.ToLower() == "rock")
                    ComputerChoiceRock(userChoice);
                else if (ComputerChoice.ToLower() == "scissors")
                    ComputerChoiceScissors(userChoice);

                Info = $"\nComputer Choice: {ComputerChoice}, Your Choice: {userChoice}\n";
                Info += (CurrentRoundOut == WinState.Win) ? "You Won" : ((CurrentRoundOut == WinState.Loss) ? "Computer Won" : "A draw match");

                if (CurrentRoundOut == WinState.Win)
                    HumanWin += 1;
                else if (CurrentRoundOut == WinState.Loss)
                    ComputerWin += 1;

                return true;
            }
            else {
                Info = "\nInvalid Input !!!please enter valid input, rock paper scissors";
                return false;
            }
        }


        void ComputerChoicePaper(string userSelection)
        {
            CurrentRoundOut = WinState.Draw;
            if (userSelection.Equals("scissors"))
            {
                CurrentRoundOut = WinState.Win;
            }
            else if (userSelection.Equals("rock"))
            {
                CurrentRoundOut = WinState.Loss;
            }
        }
        void ComputerChoiceRock(string userSelection)
        {
            CurrentRoundOut = WinState.Draw;
            if (userSelection.Equals("scissors"))
            {
                CurrentRoundOut = WinState.Loss;
            }
            else if (userSelection.Equals("paper"))
            {
                CurrentRoundOut = WinState.Win;
            }
        }
        void ComputerChoiceScissors(string userSelection)
        {
            CurrentRoundOut = WinState.Draw;
            if (userSelection.Equals("rock"))
            {
                CurrentRoundOut = WinState.Win;
            }
            else if (userSelection.Equals("paper"))
            {
                CurrentRoundOut = WinState.Loss;
            }
        }

        public void TestComputerChoicePaper(string userSelection) => ComputerChoicePaper(userSelection);
        public void TestComputerChoiceRock(string userSelection) => ComputerChoiceRock(userSelection);
        public void TestComputerChoiceScissors(string userSelection) => ComputerChoiceScissors(userSelection);

        public WinState GetCurrentRoundOut  => CurrentRoundOut; 
    }
}
