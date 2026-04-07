namespace ConsoleApp4
{
        public abstract class GameScreen
        {
            public const string GameTitle = "Ultra Moon TCG";

            public abstract void DisplayUI();
            public abstract GameScreen ProcessInput();

            public static void InitializeScreen(string screenName)
            {
                Console.Clear();
                Console.WriteLine($"=== {GameTitle} | {screenName} ===\n");
                Console.WriteLine();
            }

            protected void PromptUser(bool isError)
            {
        {
            if (isError)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[!] Press any key to retry.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("[<] Press any key to return to main menu.");
            }
            Console.ResetColor();
            Console.ReadKey(true);
        }
    }
        }
    }


