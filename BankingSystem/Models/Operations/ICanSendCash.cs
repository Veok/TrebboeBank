using System;
using BankingSystem.Models.Customers;

namespace BankingSystem.Models.Operations
{
    public interface ICanSendCash
    {
        Boolean CanSendCash(PersonalCustomer personalCustomer);
        void SendCach(PersonalCustomer personalCustomer, double amount1);
    }
}
