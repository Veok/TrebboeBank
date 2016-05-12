﻿using System;
using BankingSystem.Models.Validators;

namespace BankingSystem.Models.Generators
{
    public class NrbGenerator
    {
        public string NrbNumber { get; set; }


        public string GenerateNrb()
        {
            NrbValidator nrbValidator = new NrbValidator();

            do
            {
                Random rnd1 = new Random();
                NrbNumber = string.Empty;
                NrbNumber =
                    $"{rnd1.Next(1000000000):000000000}{rnd1.Next(1000000000):000000000}{rnd1.Next(100000000):00000000}";
            } while (nrbValidator.ValidateNrb(NrbNumber) == false);
            return NrbNumber;

        }

    }
}