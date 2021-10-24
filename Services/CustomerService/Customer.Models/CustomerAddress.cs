using System;
using System.Collections.Generic;
using System.Text;

namespace Customer.Models
{
    public class CustomerAddress
    {
        public string AddressLine { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int CityCode { get; set; }
    }
}
