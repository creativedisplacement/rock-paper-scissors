using Microsoft.VisualStudio.TestTools.UnitTesting;
using RockPaperScissors.App.Factory;
using RockPaperScissors.App.Interfaces;
using System;
using static RockPaperScissors.App.Enums;

namespace RockPaperScissors.App.Tests
{
    [TestClass]
    public class SelectionTests
    {
        IPlayer player1;
        IPlayer player2;
        Result result;
        Exception expectedException;

        public SelectionTests()
        {
            var humanGenerator = new HumanPlayerGenerator();
            player1 = humanGenerator.GeneratePlayer();
            player2 = humanGenerator.GeneratePlayer();
        }

        [TestMethod]
        public void RockVsRock()
        {
            player1.SelectedValue = Selection.Rock;
            player2.SelectedValue = Selection.Rock;

            result = Program.GetResult(player1, player2);
            Assert.AreEqual(Result.Draw, result);
        }

        [TestMethod]
        public void RockVsPaper()
        {
            player1.SelectedValue = Selection.Rock;
            player2.SelectedValue = Selection.Paper;

            result = Program.GetResult(player1, player2);
            Assert.AreEqual(Result.Lose, result);
        }

        [TestMethod]
        public void RockVsScissors()
        {
            player1.SelectedValue = Selection.Rock;
            player2.SelectedValue = Selection.Scissors;

            result = Program.GetResult(player1, player2);
            Assert.AreEqual(Result.Win, result);
        }

        [TestMethod]
        public void PaperVsRock()
        {
            player1.SelectedValue = Selection.Paper;
            player2.SelectedValue = Selection.Rock;

            result = Program.GetResult(player1, player2);
            Assert.AreEqual(Result.Win, result);
        }

        [TestMethod]
        public void PaperVsPaper()
        {
            player1.SelectedValue = Selection.Paper;
            player2.SelectedValue = Selection.Paper;

            result = Program.GetResult(player1, player2);
            Assert.AreEqual(Result.Draw, result);
        }

        [TestMethod]
        public void PaperVsScissors()
        {
            player1.SelectedValue = Selection.Paper;
            player2.SelectedValue = Selection.Scissors;

            result = Program.GetResult(player1, player2);
            Assert.AreEqual(Result.Lose, result);
        }

        [TestMethod]
        public void ScissorsVsRock()
        {
            player1.SelectedValue = Selection.Scissors;
            player2.SelectedValue = Selection.Rock;

            result = Program.GetResult(player1, player2);
            Assert.AreEqual(Result.Lose, result);
        }

        [TestMethod]
        public void ScissorsVsPaper()
        {
            player1.SelectedValue = Selection.Scissors;
            player2.SelectedValue = Selection.Paper;

            result = Program.GetResult(player1, player2);
            Assert.AreEqual(Result.Win, result);
        }

        [TestMethod]
        public void ScissorsVsScissors()
        {
            player1.SelectedValue = Selection.Scissors;
            player2.SelectedValue = Selection.Scissors;

            result = Program.GetResult(player1, player2);
            Assert.AreEqual(Result.Draw, result);
        }

        [TestMethod]
        public void NullVsNull()
        {
            try
            {
                result = Program.GetResult(player1, player2);
            }
            catch (Exception ex)
            {
                expectedException = ex;
            }
            Assert.AreEqual("Invalid selection detected.", expectedException.Message);
        }

        [TestMethod]
        public void NullVsValue()
        {
            player2.SelectedValue = Selection.Scissors;

            try
            {
                result = Program.GetResult(player1, player2);
            }
            catch (Exception ex)
            {
                expectedException = ex;
            }
            Assert.AreEqual("Invalid selection detected.", expectedException.Message);
        }

        [TestMethod]
        public void ValueVsNull()
        {
            player2.SelectedValue = Selection.Scissors;

            try
            {
                result = Program.GetResult(player1, player2);
            }
            catch (Exception ex)
            {
                expectedException = ex;
            }
            Assert.AreEqual("Invalid selection detected.", expectedException.Message);
        }
    }
}
