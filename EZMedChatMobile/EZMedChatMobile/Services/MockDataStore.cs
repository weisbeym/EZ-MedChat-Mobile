using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EZMedChatMobile.Models;

namespace EZMedChatMobile.Services
{
    public class MockDataStore : IDataStore<Practitioner>
    {
        readonly List<Practitioner> practitioners;

        public MockDataStore()
        {
            practitioners = new List<Practitioner>()
            {
                new Practitioner { Id = 1, FirstName = "John", LastName ="Doe", IsOnline=false},
                new Practitioner { Id = 2, FirstName = "Max", LastName ="Paine", IsOnline=true},
                new Practitioner { Id = 3, FirstName = "Jane", LastName ="Fonda", IsOnline=false},
                new Practitioner { Id = 4, FirstName = "Chris", LastName ="Pratt", IsOnline=false},
                new Practitioner { Id = 5, FirstName = "Mary", LastName ="Jane", IsOnline=false},
                new Practitioner { Id = 6, FirstName = "Gwen", LastName ="Stacy", IsOnline=false},
                new Practitioner { Id = 7, FirstName = "Allen", LastName ="Walker", IsOnline=true},
            };
        }

        public async Task<bool> AddItemAsync(Practitioner practitioner)
        {
            practitioners.Add(practitioner);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Practitioner practitioner)
        {
            var oldItem = practitioners.Where((Practitioner arg) => arg.Id == practitioner.Id).FirstOrDefault();
            practitioners.Remove(oldItem);
            practitioners.Add(practitioner);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldItem = practitioners.Where((Practitioner arg) => arg.Id == id).FirstOrDefault();
            practitioners.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Practitioner> GetItemAsync(int id)
        {
            return await Task.FromResult(practitioners.FirstOrDefault(s => s.Id == id));
        }

        public List<Practitioner> GetPractitioners()
        {
            return practitioners;
        }

        public async Task<IEnumerable<Practitioner>> GetPractitionersAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(practitioners);
        }
    }
}