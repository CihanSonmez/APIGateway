using Customer.Infrastructure;
using Customer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IDbOperations<CustomerDto> _db;
        public CustomerService(IDbOperations<CustomerDto> db)
        {
            _db = db;
        }

        public string Create(CustomerDto customer)
        {
            return _db.CreateCustomerAsync(customer).Result;
        }

        public bool Delete(string uuid)
        {
            return _db.DeleteCustomerAsync(uuid).Result;
        }

        public IEnumerable<CustomerDto> Get()
        {
            return _db.GetAllCustomersAsync().Result;
        }

        public CustomerDto Get(string uuid)
        {
            return _db.GetCustomerByUuidAsync(uuid).Result;
        }

        public bool Update(CustomerDto customer)
        {
            return _db.UpdateCustomerAsync(customer).Result;
        }

        public bool Validate(string uuid)
        {
            return _db.ValidateAsync(uuid).Result;
        }
    }
}
