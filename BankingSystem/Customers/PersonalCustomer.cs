using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Customers
{
    public class PersonalCustomer : Customer
    {
        


        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public Gender Gender1 { get; set; }
        public long Pesel { get; set; }

        public PersonalCustomer() { }
        public PersonalCustomer( string firstName, string lastName, string doB, 
            Gender gender, long pesel, string email, string street, string zipCode, string country,
            string phone, string city)
        {
           
            this.FirstName = firstName;
            this.LastName = lastName;
            this.DateOfBirth = doB;
            this.Gender1 = gender;
            this.Pesel = pesel; 
            this.Email = email;
            this.Street = street;
            this.ZipCode = zipCode;
            this.Country = country;
            this.Phone = phone;
            this.City = city;
        }

    }
}
