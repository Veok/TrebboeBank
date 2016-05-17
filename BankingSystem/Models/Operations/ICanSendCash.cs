using BankingSystem.Models.Customers;

namespace BankingSystem.Models.Operations
{
    public interface ICanSendCash
    {
        bool CanSendCash(PersonalCustomer personalCustomer);
        double SendCach(PersonalCustomer personalCustomer, double amount);
    }
}