using BankingSystem.Models.Accounts;

namespace BankingSystem.Models.Operations
{
    public interface ICanSendCash
    {
        bool CanSendCash(Customer customer);
        double SendCach(Customer customer, double amount);
    }
}