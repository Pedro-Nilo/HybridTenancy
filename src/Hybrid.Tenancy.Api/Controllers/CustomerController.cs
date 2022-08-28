using Hybrid.Tenancy.Api.Interfaces;
using Hybrid.Tenancy.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hybrid.Tenancy.Api.Controllers;


[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerController(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Customer customer)
    {
        var id = await _customerRepository.InsertCustomerAsync(customer);

        return Created("/api/customer/", id);
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var customers = await _customerRepository.GetAllCustomersAsync();

        return Ok(customers);
    }
}
