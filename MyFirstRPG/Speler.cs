using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstRPG
{
    internal class Speler
    {
        public string Name;
        public int Level;
        public int HP;
        public int XP;

        public int Damage;
        public int Potions;

        public Speler(string name, int level, int hp, int xp, int damage, int potions)
        {
            Name = name;
            Level = level;
            HP = hp;
            XP = xp;
            Damage = damage;
            Potions = potions;
        }
    }
}
