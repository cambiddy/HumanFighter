using HumanFighter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace HumanFighter.Logic
{
    public class Actions
    {
        public static int Heal(int entityHP, string entityName)
        {
            int healFor = DiceRoll(entityName);
            
            WriteLine($"{entityName} Has healed for {healFor} HP!");
            return entityHP + healFor;
        }

        public static int Attack(int attackedHP, string attackerName, string attackedName)
        {
            int attackFor = DiceRoll(attackerName);
            WriteLine($"{attackerName} Has attacked {attackedName} for {attackFor} HP!");
            return attackedHP - attackFor;
        }
        public static int ManaAttack(int attackedHP, string attackerName, string attackedName, int availableMP, Player player)
        {
            int attackFor = (int)(DiceRoll(attackerName) * 1.2);
            if (availableMP > (int)(attackFor / 1.2))
            {

                WriteLine($"{attackerName} has Mana attacked {attackedName} for {attackFor} HP, and has lost {(int)(attackFor / 1.2)} Mana Points!");
                player.UserMP = player.UserMP - (int)(attackFor / 1.2);
                return attackedHP - attackFor;
            }
            else if (availableMP == 0)
            {
                WriteLine("Sorry, you don't have enough mana points! initiating a regular attack!");
                return Attack(attackedHP, attackerName, attackedName);
            }
            else
            {
                int tempMP = availableMP;
                player.UserMP = 0;
                WriteLine($"{attackerName} has Mana attacked {attackedName} for {attackFor} HP, and has lost all of their remaining Mana Points!");
                return attackedHP - (int)(tempMP * 1.2);
            }
        }
        public static int DiceRoll(string nameOfRoller)
        {
            int diceValue = 0;
            Random rand1 = new();
            Random rand2 = new();
            int Die1 = rand1.Next(1, 13);
            int Die2 = rand2.Next(1, 13);
            if (Die1 == Die2)
            {
                diceValue = (Die1 + Die2) * 2;
            }
            else

            {
                diceValue = Die1 + Die2;
            }
            WriteLine($"{nameOfRoller} rolled a {Die1}");
            WriteLine($"And a {Die2}");
            return diceValue;

        }

    }
}
