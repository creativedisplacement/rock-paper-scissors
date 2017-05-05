using Microsoft.VisualStudio.TestTools.UnitTesting;
using RockPaperScissors.App.Factory;
using RockPaperScissors.App.Interfaces;
using RockPaperScissors.App.Models;
using static RockPaperScissors.App.Enums;

namespace RockPaperScissors.App.Tests
{
    [TestClass]
    public class ComputerPlayerTests
    {
        HumanPlayerGenerator humanPlayerGenerator;
        ComputerPlayerGenerator computerPlayerGenerator;

        IPlayer humanPlayer;
        IPlayer computerPlayer;

        public ComputerPlayerTests()
        {
            humanPlayerGenerator = new HumanPlayerGenerator();
            computerPlayerGenerator = new ComputerPlayerGenerator();
        }

        [TestMethod]
        public void ReturningComputerPlayerType()
        {
            computerPlayer = computerPlayerGenerator.GeneratePlayer();
            Assert.AreEqual(typeof(ComputerPlayer), computerPlayer.GetType());
        }

        [TestMethod]
        public void NotReturningComputerPlayerType()
        {
            humanPlayer = humanPlayerGenerator.GeneratePlayer();
            Assert.AreNotEqual(typeof(ComputerPlayer), humanPlayer.GetType());
        }

        [TestMethod]
        public void CheckComputerPlayerNameIsNull()
        {
            computerPlayer = computerPlayerGenerator.GeneratePlayer();
            Assert.AreEqual(computerPlayer.Name, null);
        }

        [TestMethod]
        public void CheckComputerPlayerNameIsNotNull()
        {
            var playerName = "Computer Player 1";
            computerPlayer = computerPlayerGenerator.GeneratePlayer(playerName);
            Assert.AreEqual(computerPlayer.Name, playerName);
        }

        [TestMethod]
        public void CheckComputerPlayerSelectionIsValid()
        {
            var playerName = "Computer Player 1";
            computerPlayer = computerPlayerGenerator.GeneratePlayer(playerName);
            Assert.AreEqual(typeof(Selection), computerPlayer.SelectedValue.GetType());
        }
    }
}
