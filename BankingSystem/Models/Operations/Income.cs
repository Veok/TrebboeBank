namespace BankingSystem.Models.Operations
{
    internal class Income : ICanSendCash
    {
        public double Amount { get; set; }


        public bool CanSendCash(BankAccount bankAccount)
        {
            return bankAccount.Balance >= 0;
        }

        public double SendCach(BankAccount bankAccount)
        {
            return bankAccount.Balance + Amount;
        }
    }
}
