using Helix.SalesService.Application.Repository;
using Helix.SalesService.Domain.AggregateModels;
using Helix.SalesService.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Helix.SalesService.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RetailSalesDispatchTransactionController : ControllerBase
	{
		IRetailSalesDispatchTransactionService _retailSalesDispatchTransactionService;
        public RetailSalesDispatchTransactionController(IRetailSalesDispatchTransactionService retailSalesDispatchTransactionService)
        {
            _retailSalesDispatchTransactionService = retailSalesDispatchTransactionService;
        }

		[HttpGet]
		public async Task<DataResult<IEnumerable<RetailSalesDispatchTransaction>>> GetAll()
		{
			var result = await _retailSalesDispatchTransactionService.GetRetailSalesDispatchTransactionsAsync();
			return result;
		}

		[HttpGet("Id/{id:int}")]
		public async Task<DataResult<RetailSalesDispatchTransaction>> GetById(int id)
		{
			var result = await _retailSalesDispatchTransactionService.GetRetailSalesDispatchTransactionByIdAsync(id);
			return result;
		}

		[HttpGet("Code/{code}")]
		public async Task<DataResult<RetailSalesDispatchTransaction>> GetByCode(string code)
		{
			var result = await _retailSalesDispatchTransactionService.GetRetailSalesDispatchTransactionByCode(code);
			return result;
		}

		[HttpGet("Current/Id/{id:int}")]
		public async Task<DataResult<IEnumerable<RetailSalesDispatchTransaction>>> GetByCurrentId(int id)
		{
			var result = await _retailSalesDispatchTransactionService.GetRetailSalesDispatchTransactionsByCurrentIdAsync(id);
			return result;
		}

		[HttpGet("Current/Code/{code}")]
		public async Task<DataResult<IEnumerable<RetailSalesDispatchTransaction>>> GetByCurrentCode(string code)
		{
			var result = await _retailSalesDispatchTransactionService.GetRetailSalesDispatchTransactionsByCurrentCodeAsync(code);
			return result;
		}
	}
}
