using System;

namespace BankingSystem.Models.Generators
{
    public class AccountIdGenerator
    {
        public int Id { get; set; }

        public int IdGenerator()
        {
            var rnd = new Random();
            Id = rnd.Next(1000000, 9999999);
            return Id;
        }
    }
}