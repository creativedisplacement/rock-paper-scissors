using RockPaperScissors.App.Interfaces;
using RockPaperScissors.App.Models;

namespace RockPaperScissors.App.Factory
{
    public class ComputerPlayerGenerator : IPlayerGenerator
    {
        public IPlayer GeneratePlayer()
        {
            var computerPlayer = new ComputerPlayer();
            return computerPlayer;
        }

        public IPlayer GeneratePlayer(string name)
        {
            var computerPlayer = new ComputerPlayer();
            computerPlayer.Name = name;
            return computerPlayer;
        }
    }
}
