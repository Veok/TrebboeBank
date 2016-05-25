using TrebboeBank.Models.Accounts;

namespace TrebboeBank.Models.Operations
{
    public interface ICanSendCash
    {
        bool CanSendCash(Customer customer);
        double SendCach(Customer customer, double amount);
    }
}