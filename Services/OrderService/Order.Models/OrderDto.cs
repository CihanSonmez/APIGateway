using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Models
{
    public class OrderDto
    {
        public ObjectId Id { get; set; }
        public string Uuid { get; set; }
        public string CustomerId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Status { get; set; }
        public OrderAddress Address { get; set; }
        public OrderProduct Product { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
