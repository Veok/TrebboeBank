using System.Windows;
using TrebboeBank.Models.Generators;
using TrebboeBank.Models.Operations;

namespace TrebboeBank.Models.Accounts
{
    public class CompanyAccount : Customer
    {
        public CompanyAccount()
        {
        }

        public CompanyAccount(string firmName, string nip, string email,
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

        public string FirmName { get; set; }
        public string Nip { get; set; }

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