using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure.Game_Logic
{
    /// <summary>
    /// The game logic class.
    /// </summary>
    public class GameLogic
    {
        public string PlayerName;
        public Gender Gender;

        public GameLogic(string playerName, Gender gender)
        {
            PlayerName = playerName;
            Gender = gender;
        }

        public GameLogic()
        {
            // This hsould show up in the source control
        }
    }

    public enum Gender
    {
        Male, Female, NonBinary
    }
}
