using System.Windows;
using TrebboeBank.Models.Accounts;

namespace TrebboeBank.Models.Operations
{
    internal class Withdraw : ICanSendCash
    {
        public bool CanSendCash(Customer customer)
        {
            return customer.BankAccount.Balance >= customer.Amount;
        }

        public double SendCach(Customer customer, double amount)
        {
            MessageBox.Show("Wypłacono zadaną kwotę");
            return customer.BankAccount.Balance = customer.BankAccount.Balance - amount;
        }
    }
}