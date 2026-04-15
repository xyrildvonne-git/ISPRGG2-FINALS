namespace UltraMoonTCG;

public class CreditsScreen : BaseScreen
{
    public override void DisplayUI()
    {
        InitializeScreen("CREDITS");

        Console.WriteLine("Thank you so much for playing!");
        Console.WriteLine("\nGame made by:");
        Console.WriteLine("De Guzman, Kellie");
        Console.WriteLine("Layugan, Mishael");
        Console.WriteLine("Tee, Xyril");
        WriteColorLine("\n[X] Press any key to exit.", ConsoleColor.Red);

        Console.ReadKey(true);
    }

    public override ScreenResult ProcessInput()
    {
        return ScreenResult.Exit;
    }
}