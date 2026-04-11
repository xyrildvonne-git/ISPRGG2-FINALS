using System;
using System.Collections.Generic;

namespace UltraMoonTCG
{
    public enum CardType
    {
        FIRE,
        WATER,
        GRASS
    }

    public interface ICard
    {
        string Name { get; }
    }


    public abstract class BaseCard : ICard // Battle cards
    {
        public string Name { get; set; }
        public CardType Type { get; set; }
        public int Rarity { get; set; }
        public int HP { get; set; }

        public string AttackCode { get; set; }
        public int Attack { get; set; }
        public string SpecialMove { get; set; }

        public int Index { get; set; }
        public int PullCount { get; set; }


        public virtual void PrintCard() // Deleted PrintCard class and moved to CardModel
        {
            string borderTop = "";
            string borderBottom = "";
            char sideChar = '|';

            switch (Rarity)
            {
                case 1:
                    borderTop = "+------------------+"; // Combined Top and Bottom into single line of code for easy changing later on
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

            // Card borders (fixed)
            Console.WriteLine(borderTop);
            Console.WriteLine($"{sideChar} {Name.PadRight(9)} HP:{HP.ToString().PadLeft(3)} {sideChar}");
            Console.WriteLine($"{sideChar} TYPE: {Type.ToString().PadRight(11)}{sideChar}");
            Console.WriteLine($"{sideChar} {attackName.PadRight(12)} {Attack.ToString().PadLeft(3)} {sideChar}");
            Console.WriteLine($"{sideChar} {SpecialMove.PadRight(17)}{sideChar}");
            Console.WriteLine(borderBottom);
        }

        public abstract void PullCard();
    }

    public static class GameData
    {
        public static Dictionary<string, string> AttackNames = new Dictionary<string, string> // Moved dictionary to CardModel like sir's Google Doc
        {
            { "JMS", "Jump Scare" },
            { "SFB", "Soft Block" },
            { "HPS", "Hard Pass" },
            { "DLL", "Delulu" },
            { "BRR", "Brain Rot" },
            { "MXS", "Mixed Signal" },
            { "RBD", "Rebound" },
            { "ORB", "Orbiting" },
            { "RLP", "Relapse" },
            { "GHS", "Ghosting" },
            { "HRL", "Hard Launch" },
            { "NCH", "Nonchalant" },
            { "LVB", "Love Bomb" },
            { "AUF", "Aura Farm" },
            { "TRD", "Trauma Dump" }
        };
    }


    public class FireCard : BaseCard
    {
        public override void PullCard()
        {

        }
    }

    public class WaterCard : BaseCard
    {
        public override void PullCard()
        {

        }
    }

    public class GrassCard : BaseCard
    {
        public override void PullCard()
        {

        }
    }
}
