namespace RockPaperScissors.App.Interfaces
{
    public interface IPlayerGenerator
    {
        IPlayer GeneratePlayer();
        IPlayer GeneratePlayer(string name);
    }
}
