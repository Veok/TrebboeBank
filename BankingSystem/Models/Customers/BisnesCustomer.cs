using System;

namespace BankingSystem.Models.Customers
{
    internal class BisnesCustomer : Customer
    {
        public string FirmName { get; set; }
        public long Nip { get; set; }
        public DateTime FirmDate { get; set; }
    }
}