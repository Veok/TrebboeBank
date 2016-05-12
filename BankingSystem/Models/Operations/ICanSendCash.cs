using System;

namespace BankingSystem.Models.Operations
{
    interface ICanSendCash
    {
        Boolean CanSendCash(BankAccount bankAccount);
        double SendCach(BankAccount bankAccount);
    }
}
