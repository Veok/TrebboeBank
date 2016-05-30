﻿using System;
using System.Globalization;

namespace TrebboeBank.Models.Validators
{
    internal class DateOfBirthValidator
    {
        public bool ValidateDoB(string dob)
        {
            if (!string.IsNullOrEmpty(dob))
            {
                var dt =
                    DateTime.Parse(dob);
                var today = DateTime.Now;
                var age = today.Year - dt.Year;
                if (age > 18)
                {
                    return true;
                }
            }
            return false;
        }
    }
}