using RockPaperScissors.App.Interfaces;
using static RockPaperScissors.App.Enums;

namespace RockPaperScissors.App.Models
{
    public class HumanPlayer : IPlayer
    {
        public string Name { get; set; }
        public Selection SelectedValue { get; set; }
    }
}
