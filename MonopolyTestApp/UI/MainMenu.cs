namespace Test.UI;

public static class MainMenu
{
    public const string ProgramExitKey = "E";

    public static void MainMenuRender()
    {
        Console.WriteLine("Любой ввод для повтора;");
        Console.WriteLine($"{ProgramExitKey} - Выход.");
    }
}