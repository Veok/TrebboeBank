using System;

namespace BankingSystem.Customers
{
    internal class BisnesCustomer : Customer
    {
        public string FirmName { get; set; }
        public long Nip { get; set; }
        public DateTime FirmDate { get; set; }
    }
}