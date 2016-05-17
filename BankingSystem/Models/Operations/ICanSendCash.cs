using System;
using BankingSystem.Models.Customers;

namespace BankingSystem.Models.Operations
{
    public interface ICanSendCash
    {
        Boolean CanSendCash(PersonalCustomer personalCustomer);
        double SendCach(PersonalCustomer personalCustomer, double amount);
    }
}
