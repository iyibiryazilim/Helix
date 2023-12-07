using Helix.SalesService.Application.Repository;
using Helix.SalesService.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Helix.SalesService.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CustomerController : ControllerBase
	{
		ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
		[HttpGet]
		public async Task<DataResult<IEnumerable<Customer>>> GetAll()
		{
			var result = await _customerService.GetCustomersAsync();
			return result;
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
}
