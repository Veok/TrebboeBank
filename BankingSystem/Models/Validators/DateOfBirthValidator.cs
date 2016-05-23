using System;
using System.Globalization;
using System.Windows;

namespace BankingSystem.Models.Validators
{
    class DateOfBirthValidator
    {

        public bool ValidateDoB(string dob)
        {

            if (!string.IsNullOrEmpty(dob))
            {
                DateTime dt =
        DateTime.ParseExact(dob, "dd.MM.yyyy", CultureInfo.InvariantCulture);
                DateTime today = DateTime.Now;
                DateTime validDate = new DateTime(today.Year - 18, today.Month, today.Day);
                TimeSpan validAge = today.Subtract(validDate);
                TimeSpan actualAge = today.Subtract(dt);
                TimeSpan.Compare(validAge, actualAge);
                return true;
            }
            return false;

        }
    }
}

