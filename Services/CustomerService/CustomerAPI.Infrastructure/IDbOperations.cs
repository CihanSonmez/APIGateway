using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Infrastructure
{
    public interface IDbOperations<T> : IDisposable where T : class
    {
        Task<string> CreateCustomerAsync(T entity);
        Task<bool> DeleteCustomerAsync(string uuid);
        Task<bool> UpdateCustomerAsync(T entity);
        Task<IEnumerable<T>> GetAllCustomersAsync();
        Task<T> GetCustomerByUuidAsync(string uuid);
        Task<bool> ValidateAsync(string uuid);
    }
}
