using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4
{
    internal class Card_Model
    {

        public abstract class Card
        {
            public string Name { get; set; }
            public string Type { get; set; }
            public int HP { get; set; }
            public int AttackDamage { get; set; }
            public int Rarity { get; set; }
            public string SpecialMove { get; set; }

            public abstract void DisplayCard();
            public abstract void PullCard();

        }

    }
}

