using BankingSystem.Models.Customers;

namespace BankingSystem.Models.Operations
{
     class Income : ICanSendCash
    {

        public bool CanSendCash(PersonalCustomer personalCustomer)
        {
            return personalCustomer.amount >= 0;
        }

        public double SendCach(PersonalCustomer personalCustomer, double amount)
        {
            return personalCustomer.BankAccount.Balance = personalCustomer.BankAccount.Balance+ amount;
            //return cash;
        }
    }
}
