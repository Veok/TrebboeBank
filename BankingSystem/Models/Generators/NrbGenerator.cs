using System;
using TrebboeBank.Models.Validators;

namespace TrebboeBank.Models.Generators
{
    public class NrbGenerator
    {
        public string NrbNumber { get; set; }


        public string GenerateNrb()
        {
            var nrbValidator = new NrbValidator();

            do
            {
                var rnd1 = new Random();
                NrbNumber = string.Empty;
                /* Generowanie 26 losowych cyfr */
                NrbNumber =
                    $"{rnd1.Next(1000000000):000000000}{rnd1.Next(1000000000):000000000}{rnd1.Next(100000000):00000000}";
            } while (nrbValidator.ValidateNrb(NrbNumber) == false);
            return NrbNumber;
        }
    }
}