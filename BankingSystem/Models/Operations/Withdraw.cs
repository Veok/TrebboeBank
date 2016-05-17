using BankingSystem.Models.Customers;

namespace BankingSystem.Models.Operations
{
    internal class Withdraw : ICanSendCash
    {
        public bool CanSendCash(PersonalAccount personalAccount)
        {
            return personalAccount.BankAccount.Balance - personalAccount.Amount >= 0;
        }

        public double SendCach(PersonalAccount personalAccount, double amount)
        {
            return personalAccount.BankAccount.Balance = personalAccount.BankAccount.Balance - amount;
        }
    }
}