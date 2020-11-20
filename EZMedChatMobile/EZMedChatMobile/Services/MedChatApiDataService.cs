using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EZMedChatMobile.Services
{
    public class MedChatApiDataService : BaseHttpService, IMedChatDataService
    {
        readonly Uri _baseUri;
        readonly IDictionary<string, string> _headers;

        public MedChatApiDataService(Uri baseUri)
        {
            _baseUri = baseUri;
            _headers = new Dictionary<string, string>();
        }

        public async Task<bool> CheckExists(string key, string value)
        {
            var url = new Uri(_baseUri, "Patients/CheckExists");
            _headers.Add(key, value);
            var responce = await SendRequestAsync<bool>(url, HttpMethod.Get, _headers);
            return responce;
        }

        public async Task<bool> TestUsernameExists(string username)
        {
            List<string> usernames = new List<string>();
            usernames.Add("coolguy75");
            usernames.Add("j0hnc3na");
            usernames.Add("weisbeym");
            usernames.Add("vincenjg");
            usernames.Add("poliij");

            await Task.Delay(5000);
            return usernames.Contains(username);
        }
    }
}
