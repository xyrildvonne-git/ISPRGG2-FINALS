using System;
using System.Collections.Generic;
using System.Linq;
using Card_Model;

namespace ConsoleApp4
{
    public class BinderSystem
    {

        public static List<BaseCard> ownedCards = new List<BaseCard>(); //storage for owned cards


        public static void AddToBinder(BaseCard card) // updates the binder for new cards
        {
            if (!ownedCards.Any(c => c.Name == card.Name))
            {
                ownedCards.Add(card);
            }
        }


        public static bool IsCardUnlocked(string cardName) // tells the printer if a card is unlocked
        {
            return ownedCards.Any(c => c.Name == cardName);
        }
    }
}