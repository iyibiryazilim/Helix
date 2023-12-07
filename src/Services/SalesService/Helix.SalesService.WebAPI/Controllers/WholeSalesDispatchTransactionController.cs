using Helix.SalesService.Application.Repository;
using Helix.SalesService.Domain.AggregateModels;
using Helix.SalesService.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Helix.SalesService.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WholeSalesDispatchTransactionController : ControllerBase
{
	IWholeSalesDispatchTransactionService _wholeSalesDispatchTransactionService;
    public WholeSalesDispatchTransactionController(IWholeSalesDispatchTransactionService wholeSalesDispatchTransactionService)
    {
        _wholeSalesDispatchTransactionService = wholeSalesDispatchTransactionService;
    }
	[HttpGet]
	public async Task<DataResult<IEnumerable<WholeSalesDispatchTransaction>>> GetAll()
	{
		var result = await _wholeSalesDispatchTransactionService.GetWholeSalesDispatchTransactionsAsync();
		return result;
	}

	[HttpGet("Id/{id:int}")]
	public async Task<DataResult<WholeSalesDispatchTransaction>> GetById(int id)
	{
		var result = await _wholeSalesDispatchTransactionService.GetWholeSalesDispatchTransactionByIdAsync(id);
		return result;
	}

	[HttpGet("Code/{code}")]
	public async Task<DataResult<WholeSalesDispatchTransaction>> GetByCode(string code)
	{
		var result = await _wholeSalesDispatchTransactionService.GetWholeSalesDispatchTransactionByCode(code);
		return result;
	}

	[HttpGet("Current/Id/{id:int}")]
	public async Task<DataResult<IEnumerable<WholeSalesDispatchTransaction>>> GetByCurrentId(int id)
	{
		var result = await _wholeSalesDispatchTransactionService.GetWholeSalesDispatchTransactionsByCurrentIdAsync(id);
		return result;
	}

	[HttpGet("Current/Code/{code}")]
	public async Task<DataResult<IEnumerable<WholeSalesDispatchTransaction>>> GetByCurrentCode(string code)
	{
		var result = await _wholeSalesDispatchTransactionService.GetWholeSalesDispatchTransactionsByCurrentCodeAsync(code);
		return result;
	}
}
