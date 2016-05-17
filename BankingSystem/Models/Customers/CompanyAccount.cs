using System;

namespace BankingSystem.Models.Customers
{
    internal class CompanyAccount : Customer
    {
        public string FirmName { get; set; }
        public long Nip { get; set; }
        public DateTime FirmDate { get; set; }
    }
}