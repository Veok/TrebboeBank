using BankingSystem.Models.Customers;

namespace BankingSystem.Models.Operations
{
    internal class Income : ICanSendCash
    {
        public double Amount { get; set; }


        public bool CanSendCash(PersonalCustomer personalCustomer)
        {
            return personalCustomer.BankAccount.Balance >= 0;
        }

        public void SendCach(PersonalCustomer personalCustomer, double amount1)
        {
             personalCustomer.BankAccount.Balance =+ amount1;
        }
    }
}
