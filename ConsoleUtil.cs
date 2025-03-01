namespace BankApp;

public static class ConsoleUtil
{
    public static void WriteLine(string input, ConsoleColor color)
    {
        Console.WriteLine("");
        Console.ForegroundColor = color;
        Console.WriteLine(input);
        Console.ResetColor();
        Console.WriteLine();
    }

    public static void Write(string inputString, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.Write(inputString);
        Console.ResetColor();
    }
}
