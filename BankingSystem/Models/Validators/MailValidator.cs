using System;
using System.Net.Mail;

namespace BankingSystem.Models.Validators
{
    internal class MailValidator
    {
        public bool ValidateMail(string email)
        {

            if (string.IsNullOrEmpty(email))
            {
                return false;
            } 
          
            try
            {
                MailAddress mail = new MailAddress(email);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
