namespace BankApp;

public static class ConsoleUtil
{
    public static void WriteLine(string input, ConsoleColor color)
    {
        ConsoleUtil.WriteLine();
        Console.ForegroundColor = color;
        ConsoleUtil.WriteLine(input);
        Console.ResetColor();
        ConsoleUtil.WriteLine();
    }

    public static void Write(string inputString, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.Write(inputString);
        Console.ResetColor();
    }
}