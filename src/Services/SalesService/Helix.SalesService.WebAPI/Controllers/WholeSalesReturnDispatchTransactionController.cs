using Helix.SalesService.Application.Repository;
using Helix.SalesService.Domain.AggregateModels;
using Helix.SalesService.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Helix.SalesService.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class WholeSalesReturnDispatchTransactionController : ControllerBase
	{
		IWholeSalesReturnDispatchTransactionService _wholeSalesReturnDispatchTransactionService;
        public WholeSalesReturnDispatchTransactionController(IWholeSalesReturnDispatchTransactionService wholeSalesReturnDispatchTransactionService)
        {
            _wholeSalesReturnDispatchTransactionService = wholeSalesReturnDispatchTransactionService;
        }

		[HttpGet]
		public async Task<DataResult<IEnumerable<WholeSalesReturnDispatchTransaction>>> GetAll()
		{
			var result = await _wholeSalesReturnDispatchTransactionService.GetWholeSalesReturnDispatchTransactionsAsync();
			return result;
		}

		[HttpGet("Id/{id:int}")]
		public async Task<DataResult<WholeSalesReturnDispatchTransaction>> GetById(int id)
		{
			var result = await _wholeSalesReturnDispatchTransactionService.GetWholeSalesReturnDispatchTransactionByIdAsync(id);
			return result;
		}

		[HttpGet("Code/{code}")]
		public async Task<DataResult<WholeSalesReturnDispatchTransaction>> GetByCode(string code)
		{
			var result = await _wholeSalesReturnDispatchTransactionService.GetWholeSalesReturnDispatchTransactionByCode(code);
			return result;
		}

		[HttpGet("Current/Id/{id:int}")]
		public async Task<DataResult<IEnumerable<WholeSalesReturnDispatchTransaction>>> GetByCurrentId(int id)
		{
			var result = await _wholeSalesReturnDispatchTransactionService.GetWholeSalesReturnDispatchTransactionsByCurrentIdAsync(id);
			return result;
		}

		[HttpGet("Current/Code/{code}")]
		public async Task<DataResult<IEnumerable<WholeSalesReturnDispatchTransaction>>> GetByCurrentCode(string code)
		{
			var result = await _wholeSalesReturnDispatchTransactionService.GetWholeSalesReturnDispatchTransactionsByCurrentCodeAsync(code);
			return result;
		}
	}
}
