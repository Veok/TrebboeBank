using System.Text.RegularExpressions;

namespace TrebboeBank.Models.Validators
{
    internal class NameValidator
    {
        public bool ValidateName(string name)
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