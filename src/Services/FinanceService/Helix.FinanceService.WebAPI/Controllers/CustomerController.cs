using Helix.FinanceService.Application.Services;
using Helix.FinanceService.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Helix.FinanceService.Infrastructure.Queries.CustomerQuery;

namespace Helix.FinanceService.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class CustomerController : ControllerBase
{
    ICustomerService _customerService;
    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }
    [HttpGet()]
    public async Task<DataResult<IEnumerable<Customer>>> GetAll([FromQuery] string search = "", string orderBy = CustomerOrderBy.CustomerNameDesc, int page = 0, int pageSize = 20)
    {
        DataResult<IEnumerable<Customer>> result = new();
        switch (orderBy)
        {
            case "namedesc":
                result = await _customerService.GetCustomersAsync(search, CustomerOrderBy.CustomerNameDesc, page, pageSize);
                return result;
            case "nameasc":
                result = await _customerService.GetCustomersAsync(search, CustomerOrderBy.CustomerNameAsc, page, pageSize);
                return result;
            case "codedesc":
                result = await _customerService.GetCustomersAsync(search, CustomerOrderBy.CustomerCodeDesc, page, pageSize);
                return result;
            case "codeasc":
                result = await _customerService.GetCustomersAsync(search, CustomerOrderBy.CustomerCodeAsc, page, pageSize);
                return result;
            default:
                result = await _customerService.GetCustomersAsync(search, orderBy, page, pageSize);
                return result;
        }

    }
    [HttpGet("Code/{code}")]
    public async Task<DataResult<Customer>> GetByCode(string code)
    {
        var result = await _customerService.GetCustomersByCodeAsync(code);
        return result;
    }
    [HttpGet("Id/{id:int}")]
    public async Task<DataResult<Customer>> GetById(int id)
    {
        var result = await _customerService.GetCustomerByIdAsync(id);
        return result;
    }
}
