using BankingSystem.Models.Generators;
using BankingSystem.Models.Operations;

namespace BankingSystem.Models
{
    public class BankAccount
    {
        public double Balance { get; set; }
        public AccountIdGenerator AccountId { get; set; }
        public NrbGenerator Nrb { get; set; }
        

        
        

    }
}
