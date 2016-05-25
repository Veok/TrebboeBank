namespace TrebboeBank.Models.Accounts
{
    public class Customer
    {
        public BankAccount BankAccount { get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public double Amount { get; set; }
    }
}