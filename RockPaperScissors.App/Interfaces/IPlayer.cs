using static RockPaperScissors.App.Enums;

namespace RockPaperScissors.App.Interfaces
{
    public interface IPlayer
    {
        string Name { get; set; }
        Selection SelectedValue { get; set; }
    }
}
