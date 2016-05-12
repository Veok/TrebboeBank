namespace BankingSystem.Models.Validators
{
    internal class NrbValidator
    {

        public bool ValidateNrb(string nrb1)
        {

            if (nrb1.Length != 26 && nrb1.Length != 32)
            {
                return false;
            }

            const int countryCode = 2521;
            string checkSum = nrb1.Substring(0, 2);
            string accountNumber = nrb1.Substring(2);
            string reversedDigits = accountNumber + countryCode + checkSum;
            return ModString(reversedDigits, 97) == 1;
        }

        private static int ModString(string x, int y)
        {
            if (string.IsNullOrEmpty(x))
            {
                return 0;
            }
            string firstDigit = x.Substring(0, x.Length - 1); 
            int lastDigit = int.Parse(x.Substring(x.Length - 1)); 
            return (ModString(firstDigit, y) * 10 + lastDigit) % y;
        }

    }
}
