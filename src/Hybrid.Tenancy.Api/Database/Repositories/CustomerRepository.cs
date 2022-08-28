using Hybrid.Tenancy.Api.Interfaces;
using Hybrid.Tenancy.Api.Models;
using MongoDB.Driver;

namespace Hybrid.Tenancy.Api.Database.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly IMongoCollection<Customer> _mongoCollection;

    public CustomerRepository(IMongoClient mongoClient, string database, string collection)
    {
        _mongoCollection = mongoClient.GetDatabase(database).GetCollection<Customer>(collection);
    }

    public async Task<string> InsertCustomerAsync(Customer customer)
    {
        await _mongoCollection.InsertOneAsync(customer);

        return customer.Id;
    }

    public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
    {
        return await _mongoCollection.AsQueryable().ToListAsync();
    }
}
