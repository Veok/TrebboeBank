using System.Text.RegularExpressions;

namespace TrebboeBank.Models.Validators
{
    internal class PhoneValidator
    {
        public bool ValidatePhoneNumber(string phone)
        {
            
            return Regex.Match(phone, @"^(\+[0-9]{9})$").Success;
        }
    }
}