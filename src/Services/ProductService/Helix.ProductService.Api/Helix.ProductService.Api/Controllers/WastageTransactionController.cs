using Helix.ProductService.Application.Repository;
using Helix.ProductService.Domain.AggregateModels;
using Helix.ProductService.Domain.Models;
using Microsoft.AspNetCore.Mvc;


namespace Helix.ProductService.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WastageTransactionController : ControllerBase
{
	IWastageTransactionService _wastageTransactionService;
	public WastageTransactionController(IWastageTransactionService wastageTransactionService)
	{
		_wastageTransactionService = wastageTransactionService;
	}


	[HttpGet]
	public async Task<DataResult<IEnumerable<WastageTransaction>>> GetAll()
	{
		var result = await _wastageTransactionService.GetWastageTransactionsAsync();
		return result;
	}

	[HttpGet("Id/{id:int}")]
	public async Task<DataResult<WastageTransaction>> GetById(int id)
	{
		var result = await _wastageTransactionService.GetWastageTransactionByIdAsync(id);
		return result;
	}

	[HttpGet("Code/{code}")]
	public async Task<DataResult<WastageTransaction>> GetByCode(string code)
	{
		var result = await _wastageTransactionService.GetWastageTransactionByCode(code);
		return result;
	}

	[HttpGet("Current/Id/{id:int}")]
	public async Task<DataResult<IEnumerable<WastageTransaction>>> GetByCurrentId(int id)
	{
		var result = await _wastageTransactionService.GetWastageTransactionsByCurrentIdAsync(id);
		return result;
	}

	[HttpGet("Current/Code/{code}")]
	public async Task<DataResult<IEnumerable<WastageTransaction>>> GetByCurrentCode(string code)
	{
		var result = await _wastageTransactionService.GetWastageTransactionsByCurrentCodeAsync(code);
		return result;
	}
}
