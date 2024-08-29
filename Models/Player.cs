using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace HumanFighter.Models
{
    public class Player
    {
        public string UserName { get; set; } = string.Empty;

        public int UserHP { get; set; }

        public int UserMP { get; set; }

        public static void PlayerInfoDisplay(Player player)
        {

            WriteLine(player.UserName);
            WriteLine("HP: " + player.UserHP);
            WriteLine("MP: " + player.UserMP);

        }

    }
}
