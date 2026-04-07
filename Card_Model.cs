using System;

namespace Card_Model
{

    public enum CardType
    {
        FIRE,
        WATER,
        GRASS
    }

    public interface ICard
    {
        string Name { get; set; }
        CardType Type { get; set; }
        int HP { get; set; }
    }

    public abstract class BaseCard : ICard  //Battle Cards
    {
        public string Name { get; set; }
        public CardType Type { get; set; }
        public int Rarity { get; set; }
        public int HP { get; set; }
        public int AttackCode { get; set; }
        public int Attack { get; set; }
        public string SpecialMove { get; set; }

        public abstract void DisplayCard();
        public abstract void PullCard();

    }

    public class FireCard : BaseCard
    {
        public override void DisplayCard()
        {

        }

        public override void PullCard()
        {

        }
    }

    public class WaterCard : BaseCard
    {
        public override void DisplayCard()
        {

        }

        public override void PullCard()
        {

        }
    }

    public class GrassCard : BaseCard
    {
        public override void DisplayCard()
        {

        }

        public override void PullCard()
        {

        }
    }

}
