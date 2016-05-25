using System.Windows;
using BankingSystem.Models.Generators;
using BankingSystem.Models.Operations;

namespace BankingSystem.Models.Accounts
{
    public class PersonalAccount : Customer
    {
        public PersonalAccount()
        {
        }

        public PersonalAccount(string firstName, string lastName, string doB,
            Gender gender, string pesel, string email, string street, string zipCode, string country,
            string phone, string city, BankAccount bankAccount)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = doB;
            Gender1 = gender;
            Pesel = pesel;
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


        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public Gender Gender1 { get; set; }
        public string Pesel { get; set; }

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