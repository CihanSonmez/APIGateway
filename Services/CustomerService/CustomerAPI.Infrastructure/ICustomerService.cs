using Customer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Customer.Infrastructure
{
    public interface ICustomerService
    {
        public string Create(CustomerDto customer);
        public bool Update(CustomerDto customer);
        public bool Delete(string uuid);
        public IEnumerable<CustomerDto> Get();
        public CustomerDto Get(string uuid);
        public bool Validate(string uuid);
    }
}
