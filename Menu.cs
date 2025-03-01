namespace BankApp;

public class Menu
{
    private readonly IAccountManager _accountManager;

    public Menu()
    {
        _accountManager = new AccountManager();
    }

    public void AccountMenu()
    {
        bool exit = false;

        while (!exit)
        {
            PrintAccountMenu();

            try
            {
                Console.Write("Enter option: ");

                if (!int.TryParse(Console.ReadLine(), out int option))
                {
                    Console.WriteLine("Invalid input. Please enter a valid number input.");
                    continue;
                }
                switch (option)
                {
                    case 0:
                        exit = true;
                        ConsoleUtil.WriteLine("Exiting application......", ConsoleColor.Green);
                        break;

                    case 1: 
                        _accountManager.AddAccount();
                        break;

                    case 2:
                        _accountManager.SearchAccountById();
                        break;

                    case 3:
                        _accountManager.SwitchAccount();
                        break;

                    case 4:
                        _accountManager.UpdateAccount();
                        break;

                    case 5:
                        _accountManager.DeleteAccount();
                        break;

                   /* case 6:
                        _accountManager.ListAllAccounts();
                        break;*/

                    default:
                        ConsoleUtil.WriteLine("Invalid operation!", ConsoleColor.Red);
                        break;


                }
            }
            catch (FormatException fe)
            {
                ConsoleUtil.WriteLine($"Invalid operation {fe.Message}", ConsoleColor.Red);
            }
        }
    }

    private static void PrintAccountMenu()
    {
        Console.WriteLine("Enter 1 to Add new account");
        Console.WriteLine("Enter 2 to search account by ID");
        Console.WriteLine("Enter 3 to switch account");
        Console.WriteLine("Enter 4 to update account");
        Console.WriteLine("Enter 5 to delete account");
        Console.WriteLine("Enter 6 to display all accounts");
        Console.WriteLine("Enter 0 to Exit");
        Console.WriteLine();
    }
}