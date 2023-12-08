using Helix.ProductService.Application.Repository;
using Helix.ProductService.Domain.Models;
using Helix.ProductService.Domain.AggregateModels;
using Microsoft.AspNetCore.Mvc;


namespace Helix.ProductService.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ConsumableTransactionController : ControllerBase
{
	IConsumableTransactionService _consumableTransactionService;
	public ConsumableTransactionController( IConsumableTransactionService consumableTransactionService)
	{
		_consumableTransactionService = consumableTransactionService;
	}

	[HttpGet]
	public async Task<DataResult<IEnumerable<ConsumableTransaction>>> GetAll()
	{
		var result = await _consumableTransactionService.GetConsumableTransactionsAsync();
		return result;
	}

	[HttpGet("Id/{id:int}")]
	public async Task<DataResult<ConsumableTransaction>> GetById(int id)
	{
		var result = await _consumableTransactionService.GetConsumableTransactionByIdAsync(id);
		return result;
	}

	[HttpGet("Code/{code}")]
	public async Task<DataResult<ConsumableTransaction>> GetByCode(string code)
	{
		var result = await _consumableTransactionService.GetConsumableTransactionByCode(code);
		return result;
	}

	[HttpGet("Current/Id/{id:int}")]
	public async Task<DataResult<IEnumerable<ConsumableTransaction>>> GetByCurrentId(int id)
	{
		var result = await _consumableTransactionService.GetConsumableTransactionsByCurrentIdAsync(id);
		return result;
	}

	[HttpGet("Current/Code/{code}")]
	public async Task<DataResult<IEnumerable<ConsumableTransaction>>> GetByCurrentCode(string code)
	{
		var result = await _consumableTransactionService.GetConsumableTransactionsByCurrentCodeAsync(code);
		return result;
	}
}
