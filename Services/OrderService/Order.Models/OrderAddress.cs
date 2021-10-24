using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Models
{
    public class OrderAddress
    {
        public string AddressLine { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int CityCode { get; set; }
    }
}
