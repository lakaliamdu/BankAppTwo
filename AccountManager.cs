namespace BankApp;

using System;
using System.Text.RegularExpressions;
using ConsoleTables;

public class AccountManager : IAccountManager
{
    private readonly List<Account> Accounts;

    public AccountManager()
    {
        Accounts = [];
    }

    public Account AddAccountRequest()
    {
        Account account = new();

        Console.Write("Enter first name: ");
        account.FirstName = Console.ReadLine()!;

        Console.Write("Enter last name: ");
        account.LastName = Console.ReadLine()!;

        Console.Write("Enter middle name: ");
        account.MiddleName = Console.ReadLine()!;

        Console.Write("Enter phone number: ");
        account.MobileNumber = Console.ReadLine()!;

        Console.Write("Enter Email: ");
        account.Email = Console.ReadLine()!;

        Console.Write("Enter date of birth: ");
        account.DateOfBirth = Console.ReadLine()!;

        Console.Write("Enter Gender: ");
        account.Gender = Console.ReadLine()!;

        Console.Write("Enter password, not less than six characters: ");
        CheckPassword(account.Password);
        account.Password = Console.ReadLine()!;

        if (account.Password.Length != 6)
        {
            Console.WriteLine("Invalid Password, please try again ");
            return account;
        }
        Console.Write("Enter marital status: ");
        account.MaritalStatus = Console.ReadLine()!;
        return account;
    }

    public void AddAccount()
    {
        int id = Accounts.Count > 0 ? Accounts.Count + 1 : 1;
        var accountRequest = AddAccountRequest();

        var account = new Account
        {
            Id = id,
            FirstName = accountRequest.FirstName,
            LastName = accountRequest.LastName,
            MiddleName = accountRequest.MiddleName,
            MobileNumber = accountRequest.MobileNumber,
            Email = accountRequest.Email,
            DateOfBirth = accountRequest.DateOfBirth,
            Gender = accountRequest.Gender,
            Password = accountRequest.Password,
            MaritalStatus = accountRequest.MaritalStatus,
            CreatedAt = DateTime.Today,
        };

        Accounts.Add(account);
        ConsoleUtil.WriteLine(
            $"Account with name {account.FirstName} and id {account.Id} created sucessfully!",
            ConsoleColor.Green
        );
    }

    /*  public void SearchAccountById()
      {
          Console.Write("Enter the ID of account: ");
          int id = int.Parse(Console.ReadLine()!);
          var account = Accounts.Find(x => x.Id == id);

          if (account is null)
          {
              Console.WriteLine("Account does not exist!");
              return;
          }

          var result = $"""
          ======ACCOUNT DETAILS======
          FirstName: {account.FirstName}
          LastName: {account.LastName}
          MiddleName: {account.MiddleName}
          MobileNumber: {account.MobileNumber}
          Email: {account.Email ?? "N/A"}
          DateOfBirth: {account.DateOfBirth}
          Gender: {account.Gender}
          MaritalStatus: {account.MaritalStatus}
          """;

          Console.WriteLine(result);
          Console.WriteLine();

      }*/
    public void SwitchAccount()
    {
        Console.Write("Enter the Id of the account you want to switch to: ");
        int id = int.Parse(Console.ReadLine()!);
        var account = Accounts.Find(x => x.Id == id);
        if (account is null)
        {
            Console.WriteLine("The account you are trying switch to does exist!");
            return;
        }
        var result = $"""
            ======ACCOUNT DETAILS=====
            FirstName: {account.FirstName}
            LastName: {account.LastName}
            MiddleName: {account.MiddleName}
            MobileNumber: {account.MobileNumber}
            Email: {account.Email ?? "N/A"}
            DateOfBirth: {account.DateOfBirth}
            Gender: {account.Gender}
            MaritalStatus: {account.MaritalStatus}
            """;

        Console.WriteLine(result);
        Console.WriteLine();
    }

    public void DeleteAccount()
    {
        try
        {
            Console.Write("Enter the ID of the account: ");
            int id = int.Parse(Console.ReadLine()!);
            var account = Accounts.Find(x => x.Id == id);

            if (account is null)
            {
                ConsoleUtil.WriteLine(
                    "Account you are trying to delete does not exist!",
                    ConsoleColor.Red
                );
                return;
            }

            bool isRemoved = Accounts.Remove(account);

            string result = isRemoved
                ? "Account removed successfully!"
                : "Unable to remove account!";
            ConsoleUtil.WriteLine(result, ConsoleColor.Green);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occured: {ex.Message}", ConsoleColor.Red);
        }
    }

