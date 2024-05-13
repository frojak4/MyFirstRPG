using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstRPG
{
    internal class Fiende
    {
        public string Name;
        public int Level;
        public int Damage;
        public int HP;
        public int XPDrop;

        public Fiende(string name, int level, int damage, int hp, int xpDrop)
        {
            Name = name;
            Level = level;
            Damage = damage;
            HP = hp;
            XPDrop = xpDrop;
        }
    }
}
