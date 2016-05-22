using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BankingSystem.Models.Validators
{
    class PhoneValidator
    {
        public bool ValidatePhoneNumber(string phone)
        {
            return Regex.Match(phone, @"^(\+[0-9]{9})$").Success;
        }
    }
}
