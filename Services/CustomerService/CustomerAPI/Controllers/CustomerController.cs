using Customer.Infrastructure;
using Customer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPut]
        [Route("Create")]
        public string Create([FromBody]CustomerDto customer)
        {
            return _customerService.Create(customer);
        }

        [HttpDelete]
        [Route("Delete")]
        public bool Delete(string uuid)
        {
            return _customerService.Delete(uuid);
        }

        [HttpGet]
        [Route("Get")]
        public IEnumerable<CustomerDto> Get()
        {
            return _customerService.Get();
        }

        [HttpGet]
        [Route("Get/{uuid}")]
        public CustomerDto Get(string uuid)
        {
            return _customerService.Get(uuid);
        }

        [HttpPost]
        [Route("Update")]
        public bool Update([FromBody]CustomerDto customer)
        {
            return _customerService.Update(customer);
        }

        [HttpGet]
        [Route("Validate/{uuid}")]
        public bool Validate(string uuid)
        {
            return _customerService.Validate(uuid);
        }
    }
}
