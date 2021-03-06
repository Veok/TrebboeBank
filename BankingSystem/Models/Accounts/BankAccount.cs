﻿using TrebboeBank.Models.Generators;

namespace TrebboeBank.Models.Accounts
{
    public class BankAccount
    {
        public double Balance { get; set; }
        public AccountIdGenerator AccountId { get; set; }
        public NrbGenerator Nrb { get; set; }
    }
}