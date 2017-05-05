using RockPaperScissors.App.Interfaces;
using RockPaperScissors.App.Models;
using static RockPaperScissors.App.Enums;

namespace RockPaperScissors.App.Factory
{
    public class HumanPlayerGenerator : IPlayerGenerator
    {
        public IPlayer GeneratePlayer()
        {
            var humanPlayer = new HumanPlayer();
            return humanPlayer;
        }
        public IPlayer GeneratePlayer(string name)
        {
            var humanPlayer = new HumanPlayer();
            humanPlayer.Name = name;
            return humanPlayer;
        }

        public IPlayer GeneratePlayer(string name, Selection selectedValue)
        {
            var humanPlayer = new HumanPlayer();
            humanPlayer.Name = name;
            humanPlayer.SelectedValue = selectedValue;
            return humanPlayer;
        }
    }
}
