using Order.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Infrastructure
{
    public interface IOrderService
    {
        public string Create(OrderDto customer);
        public bool Update(OrderDto customer);
        public bool Delete(string uuid);
        public IEnumerable<OrderDto> Get();
        public OrderDto Get(string uuid);
        public bool ChangeStatus(string uuid, string status);
    }
}
