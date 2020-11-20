using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace EZMedChatMobile.Validation
{
    /// <summary>
    /// This Validation Rule checks if a password contain at least 8 characters, with 
    /// those characters containing 1 numeric, 1 uppercase, 1 lowercase, and 1 special character.
    /// </summary>
    /// <typeparam name="T">The String password to validate.</typeparam>
    public class PasswordRule<T> : IValidationRule<T>
    {
        public string ValidationMessage { get; set; }

        public bool Check(T value)
        {
            if (value == null)
            {
                return false;
            }

            var str = value as string;
            Regex regex = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[$@$!%*#?&])[A-Za-z\d$@$!%*#?&]{8,}$");
            Match match = regex.Match(str);

            return match.Success;
        }
    }
}
