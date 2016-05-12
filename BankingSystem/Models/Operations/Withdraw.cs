namespace BankingSystem.Models.Operations
{
    internal class Withdraw : ICanSendCash
    {
        public double Amount { get; set; }

        public bool CanSendCash(BankAccount bankAccount)
        {
            return bankAccount.Balance - Amount >= 0;
        }

        public double SendCach(BankAccount bankAccount)
        {
            return bankAccount.Balance - Amount;
        }
    }
}
