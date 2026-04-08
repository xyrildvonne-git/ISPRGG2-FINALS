namespace UltraMoonTCG
{
    public enum CardType
    {
        FIRE,
        WATER,
        GRASS
    }

    public enum CardIndex
    {

    }

    public interface ICard
    {
        string Name { get; }
    }

    public abstract class BaseCard : ICard  // Battle Cards
    {
        public string Name { get; init; } 
        public CardType Type { get; init; }
        public int Rarity { get; init; }
        public int HP { get; init; }
        public int AttackCode { get; init; }
        public int Attack { get; init; }
        public string SpecialMove { get; init; }

        public abstract void PrintCard();
        public abstract void PullCard();
    };

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
                    borderTop = borderBottom = "+------------------+"; // Combined Top and Bottom into single line of code for easy changing later on
                    sideChar = '|';
                    break;

                case 2:
                    borderTop = borderBottom = "+==================+";
                    sideChar = '|';
                    break;

                case 3:
                    borderTop = borderBottom = "********************";
                    sideChar = '*';
                    break;

                case 4:
                    borderTop = borderBottom = "@@@@@@@@@@@@@@@@@@@@";
                    sideChar = '@';
                    break;

                case 5:
                    borderTop = borderBottom = "####################";
                    sideChar = '#';
                    break;
            }

            string attackName = GameData.AttackNames.ContainsKey(AttackCode)
                ? GameData.AttackNames[AttackCode]
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

    public class FireCard : BaseCard
    {
        public override void PrintCard()
        {

        }

        public override void PullCard()
        {

        }
    }

    public class WaterCard : BaseCard
    {
        public override void PrintCard()
        {

        }

        public override void PullCard()
        {

        }
    }

    public class GrassCard : BaseCard
    {
        public override void PrintCard()
        {

        }

        public override void PullCard()
        {

        }
    }

}
