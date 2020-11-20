using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EZMedChatMobile.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddItemAsync(T item);
        Task<bool> UpdateItemAsync(T item);
        Task<bool> DeleteItemAsync(int id);
        Task<T> GetItemAsync(int id);

        List<T> GetPractitioners();
        Task<IEnumerable<T>> GetPractitionersAsync(bool forceRefresh = false);

    }
}
