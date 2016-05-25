using System.Windows;
using BankingSystem.Models.Accounts;

namespace BankingSystem.Models.Operations
{
    internal class Income : ICanSendCash
    {
        public bool CanSendCash(Customer customer)
        {
            return customer.Amount >= 0;
        }

        public double SendCach(Customer customer, double amount)
        {
            MessageBox.Show("Wpłacono zadaną kwotę");
            return customer.BankAccount.Balance = customer.BankAccount.Balance + amount;

        }
    }
}