using Hybrid.Tenancy.Api.Models;

namespace Hybrid.Tenancy.Api.Interfaces;

public interface ICustomerRepository
{
    Task<string> InsertCustomerAsync(Customer customer);
    Task<IEnumerable<Customer>> GetAllCustomersAsync();
}
