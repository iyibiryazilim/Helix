using Helix.SalesService.Application.Repository;
using Helix.SalesService.Domain.Models;
using Helix.SalesService.Infrastructure.Helper.Queries;
using Microsoft.AspNetCore.Mvc;
using static Helix.SalesService.Infrastructure.Helper.Queries.CustomerTransactionQuery;
using static Helix.SalesService.Infrastructure.Helper.Queries.CustomerTransactionQuery;

namespace Helix.SalesService.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CustomerTransactionController : ControllerBase
	{
		ICustomerTransactionService _customerTransactionService;
        public CustomerTransactionController(ICustomerTransactionService customerTransactionService)
        {
            _customerTransactionService = customerTransactionService;
        }
		[HttpGet("Current/Code/{currentCode}")]
		public async Task<DataResult<IEnumerable<CustomerTransaction>>> GetTransactionByTransactionTypeAndCodeAsync([FromQuery] string search = "", string orderBy = CustomerTransactionOrderBy.DateAsc, string currentCode = "", string TransactionType = "1", int page = 0, int pageSize = 20)
		{
			var result = new DataResult<IEnumerable<CustomerTransaction>>();
			switch (orderBy)
			{
				 
				case "codedesc":
					result = await _customerTransactionService.GetTransactionByTransactionTypeAsync(search, CustomerTransactionOrderBy.CodeDesc, currentCode, TransactionType, page, pageSize);
					return result;
				case "codeasc":
					result = await _customerTransactionService.GetTransactionByTransactionTypeAsync(search, CustomerTransactionOrderBy.CodeAsc, currentCode, TransactionType, page, pageSize);
					return result;
				case "dateasc":
					result = await _customerTransactionService.GetTransactionByTransactionTypeAsync(search, CustomerTransactionOrderBy.DateAsc, currentCode, TransactionType, page, pageSize);
					return result;
				case "datedesc":
					result = await _customerTransactionService.GetTransactionByTransactionTypeAsync(search, CustomerTransactionOrderBy.DateDesc, currentCode, TransactionType, page, pageSize);
					return result;
				default:
					return result;
			} 
		}
		[HttpGet("Current/Id/{currentId:int}")]
		public async Task<DataResult<IEnumerable<CustomerTransaction>>> GetTransactionByTransactionTypeAndIdAsync([FromQuery] string search = "", string orderBy = CustomerTransactionOrderBy.DateAsc, int currentId = 0, string TransactionType = "1", int page = 0, int pageSize = 20)
		{
			var result = new DataResult<IEnumerable<CustomerTransaction>>();
			switch (orderBy)
			{

				case "codedesc":
					result = await _customerTransactionService.GetTransactionByTransactionTypeAsync(search, CustomerTransactionOrderBy.CodeDesc, currentId, TransactionType, page, pageSize);
					return result;
				case "codeasc":
					result = await _customerTransactionService.GetTransactionByTransactionTypeAsync(search, CustomerTransactionOrderBy.CodeAsc, currentId, TransactionType, page, pageSize);
					return result;
				case "dateasc":
					result = await _customerTransactionService.GetTransactionByTransactionTypeAsync(search, CustomerTransactionOrderBy.DateAsc, currentId, TransactionType, page, pageSize);
					return result;
				case "datedesc":
					result = await _customerTransactionService.GetTransactionByTransactionTypeAsync(search, CustomerTransactionOrderBy.DateDesc, currentId, TransactionType, page, pageSize);
					return result;
				default:
					return result;
			} 
		}

		[HttpGet("Current/Code/{currentCode}/All")]
		public async Task<DataResult<IEnumerable<CustomerTransaction>>> GetTransactionByCurrentCodeAsync([FromQuery] string search = "", string orderBy = CustomerTransactionOrderBy.DateAsc, string currentCode = "", int page = 0, int pageSize = 20)
		{
			var result = new DataResult<IEnumerable<CustomerTransaction>>();
			switch (orderBy)
			{

				case "codedesc":
					result = await _customerTransactionService.GetTransactionByCurrentCode(search, CustomerTransactionOrderBy.CodeDesc, currentCode, page, pageSize);
					return result;
				case "codeasc":
					result = await _customerTransactionService.GetTransactionByCurrentCode(search, CustomerTransactionOrderBy.CodeAsc, currentCode, page, pageSize);
					return result;
				case "dateasc":
					result = await _customerTransactionService.GetTransactionByCurrentCode(search, CustomerTransactionOrderBy.DateAsc, currentCode, page, pageSize);
					return result;
				case "datedesc":
					result = await _customerTransactionService.GetTransactionByCurrentCode(search, CustomerTransactionOrderBy.DateDesc, currentCode, page, pageSize);
					return result;
				default:
					return result;
			} 
		}
		[HttpGet("Current/Id/{currentId:int}/All")]
		public async Task<DataResult<IEnumerable<CustomerTransaction>>> GetTransactionByCurrentIdAsync([FromQuery] string search = "", string orderBy = CustomerTransactionOrderBy.DateAsc, int currentId = 0, int page = 0, int pageSize = 20)
		{
			var result = new DataResult<IEnumerable<CustomerTransaction>>();
			switch (orderBy)
			{

				case "codedesc":
					result = await _customerTransactionService.GetTransactionByCurrentId(search, CustomerTransactionOrderBy.CodeDesc, currentId, page, pageSize);
					return result;
				case "codeasc":
					result = await _customerTransactionService.GetTransactionByCurrentId(search, CustomerTransactionOrderBy.CodeAsc, currentId, page, pageSize);
					return result;
				case "dateasc":
					result = await _customerTransactionService.GetTransactionByCurrentId(search, CustomerTransactionOrderBy.DateAsc, currentId, page, pageSize);
					return result;
				case "datedesc":
					result = await _customerTransactionService.GetTransactionByCurrentId(search, CustomerTransactionOrderBy.DateDesc, currentId, page, pageSize);
					return result;
				default:
					return result;
			} 
		}
		[HttpGet("Current/Code/{currentCode}/Input")]
		public async Task<DataResult<IEnumerable<CustomerTransaction>>> GetInputTransactionByCurrentCode([FromQuery] string search = "", string orderBy = CustomerTransactionOrderBy.DateAsc, string currentCode = "", int page = 0, int pageSize = 20)
		{
			var result = new DataResult<IEnumerable<CustomerTransaction>>();
			switch (orderBy)
			{

				case "codedesc":
					result = await _customerTransactionService.GetInputTransactionByCurrentCode(search, CustomerTransactionOrderBy.CodeDesc, currentCode, page, pageSize);
					return result;
				case "codeasc":
					result = await _customerTransactionService.GetInputTransactionByCurrentCode(search, CustomerTransactionOrderBy.CodeAsc, currentCode, page, pageSize);
					return result;
				case "dateasc":
					result = await _customerTransactionService.GetInputTransactionByCurrentCode(search, CustomerTransactionOrderBy.DateAsc, currentCode, page, pageSize);
					return result;
				case "datedesc":
					result = await _customerTransactionService.GetInputTransactionByCurrentCode(search, CustomerTransactionOrderBy.DateDesc, currentCode, page, pageSize);
					return result;
				default:
					return result;
			} 
		}
		[HttpGet("Current/Id/{currentId:int}/Input")]
		public async Task<DataResult<IEnumerable<CustomerTransaction>>> GetInputTransactionByCurrentId([FromQuery] string search = "", string orderBy = CustomerTransactionOrderBy.DateAsc, int currentId = 0, int page = 0, int pageSize = 20)
		{
			var result = new DataResult<IEnumerable<CustomerTransaction>>();
			switch (orderBy)
			{

				case "codedesc":
					result = await _customerTransactionService.GetInputTransactionByCurrentId(search, CustomerTransactionOrderBy.CodeDesc, currentId, page, pageSize);
					return result;
				case "codeasc":
					result = await _customerTransactionService.GetInputTransactionByCurrentId(search, CustomerTransactionOrderBy.CodeAsc, currentId, page, pageSize);
					return result;
				case "dateasc":
					result = await _customerTransactionService.GetInputTransactionByCurrentId(search, CustomerTransactionOrderBy.DateAsc, currentId, page, pageSize);
					return result;
				case "datedesc":
					result = await _customerTransactionService.GetInputTransactionByCurrentId(search, CustomerTransactionOrderBy.DateDesc, currentId, page, pageSize);
					return result;
				default:
					return result;
			} 
		}
		[HttpGet("Current/Code/{currentCode}/Output")]
		public async Task<DataResult<IEnumerable<CustomerTransaction>>> GetOutputTransactionByCurrentCode([FromQuery] string search = "", string orderBy = CustomerTransactionOrderBy.DateAsc, string currentCode = "", int page = 0, int pageSize = 20)
		{
			var result = new DataResult<IEnumerable<CustomerTransaction>>();
			switch (orderBy)
			{

				case "codedesc":
					result = await _customerTransactionService.GetOutputTransactionByCurrentCode(search, CustomerTransactionOrderBy.CodeDesc, currentCode, page, pageSize);
					return result;
				case "codeasc":
					result = await _customerTransactionService.GetOutputTransactionByCurrentCode(search, CustomerTransactionOrderBy.CodeAsc, currentCode, page, pageSize);
					return result;
				case "dateasc":
					result = await _customerTransactionService.GetOutputTransactionByCurrentCode(search, CustomerTransactionOrderBy.DateAsc, currentCode, page, pageSize);
					return result;
				case "datedesc":
					result = await _customerTransactionService.GetOutputTransactionByCurrentCode(search, CustomerTransactionOrderBy.DateDesc, currentCode, page, pageSize);
					return result;
				default:
					return result;
			} 
		}
		[HttpGet("Current/Id/{currentId:int}/Output")]
		public async Task<DataResult<IEnumerable<CustomerTransaction>>> GetOutputTransactionByCurrentId([FromQuery] string search = "", string orderBy = CustomerTransactionOrderBy.DateAsc, int currentId = 0, int page = 0, int pageSize = 20)
		{
			var result = new DataResult<IEnumerable<CustomerTransaction>>();
			switch (orderBy)
			{

				case "codedesc":
					result = await _customerTransactionService.GetOutputTransactionByCurrentId(search, CustomerTransactionOrderBy.CodeDesc, currentId, page, pageSize);
					return result;
				case "codeasc":
					result = await _customerTransactionService.GetOutputTransactionByCurrentId(search, CustomerTransactionOrderBy.CodeAsc, currentId, page, pageSize);
					return result;
				case "dateasc":
					result = await _customerTransactionService.GetOutputTransactionByCurrentId(search, CustomerTransactionOrderBy.DateAsc, currentId, page, pageSize);
					return result;
				case "datedesc":
					result = await _customerTransactionService.GetOutputTransactionByCurrentId(search, CustomerTransactionOrderBy.DateDesc, currentId, page, pageSize);
					return result;
				default:
					return result;
			} 
		}
	}
}
