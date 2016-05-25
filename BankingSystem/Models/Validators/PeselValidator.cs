using System;
using System.Linq;

namespace TrebboeBank.Models.Validators
{
    internal class PeselValidator
    {
        private static readonly int[] Wagi = {1, 3, 7, 9, 1, 3, 7, 9, 1, 3};

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
            var sum = Wagi.Select((t, i) => t*int.Parse(pesel[i].ToString())).Sum();
            var reszta = sum%10;
            return reszta == 0 ? reszta.ToString() : (10 - reszta).ToString();
        }
    }
}