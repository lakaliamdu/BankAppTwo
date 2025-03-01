namespace BankApp;

public static class Utility
{
    public static int? SelectEnum(string screenMessage, int validStart, int validEnd)
    {
        int outValue;

        while (true)
        {
            Console.Write(screenMessage);

            bool isPasrable = int.TryParse(Console.ReadLine(), out outValue);

            if (!isPasrable)
            {
                return null;
            }

            if (!isPasrable && (outValue >= validStart) && (outValue <= validEnd))
            {
                break;
            }
        }

        return outValue;
    }
}
