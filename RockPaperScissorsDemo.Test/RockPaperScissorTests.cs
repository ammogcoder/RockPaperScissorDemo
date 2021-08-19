using NUnit.Framework;
using RockPaperScissorDemo;

namespace RockPaperScissorsDemo.Test
{

    public class RockPaperScissorTests
    {
        private RockPaperScissor _gameService;

        [SetUp]
        public void Setup()
        {
            _gameService = new RockPaperScissor();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        [TestCase("paper")]
        [TestCase("rock")]
        [TestCase("scissors")]
        public void IsGame_ProcessSuccessful(string userChoice)
        {
            var result = _gameService.ProcessGame(userChoice);

            Assert.AreEqual(true, result);
        }

        [Test]
        [TestCase("papers")]
        [TestCase("rocka")]
        [TestCase("scisss")]
        public void IsGame_ProcessFail(string userChoice)
        {
            var result = _gameService.ProcessGame(userChoice);

            Assert.IsFalse(result, $"Invalid Input{userChoice} Passed");
        }

        [Test]
        [TestCase("paper")]
        [TestCase("rock")]
        [TestCase("scissors")]
        public void CheckGameResult_WithComputerAsPaper(string userChoice)
        {
            _gameService.TestComputerChoicePaper(userChoice);

            if (userChoice == "paper") Assert.AreEqual(WinState.Draw, _gameService.GetCurrentRoundOut);
            if (userChoice == "rock") Assert.AreEqual(WinState.Loss, _gameService.GetCurrentRoundOut);
            if (userChoice == "scissors") Assert.AreEqual(WinState.Win, _gameService.GetCurrentRoundOut);
        }

        [Test]
        [TestCase("paper")]
        [TestCase("rock")]
        [TestCase("scissors")]
        public void CheckGameResult_WithComputerAsRock(string userChoice)
        {
            _gameService.TestComputerChoiceRock(userChoice);

            if (userChoice == "paper") Assert.AreEqual(WinState.Win, _gameService.GetCurrentRoundOut);
            if (userChoice == "rock") Assert.AreEqual(WinState.Draw, _gameService.GetCurrentRoundOut);
            if (userChoice == "scissors") Assert.AreEqual(WinState.Loss, _gameService.GetCurrentRoundOut);
        }

        [Test]
        [TestCase("paper")]
        [TestCase("rock")]
        [TestCase("scissors")]
        public void CheckGameResult_WithComputerAsScissors(string userChoice)
        {
            _gameService.TestComputerChoiceScissors(userChoice);

            if (userChoice == "paper") Assert.AreEqual(WinState.Loss, _gameService.GetCurrentRoundOut);
            if (userChoice == "rock") Assert.AreEqual(WinState.Win, _gameService.GetCurrentRoundOut);
            if (userChoice == "scissors") Assert.AreEqual(WinState.Draw, _gameService.GetCurrentRoundOut);
        }
    }
} 