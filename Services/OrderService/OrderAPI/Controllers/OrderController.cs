using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order.Infrastructure;
using Order.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPut]
        [Route("Create")]
        public string Create([FromBody] OrderDto order)
        {
            return _orderService.Create(order);
        }

        [HttpDelete]
        [Route("Delete")]
        public bool Delete(string uuid)
        {
            return _orderService.Delete(uuid);
        }

        [HttpGet]
        [Route("Get")]
        public IEnumerable<OrderDto> Get()
        {
            return _orderService.Get();
        }

        [HttpGet]
        [Route("Get/{uuid}")]
        public OrderDto Get(string uuid)
        {
            return _orderService.Get(uuid);
        }

        [HttpPost]
        [Route("Update")]
        public bool Update([FromBody] OrderDto order)
        {
            return _orderService.Update(order);
        }

        [HttpPost]
        [Route("ChangeStatus/{uuid}/{status}")]
        public bool ChangeStatus(string uuid, string status)
        {
            return _orderService.ChangeStatus(uuid, status);
        }
    }
}
