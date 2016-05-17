using BankingSystem.Models.Customers;

namespace BankingSystem.Models.Operations
{
    public interface ICanSendCash
    {
        bool CanSendCash(PersonalAccount personalAccount);
        double SendCach(PersonalAccount personalAccount, double amount);
    }
}