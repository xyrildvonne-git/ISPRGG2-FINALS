namespace UltraMoonTCG;

public class BinderPrinter()
{
    public static void DisplayBinder()
    {
        Console.WriteLine("+---------------------------------------------------------------------+");

        for (int i = 0; i < 15; i += 5)
        {
            Console.Write("| ");

            for (int j = 1; j <= 5; j++)
            {
                int index = i + j;
                BaseCard card = Program.allCards.FirstOrDefault(c => c.Index == index);

                string display;

                if (card != null && card.PullCount > 0)
                {
                    display = card.Name;
                }
                else
                {
                    display = $"#{index:000}";
                }

                Console.Write(display.PadRight(12));
                Console.Write("| ");
            }

            Console.WriteLine();
            Console.WriteLine("+---------------------------------------------------------------------+");
        }
    }
}