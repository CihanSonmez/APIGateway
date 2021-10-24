using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace Customer.Models
{
    public class CustomerDto
    {
        public ObjectId Id { get; set; }
        public string Uuid { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public CustomerAddress Address { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
