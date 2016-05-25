using System;
using System.Windows;
using BankingSystem.Models.Generators;
using BankingSystem.Models.Operations;

namespace BankingSystem.Models.Accounts
{
    public class CompanyAccount : Customer
    {
        public string FirmName { get; set; }
        public string Nip { get; set; }
    

        public CompanyAccount() { }

        public CompanyAccount(string firmName, string nip,  string email,
            string zipCode, string country, string phone, string city, string street, BankAccount bankAccount)
        {
            FirmName = firmName;
            Nip = nip;
        
            Email = email;
            Street = street;
            ZipCode = zipCode;
            Country = country;
            Phone = phone;
            City = city;

            BankAccount = bankAccount;
            bankAccount.AccountId = new AccountIdGenerator();
            bankAccount.AccountId.IdGenerator();
            bankAccount.Nrb = new NrbGenerator();
            bankAccount.Nrb.GenerateNrb();
        }

        public void ApplyIncome(ICanSendCash applyIncome)
        {
            if (applyIncome.CanSendCash(this))
            {
                applyIncome.SendCach(this, Amount);
            }
            else
            {
                MessageBox.Show("Operacja nieudana");
            }
        }

    }
}