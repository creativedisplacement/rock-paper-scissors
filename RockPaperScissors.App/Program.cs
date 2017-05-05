using RockPaperScissors.App.Factory;
using RockPaperScissors.App.Interfaces;
using System;
using static RockPaperScissors.App.Enums;

namespace RockPaperScissors.App
{
    public class Program
    {
        static IPlayer player1;
        static IPlayer player2;

        static IPlayerGenerator computerPlayerGenerator;
        static IPlayerGenerator humanPlayerGenerator;

        static string newLine = Environment.NewLine;
        static bool play = true;

        static void Main(string[] args)
        {
            Initialise();

            string newLine = Environment.NewLine;
            do
            {
                var selectedGameMode = ChooseGameMode();

                if (selectedGameMode == GameMode.Play)
                {
                    HumanSelection();
                }
                else
                {
                    ComputerSelection();
                }

                DisplayResult();
                PlayAgain();

            } while (play == true);
        }
        /// <summary>
        /// Setup the factories for human and computer players
        /// </summary>
        static void Initialise()
        {
            //Could be improved by using dependency injection.
            computerPlayerGenerator = new ComputerPlayerGenerator();
            humanPlayerGenerator = new HumanPlayerGenerator();
        }

        /// <summary>
        /// Allows the user to participate in a game or not
        /// </summary>
        /// <returns>GameMode</returns>
        public static GameMode ChooseGameMode()
        {
            //choose if you want to play or have the computer play each other
            Console.Write("Press 1 to play the computer, or press 2 for the computer to play itself: " + newLine);

            int gameModeSelection = 0;
            while (!Enum.IsDefined(typeof(GameMode), gameModeSelection))
            {
                int.TryParse(Console.ReadLine() + newLine, out gameModeSelection);
                if (!Enum.IsDefined(typeof(GameMode), gameModeSelection))
                {
                    Console.WriteLine("Invalid selection please select 1 to play the computer or press 2 for the computer to play itself." + newLine);
                }
            }

            GameMode selectedGameMode = (GameMode)gameModeSelection;
            Console.WriteLine("You chose to " + selectedGameMode + newLine);

            return selectedGameMode;
        }

        /// <summary>
        /// Handles the selection of the user if they have chosen to participate
        /// </summary>
        static void HumanSelection()
        {
            player1 = humanPlayerGenerator.GeneratePlayer("Player 1");
            Console.WriteLine("Please select: " + newLine);
            Console.WriteLine("1 for Rock" + newLine);
            Console.WriteLine("2 for Paper: " + newLine);
            Console.WriteLine("3 for Scissors: " + newLine);

            int weaponSelection = 0;
            while (!Enum.IsDefined(typeof(Selection), weaponSelection))
            {
                int.TryParse(Console.ReadLine() + newLine, out weaponSelection);
                if (!Enum.IsDefined(typeof(Selection), weaponSelection))
                {
                    Console.WriteLine("Invalid selection. Please select a weapon using numbers between 1 & 3." + newLine);
                }
            }

            Selection selectedWeapon = (Selection)weaponSelection;
            player1.SelectedValue = selectedWeapon;
            Console.WriteLine(player1.Name + " chose " + selectedWeapon + newLine);
        }

        /// <summary>
        /// Handles the selection of the computer if the user has chosen not to participate
        /// </summary>
        static void ComputerSelection()
        {
            player1 = computerPlayerGenerator.GeneratePlayer("Player 1");
            Console.WriteLine(player1.Name + " chose " + player1.SelectedValue + newLine);
        }

        /// <summary>
        /// Takes in the two players and calculates who the winner is
        /// </summary>
        /// <param name="player1"></param>
        /// <param name="player2"></param>
        /// <returns></returns>
        public static Result GetResult(IPlayer player1, IPlayer player2)
        {
            switch (player1.SelectedValue)
            {
                case Selection.Rock:
                    switch (player2.SelectedValue)
                    {
                        case Selection.Rock: return Result.Draw;
                        case Selection.Paper: return Result.Lose;
                        case Selection.Scissors: return Result.Win;
                        default: throw new Exception("Invalid selection detected.");
                    }
                case Selection.Paper:
                    switch (player2.SelectedValue)
                    {
                        case Selection.Rock: return Result.Win;
                        case Selection.Paper: return Result.Draw;
                        case Selection.Scissors: return Result.Lose;
                        default: throw new Exception("Invalid selection detected.");
                    }
                case Selection.Scissors:
                    switch (player2.SelectedValue)
                    {
                        case Selection.Rock: return Result.Lose;
                        case Selection.Paper: return Result.Win;
                        case Selection.Scissors: return Result.Draw;
                        default: throw new Exception("Invalid selection detected.");
                    }
                default: throw new Exception("Invalid selection detected.");
            }
        }

        /// <summary>
        /// Displays the result of the game to the winner
        /// </summary>
        static void DisplayResult()
        {
            player2 = computerPlayerGenerator.GeneratePlayer("Player 2");

            var result = GetResult(player1, player2);


            Console.WriteLine(player2.Name + " chose " + player2.SelectedValue + "." + newLine);
            Console.WriteLine(player1.Name + " " + result + "s!" + newLine);
        }

        /// <summary>
        /// Gives the user the option to play other game or quit playing
        /// </summary>
        static void PlayAgain()
        {
            Console.WriteLine("Press y to play again or any key to quit:" + newLine);

            var playAgain = Console.ReadLine();

            if (playAgain.ToLower() == "y")
            {
                play = true;
                Console.Clear();
            }
            else
            {
                play = false;
            }
        }
    }
}
