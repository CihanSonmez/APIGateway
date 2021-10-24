using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Order.Infrastructure;
using Order.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Order.DataAccess
{
    public class DbOperations : IDbOperations<OrderDto>
    {
        private readonly IConfiguration _config;

        public DbOperations(IConfiguration config)
        {
            _config = config;
        }
        public async Task<bool> ChangeStatusAsync(string uuid, string status)
        {
            MongoClient dbClient = new MongoClient(_config.GetConnectionString("MongoDbConn"));

            var filter = Builders<OrderDto>.Filter.Eq("Uuid", uuid);

            var update = Builders<OrderDto>.Update.Set("Status", status);

            var result = await dbClient.GetDatabase("sampleDb").GetCollection<OrderDto>("Order").UpdateOneAsync(filter, update);

            return result.IsAcknowledged && result.ModifiedCount > 0;
        }

        public async Task<string> CreateOrderAsync(OrderDto entity)
        {
            MongoClient dbClient = new MongoClient(_config.GetConnectionString("MongoDbConn"));

            await dbClient.GetDatabase("sampleDb").GetCollection<OrderDto>("Order").InsertOneAsync(entity);

            return entity.Uuid;
        }

        public async Task<bool> DeleteOrderAsync(string uuid)
        {
            MongoClient dbClient = new MongoClient(_config.GetConnectionString("MongoDbConn"));

            var result = await dbClient.GetDatabase("sampleDb").GetCollection<OrderDto>("Order").DeleteOneAsync(Builders<OrderDto>.Filter.Eq("Uuid", uuid));

            return result.IsAcknowledged && result.DeletedCount > 0;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<OrderDto>> GetAllOrdersAsync()
        {
            MongoClient dbClient = new MongoClient(_config.GetConnectionString("MongoDbConn"));

            var collection = await dbClient.GetDatabase("sampleDb").GetCollection<OrderDto>("Order").AsQueryable().ToListAsync<OrderDto>();

            return collection;
        }

        public async Task<OrderDto> GetOrderByUuidAsync(string uuid)
        {
            MongoClient dbClient = new MongoClient(_config.GetConnectionString("MongoDbConn"));

            var filter = Builders<OrderDto>.Filter.Eq("Uuid", uuid);

            var result = await dbClient.GetDatabase("sampleDb").GetCollection<OrderDto>("Order").Find(filter).FirstOrDefaultAsync();

            return result;
        }

        public async Task<bool> UpdateOrderAsync(OrderDto entity)
        {
            MongoClient dbClient = new MongoClient(_config.GetConnectionString("MongoDbConn"));

            var filter = Builders<OrderDto>.Filter.Eq("Uuid", entity.Uuid);

            var update = Builders<OrderDto>.Update.Set("CustomerId", entity.CustomerId)
                                                  .Set("Quantity", entity.Quantity)
                                                  .Set("Price", entity.Price)
                                                  .Set("Status", entity.Status)
                                                  .Set("Product.Uuid", entity.Product.Uuid)
                                                  .Set("Product.ImageUrl", entity.Product.ImageUrl)
                                                  .Set("Product.Name", entity.Product.Name)
                                                  .Set("Address.AddressLine", entity.Address.AddressLine)
                                                  .Set("Address.City", entity.Address.City)
                                                  .Set("Address.CityCode", entity.Address.CityCode)
                                                  .Set("Address.Country", entity.Address.Country)
                                                  .Set("CreatedAt", entity.CreatedAt)
                                                  .Set("UpdatedAt", entity.UpdatedAt);

            var result = await dbClient.GetDatabase("sampleDb").GetCollection<OrderDto>("Order").UpdateOneAsync(filter, update);

            return result.IsAcknowledged && result.ModifiedCount > 0;
        }
    }
}
