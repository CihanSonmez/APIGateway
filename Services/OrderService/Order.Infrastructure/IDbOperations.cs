using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Order.Infrastructure
{
    public interface IDbOperations<T> : IDisposable where T : class
    {
        Task<string> CreateOrderAsync(T entity);
        Task<bool> DeleteOrderAsync(string uuid);
        Task<bool> UpdateOrderAsync(T entity);
        Task<IEnumerable<T>> GetAllOrdersAsync();
        Task<T> GetOrderByUuidAsync(string uuid);
        Task<bool> ChangeStatusAsync(string uuid, string status);
    }
}
