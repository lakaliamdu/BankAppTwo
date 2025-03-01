namespace BankApp;

public class Account : BaseClass
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string MiddleName { get; set; } = default!;
    public string MobileNumber { get; set; } = default!;
    public string Email { get; set;} = default!;
    public string? DateOfBirth { get; set; }
    public string? Gender { get; set; }
    public string Password { get; set; } = default!;
    public string? MaritalStatus { get; set; }
}

