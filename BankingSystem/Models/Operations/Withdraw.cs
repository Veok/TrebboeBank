using BankingSystem.Models.Customers;

namespace BankingSystem.Models.Operations
{
    internal class Withdraw : ICanSendCash
    {
        public double Amount { get; set; }

        public bool CanSendCash(PersonalCustomer personalCustomer)
        {
            return personalCustomer.BankAccount.Balance - Amount >= 0;
        }

        public double SendCach(PersonalCustomer personalCustomer, double amount)
        {
            return personalCustomer.BankAccount.Balance =- Amount;

        }
    }
}
