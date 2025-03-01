namespace BankApp;
public interface IAccountManager
{
    void AddAccount();

   void SearchAccountById();

    void SwitchAccount();

    void UpdateAccount();

    void DeleteAccount();
    
    //void ListAllAccounts();
}