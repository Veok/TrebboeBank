using System;
using System.Linq;

namespace TrebboeBank.Models.Validators
{
    internal class PeselValidator
    {
        private static readonly int[] Waig = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };

        public bool ValidatePesel(string pesel)
        {
            var toRet = false;
            if (pesel == null)
            {
                return false;
            }
            try
            {
                if (pesel.Length == 11)
                {
                    toRet = CountSum(pesel).Equals(pesel[10].ToString());
                }
            }
            catch (Exception)
            {
                toRet = false;
            }
            return toRet;
        }

        private static string CountSum(string pesel)
        {
            var sum = Waig.Select((t, i) => t * int.Parse(pesel[i].ToString())).Sum();
            var rest = sum % 10;
            return rest == 0 ? rest.ToString() : (10 - rest).ToString();
        }
    }
}