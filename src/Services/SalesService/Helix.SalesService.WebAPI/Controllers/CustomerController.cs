using Helix.EventBus.Base.Abstractions;
using Helix.SalesService.Application.Repository;
using Helix.SalesService.Domain.Dtos;
using Helix.SalesService.Domain.Events;
using Helix.SalesService.Domain.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Helix.SalesService.Infrastructure.Helper.Queries.CustomerQuery;

namespace Helix.SalesService.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class CustomerController : ControllerBase
	{
		private ICustomerService _customerService;
		private IEventBus _eventBus;

		public CustomerController(ICustomerService customerService, IEventBus eventBus)
		{
			_customerService = customerService;
			_eventBus = eventBus;
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

		[HttpPost]
		public async Task CustomerInsert([FromBody] CustomerDto customerDto)
		{
			_eventBus.Publish(new CustomerInsertingIntegrationEvent(customerDto.code, customerDto.title, customerDto.address, customerDto.otherAddress, customerDto.districtCode, customerDto.countyCode, customerDto.cityCode, customerDto.countryCode, customerDto.telephone, customerDto.taxNumber, customerDto.taxOffice, customerDto.paymentCode, customerDto.eMail, customerDto.tckn));
		}
	}
}