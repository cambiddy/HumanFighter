using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace HumanFighter.Models
{
    public class Entities
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int EnemyHP { get; set; }
        public int StartHP { get; set; }



        public static void EnemyInfoDisplay(Entities enemy)
        {
            WriteLine("You are now fighting: " + enemy.Name);
            WriteLine(enemy.Description);
            WriteLine(enemy.Name + " HP: " + enemy.EnemyHP);
        }
    }
}
