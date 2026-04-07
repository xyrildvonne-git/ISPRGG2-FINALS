using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4
{
    public class CardPrint
    {
        public string Name;
        public CardType Type;
        public int HP;
        public string AttackCode;
        public int Attack;
        public int Rarity;
        public string SpecialMove;
        public void PrintCard()
        {
            string borderTop = "";
            string borderBottom = "";
            char sideChar = '|';

            switch (Rarity)
            {
                case 1:
                    borderTop = "+------------------+";
                    borderBottom = "+------------------+";
                    sideChar = '|';
                    break;

                case 2:
                    borderTop = "+==================+";
                    borderBottom = "+==================+";
                    sideChar = '|';
                    break;

                case 3:
                    borderTop = "********************";
                    borderBottom = "********************";
                    sideChar = '*';
                    break;

                case 4:
                    borderTop = "@@@@@@@@@@@@@@@@@@@@";
                    borderBottom = "@@@@@@@@@@@@@@@@@@@@";
                    sideChar = '@';
                    break;

                case 5:
                    borderTop = "####################";
                    borderBottom = "####################";
                    sideChar = '#';
                    break;
            }

            string attackName = Program.AttackNames.ContainsKey(AttackCode)
                ? Program.AttackNames[AttackCode]
                : AttackCode;

           //Still working on this, trying to make the cards look cleaner pa
            Console.WriteLine(borderTop);
            Console.WriteLine($"{sideChar} {Name.PadRight(10)} HP:{HP.ToString().PadLeft(3)} {sideChar}");
            Console.WriteLine($"{sideChar} TYPE: {Type.ToString().PadRight(11)}{sideChar}");
            Console.WriteLine($"{sideChar} {attackName.PadRight(12)} {Attack.ToString().PadLeft(3)} {sideChar}");
            Console.WriteLine($"{sideChar} {SpecialMove.PadRight(16)}{sideChar}");
            Console.WriteLine(borderBottom);
        }
    }
}
