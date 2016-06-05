using System;

namespace TrebboeBank.Models.Validators
{
    internal class DateOfBirthValidator
    {
        public bool ValidateDoB(string dob)
        {
            if (string.IsNullOrEmpty(dob)) return false;
            var dt =
                DateTime.Parse(dob);
            var today = DateTime.Now;
            var age = today.Year - dt.Year;
            return age > 18;
        }
    }
}