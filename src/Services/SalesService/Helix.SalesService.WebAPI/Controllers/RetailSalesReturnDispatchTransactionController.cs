using Helix.SalesService.Application.Repository;
using Helix.SalesService.Domain.AggregateModels;
using Helix.SalesService.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Helix.SalesService.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RetailSalesReturnDispatchTransactionController : ControllerBase
{
	IRetailSalesReturnDispatchTransactionService _retailSalesReturnDispatchTransactionService;
	public RetailSalesReturnDispatchTransactionController(IRetailSalesReturnDispatchTransactionService retailSalesReturnDispatchTransactionService)
	{
		_retailSalesReturnDispatchTransactionService = retailSalesReturnDispatchTransactionService;
	}
	[HttpGet]
	public async Task<DataResult<IEnumerable<RetailSalesReturnDispatchTransaction>>> GetAll()
	{
		var result = await _retailSalesReturnDispatchTransactionService.GetRetailSalesReturnDispatchTransactionsAsync();
		return result;
	}

	[HttpGet("Id/{id:int}")]
	public async Task<DataResult<RetailSalesReturnDispatchTransaction>> GetById(int id)
	{
		var result = await _retailSalesReturnDispatchTransactionService.GetRetailSalesReturnDispatchTransactionByIdAsync(id);
		return result;
	}

	[HttpGet("Code/{code}")]
	public async Task<DataResult<RetailSalesReturnDispatchTransaction>> GetByCode(string code)
	{
		var result = await _retailSalesReturnDispatchTransactionService.GetRetailSalesReturnDispatchTransactionByCode(code);
		return result;
	}

	[HttpGet("Current/Id/{id:int}")]
	public async Task<DataResult<IEnumerable<RetailSalesReturnDispatchTransaction>>> GetByCurrentId(int id)
	{
		var result = await _retailSalesReturnDispatchTransactionService.GetRetailSalesReturnDispatchTransactionsByCurrentIdAsync(id);
		return result;
	}

	[HttpGet("Current/Code/{code}")]
	public async Task<DataResult<IEnumerable<RetailSalesReturnDispatchTransaction>>> GetByCurrentCode(string code)
	{
		var result = await _retailSalesReturnDispatchTransactionService.GetRetailSalesReturnDispatchTransactionsByCurrentCodeAsync(code);
		return result;
	}
}
