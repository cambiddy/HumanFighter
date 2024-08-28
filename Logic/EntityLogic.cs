using HumanFighter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanFighter.Logic
{
    public class EntityLogic
    {
        public static Entities NewEnemy(int round)
        {
            switch (round)
            {
                case 0:
                    Entities Dog = new()
                    {
                        Name = "Dog",
                        Description = "A small fury creature. It seems weak and is emitting a strange rumbling noise from some mechanism deep within itself",
                        EnemyHP = 20,
                        StartHP = 20
                    };
                    return Dog;
                case 1:
                    Entities Cat = new()
                    {
                        Name = "Cat",
                        Description = "Another small fury creature. It seems slightly stronger than a dog and is also emitting a strange rumbling noise from some mechanism deep within itself",
                        EnemyHP = 50,
                        StartHP = 50
                    };
                    return Cat;
                case 2:
                    Entities Human0 = new()
                    {
                        Name = "Human (Timmy)",
                        Description = "A younger looking human male, probably around 4'11, it appears to be crying, yet still willing to fight.",
                        EnemyHP = 65,
                        StartHP = 65
                    };
                    return Human0;
                case 3:
                    Entities Human1 = new()
                    {
                        Name = "Human (Jerry)",
                        Description = "A (seemingly) full grown human male. He is wearing an orange baseball cap and a hockey jersey. He is 5'9 and seems to be calling you alien scum. You sense his fear. Destroy this obstacle in our great galactic cause.",
                        EnemyHP = 100,
                        StartHP = 100
                    };
                    return Human1;




                default:
                    return null;
            }

        }
    }
}