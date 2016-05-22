using System.Text.RegularExpressions;

namespace BankingSystem.Models.Validators
{
    internal class NameValidator
    {
        public bool ValidatePersonName(string name)
        {

            if (name == null)
                return false;

            if (name.Length < 3)
            {
                return false;
            }

            const string regx = "^[\\p{L} .'-]+$";
            return Regex.IsMatch(name, regx);


        }


    }
}
