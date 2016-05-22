using System;

namespace BankingSystem.Models.Validators
{
    class DateOfBirthValidator
    {

        public bool ValidateDoB(string dob)
        {
            try
            {
                string[] dateParts = dob.Split('.');


                new
                    DateTime(Convert.ToInt32(dateParts[2]),
                        Convert.ToInt32(dateParts[0]),
                        Convert.ToInt32(dateParts[1]));
                return true;
            }
            catch
            {

                return false;
            }
        }
    }
}

