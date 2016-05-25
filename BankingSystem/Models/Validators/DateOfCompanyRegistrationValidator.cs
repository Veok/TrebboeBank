using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Models.Validators
{
    class DateOfCompanyRegistrationValidator
    {
        public bool ValidateDor(string dor)
        {
            if (!string.IsNullOrEmpty(dor))
            {
                DateTime dt =
        DateTime.ParseExact(dor, "dd.MM.yyyy", CultureInfo.InvariantCulture);
                DateTime today = DateTime.Now;
                DateTime validDate = new DateTime(today.Year - 1, today.Month , today.Day );
                TimeSpan validAge = today.Subtract(validDate);
                TimeSpan actualAge = today.Subtract(dt);
                TimeSpan.Compare(validAge, actualAge);
                return true;
            }
            return false;
        }
    }
}
