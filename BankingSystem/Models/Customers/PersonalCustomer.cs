using BankingSystem.Models.Generators;

namespace BankingSystem.Models.Customers
{
    public class PersonalCustomer : Customer
    {
        public PersonalCustomer() 
        {
        }

        public PersonalCustomer(string firstName, string lastName, string doB,
            Gender gender, long pesel, string email, string street, string zipCode, string country,
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
            bankAccount.Balance = 0;
            bankAccount.Nrb = new NrbGenerator();
            bankAccount.Nrb.GenerateNrb();



        }

        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public Gender Gender1 { get; set; }
        public long Pesel { get; set; }
    }
}