using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EZMedChatMobile.Services
{
    public interface IMedChatDataService
    {
        // TODO: define method signatures for pulling data
        Task<bool> CheckExists(string key, string value);
        Task<bool> TestUsernameExists(string username);
    }
}
