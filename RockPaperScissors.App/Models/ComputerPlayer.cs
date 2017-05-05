using RockPaperScissors.App.Interfaces;
using System;
using static RockPaperScissors.App.Enums;

namespace RockPaperScissors.App.Models
{
    public class ComputerPlayer : IPlayer
    {
        public ComputerPlayer()
        {
            var values = Enum.GetValues(typeof(Selection));
            Random random = new Random();
            var randomValue = (Selection)values.GetValue(random.Next(values.Length));
            this.SelectedValue = randomValue;
        }
        public string Name { get; set; }
        public Selection SelectedValue { get; set; }
    }
}
