using EZMedChatMobile.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace EZMedChatMobile.Validation
{
    public class UsernameDoesNotExistRule<T> : IValidationRule<T>
    {
        private IMedChatDataService _dataService;

        public UsernameDoesNotExistRule(IMedChatDataService dataService)
        {
            _dataService = dataService;
        }

        public string ValidationMessage { get; set; }

        public bool Check(T value)
        {
            if (value == null)
            {
                return false;
            }

            var str = value as string;
            return _dataService.TestUsernameExists(str).Result;
        }
    }
}
