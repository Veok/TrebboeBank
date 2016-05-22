using BankingSystem.Models.Accounts;

namespace BankingSystem.Models.Operations
{
    internal class Withdraw : ICanSendCash
    {
        public bool CanSendCash(Customer customer)
        {
            return customer.BankAccount.Balance - customer.Amount >= 0;
        }

        public double SendCach(Customer customer, double amount)
        {
            return customer.BankAccount.Balance = customer.BankAccount.Balance - amount;
        }
    }
}