    public void ListAllAccounts()
    {
        if (Accounts.Count == 0)
        {
            ConsoleUtil.WriteLine(
                "There is no account in the record yet.! Add a new account",
                ConsoleColor.Cyan
            );
            return;
        }
        ConsoleTable table = new(
            "ID",
            "FirstName",
            "LastName",
            "MiddleName",
            "MobileNumber",
            "Email",
            "DateOfBirth",
            "Gender",
            "CreatedAt",
            "ModifiedAt"
        );

        foreach (var account in Accounts)
        {
            table.AddRow(
                account.Id,
                account.FirstName,
                account.LastName,
                account.MiddleName,
                account.MobileNumber,
                account.Email,
                account.DateOfBirth,
                account.Gender,
                account.CreatedAt.ToString("dd MMM, yyyy"),
                account.ModifiedAt.HasValue
                    ? account.ModifiedAt?.ToString("dd MMM, yyyy h:mm:ss")
                    : "N/A"
            );
        }

        Console.WriteLine();
        table.Write(Format.Alternative);
        Console.WriteLine();
    }

    public void UpdateAccount()
    {
        try
        {
            Console.Write("Enter the ID of the accounr: ");
            int id = int.Parse(Console.ReadLine()!);

            var account = Accounts.Find(x => x.Id == id);

            if (account is null)
            {
                Console.WriteLine("Account you are trying to edit does not exist!");
                return;
            }
            bool isRecordUpdated = false;

            Console.Write("Enter account first name: ");
            string firstName = Console.ReadLine()!;

            if (!string.IsNullOrWhiteSpace(firstName))
            {
                ValidateAccountFisrtName(firstName);
                account.FirstName = firstName;
                isRecordUpdated = true;
            }

            Console.Write("Enter last name: ");
            string lastName = Console.ReadLine()!;

            if (!string.IsNullOrWhiteSpace(lastName))
            {
                ValidateAccountLastName(lastName);
                account.LastName = lastName;
                isRecordUpdated = true;
            }

            Console.Write("Enter middle name: ");
            string middleName = Console.ReadLine()!;

            if (!string.IsNullOrWhiteSpace(middleName))
            {
                ValidateAccountMiddleName(middleName);
                account.MiddleName = middleName;
                isRecordUpdated = true;
            }

            Console.Write("Enter phone number: ");
            string mobileNumber = Console.ReadLine()!;

            if (!string.IsNullOrWhiteSpace(mobileNumber))
            {
                ValidateAccountMobileNumber(mobileNumber);
                account.MobileNumber = mobileNumber;
                isRecordUpdated = true;
            }

            Console.Write("Enter email: ");
            string email = Console.ReadLine()!;

            if (!string.IsNullOrWhiteSpace(email))
            {
                ValidateAccountEmail(email);
                account.Email = email;
                isRecordUpdated = true;
            }

            Console.Write("Enter date of birth: ");
            string dateOfBirth = Console.ReadLine()!;

            if (!string.IsNullOrWhiteSpace(dateOfBirth))
            {
                ValidateAccountDateOfBirth(dateOfBirth);
                account.DateOfBirth = dateOfBirth;
                isRecordUpdated = true;
            }

            Console.Write("Enter your gender: ");
            string gender = Console.ReadLine()!;

            if (!string.IsNullOrWhiteSpace(gender))
            {
                ValidateAccountGender(gender);
                account.Gender = gender;
                isRecordUpdated = true;
            }

            Console.Write("Enter marital status: ");
            string maritalStatus = Console.ReadLine()!;

            if (!string.IsNullOrWhiteSpace(maritalStatus))
            {
                ValidateAccountMaritalStatus(maritalStatus);
                account.MaritalStatus = maritalStatus;
                isRecordUpdated = true;
            }

            if (isRecordUpdated)
            {
                account.ModifiedAt = DateTime.Now;
                Console.WriteLine("Account was updated successfully!");
            }
            else
            {
                Console.WriteLine("Account unchanged");
            }
            Console.WriteLine();
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occured: " + ex.Message);
        }
    }

    private void CheckPassword(string EnterText)
    {
        try
        {
            Console.Write(EnterText);
            var EnteredVal = "";
            ConsoleKeyInfo key;

            while (true)
            {
                key = Console.ReadKey();

                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    EnteredVal += key.KeyChar;
                    Console.Write("*");
                }
                else if (key.Key == ConsoleKey.Backspace && EnteredVal.Length > 0)
                {
                    EnteredVal = EnteredVal.Substring(0, EnteredVal.Length - 1);
                    Console.Write("\b \b");
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    Console.Write("");

                    if (string.IsNullOrWhiteSpace(EnteredVal))
                    {
                        Console.WriteLine("Empty value not allowed! ");
                    }
                    else
                    {
                        break;
                    }

                    EnteredVal = "";
                    Console.Write(EnterText);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }

    public void SearchAccountById() { }

    public void ValidateAccountFisrtName(string name) { }

    public void ValidateAccountLastName(string name) { }

    public void ValidateAccountMiddleName(string name) { }

    public void ValidateAccountMobileNumber(string name) { }

    public void ValidateAccountGender(string name) { }

    public void ValidateAccountDateOfBirth(string name) { }

    public void ValidateAccountMaritalStatus(string status) { }

    public void ValidateAccountEmail(string status) { }
}
