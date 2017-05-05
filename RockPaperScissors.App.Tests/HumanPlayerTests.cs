using Microsoft.VisualStudio.TestTools.UnitTesting;
using RockPaperScissors.App.Factory;
using RockPaperScissors.App.Interfaces;
using RockPaperScissors.App.Models;
using static RockPaperScissors.App.Enums;

namespace RockPaperScissors.App.Tests
{
    [TestClass]
    public class HumanPlayerTests
    {
        HumanPlayerGenerator humanPlayerGenerator;
        ComputerPlayerGenerator computerPlayerGenerator;

        IPlayer humanPlayer;
        IPlayer computerPlayer;

        public HumanPlayerTests()
        {
            humanPlayerGenerator = new HumanPlayerGenerator();
            computerPlayerGenerator = new ComputerPlayerGenerator();
        }
        [TestMethod]
        public void ReturningHumanPlayerType()
        {
            humanPlayer = humanPlayerGenerator.GeneratePlayer();
            Assert.AreEqual(typeof(HumanPlayer), humanPlayer.GetType());
        }

        [TestMethod]
        public void NotReturningHumanPlayerType()
        {
            computerPlayer = computerPlayerGenerator.GeneratePlayer();
            Assert.AreNotEqual(typeof(HumanPlayer), computerPlayer.GetType());
        }

        [TestMethod]
        public void CheckComputerPlayerNameIsNull()
        {
            humanPlayer = humanPlayerGenerator.GeneratePlayer();
            Assert.AreEqual(humanPlayer.Name, null);
        }

        [TestMethod]
        public void CheckComputerPlayerNameIsNotNull()
        {
            var playerName = "Player1";
            humanPlayer = humanPlayerGenerator.GeneratePlayer(playerName);
            Assert.AreEqual(humanPlayer.Name, playerName);
        }

        [TestMethod]
        public void CheckComputerPlayerSelectionIsRock()
        {
            var playerName = "Player1";
            var selectedValue = Selection.Rock;
            humanPlayer = humanPlayerGenerator.GeneratePlayer(playerName, selectedValue);
            Assert.AreEqual(humanPlayer.SelectedValue, selectedValue);
        }

        [TestMethod]
        public void CheckComputerPlayerSelectionIsPaper()
        {
            var playerName = "Player1";
            var selectedValue = Selection.Paper;
            humanPlayer = humanPlayerGenerator.GeneratePlayer(playerName, selectedValue);
            Assert.AreEqual(humanPlayer.SelectedValue, selectedValue);
        }

        [TestMethod]
        public void CheckComputerPlayerSelectionIsScissors()
        {
            var playerName = "Player1";
            var selectedValue = Selection.Scissors;
            humanPlayer = humanPlayerGenerator.GeneratePlayer(playerName, selectedValue);
            Assert.AreEqual(humanPlayer.SelectedValue, selectedValue);
        }
    }
}
