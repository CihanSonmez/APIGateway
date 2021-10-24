using Customer.Infrastructure;
using Customer.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Customer.DataAccess
{
    public class DbOperations : IDbOperations<CustomerDto>
    {
        private readonly IConfiguration _config;

        public DbOperations(IConfiguration config)
        {
            _config = config;
        }
        public async Task<string> CreateCustomerAsync(CustomerDto entity)
        {
            MongoClient dbClient = new MongoClient(_config.GetConnectionString("MongoDbConn"));

            await dbClient.GetDatabase("sampleDb").GetCollection<CustomerDto>("Customer").InsertOneAsync(entity);

            return entity.Uuid;
        }

        public async Task<bool> DeleteCustomerAsync(string uuid)
        {
            MongoClient dbClient = new MongoClient(_config.GetConnectionString("MongoDbConn"));

            var result = await dbClient.GetDatabase("sampleDb").GetCollection<CustomerDto>("Customer").DeleteOneAsync(Builders<CustomerDto>.Filter.Eq("Uuid", uuid));

            return result.IsAcknowledged && result.DeletedCount > 0;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CustomerDto>> GetAllCustomersAsync()
        {
            MongoClient dbClient = new MongoClient(_config.GetConnectionString("MongoDbConn"));

            var collection = await dbClient.GetDatabase("sampleDb").GetCollection<CustomerDto>("Customer").AsQueryable().ToListAsync<CustomerDto>();

            return collection;
        }

        public async Task<CustomerDto> GetCustomerByUuidAsync(string uuid)
        {
            MongoClient dbClient = new MongoClient(_config.GetConnectionString("MongoDbConn"));

            var filter = Builders<CustomerDto>.Filter.Eq("Uuid", uuid);

            var result = await dbClient.GetDatabase("sampleDb").GetCollection<CustomerDto>("Customer").Find(filter).FirstOrDefaultAsync();

            return result;
        }

        public async Task<bool> UpdateCustomerAsync(CustomerDto entity)
        {
            MongoClient dbClient = new MongoClient(_config.GetConnectionString("MongoDbConn"));

            var filter = Builders<CustomerDto>.Filter.Eq("Uuid", entity.Uuid);

            var update = Builders<CustomerDto>.Update.Set("Name", entity.Name)
                                                     .Set("Email", entity.Email)
                                                     .Set("Address.AddressLine", entity.Address.AddressLine)
                                                     .Set("Address.City", entity.Address.City)
                                                     .Set("Address.CityCode", entity.Address.CityCode)
                                                     .Set("Address.Country", entity.Address.Country)
                                                     .Set("CreatedAt", entity.CreatedAt)
                                                     .Set("UpdatedAt", entity.UpdatedAt);

            var result = await dbClient.GetDatabase("sampleDb").GetCollection<CustomerDto>("Customer").UpdateOneAsync(filter, update);

            return result.IsAcknowledged && result.ModifiedCount > 0;
        }

        public async Task<bool> ValidateAsync(string uuid)
        {
            MongoClient dbClient = new MongoClient(_config.GetConnectionString("MongoDbConn"));

            var filter = Builders<CustomerDto>.Filter.Eq("Uuid", uuid);

            var result = await dbClient.GetDatabase("sampleDb").GetCollection<CustomerDto>("Customer").Find(filter).ToListAsync();

            if (result.Count > 0)
                return false;
            else
                return true;
        }
    }
}
