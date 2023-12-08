using Helix.ProductService.Application.Repository;
using Helix.ProductService.Domain.AggregateModels;
using Helix.ProductService.Domain.Models;
using Microsoft.AspNetCore.Mvc;


namespace Helix.ProductService.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OutCountingTransactionController : ControllerBase
{
	IOutCountingTransactionService _outCountingTransactionService;
	public OutCountingTransactionController(IOutCountingTransactionService outCountingTransactionService)
	{
		_outCountingTransactionService = outCountingTransactionService;
	}

	[HttpGet]
	public async Task<DataResult<IEnumerable<OutCountingTransaction>>> GetAll()
	{
		var result = await _outCountingTransactionService.GetOutCountingTransactionsAsync();
		return result;
	}

	[HttpGet("Id/{id:int}")]
	public async Task<DataResult<OutCountingTransaction>> GetById(int id)
	{
		var result = await _outCountingTransactionService.GetOutCountingTransactionByIdAsync(id);
		return result;
	}

	[HttpGet("Code/{code}")]
	public async Task<DataResult<OutCountingTransaction>> GetByCode(string code)
	{
		var result = await _outCountingTransactionService.GetOutCountingTransactionByCode(code);
		return result;
	}

	[HttpGet("Current/Id/{id:int}")]
	public async Task<DataResult<IEnumerable<OutCountingTransaction>>> GetByCurrentId(int id)
	{
		var result = await _outCountingTransactionService.GetOutCountingTransactionsByCurrentIdAsync(id);
		return result;
	}

	[HttpGet("Current/Code/{code}")]
	public async Task<DataResult<IEnumerable<OutCountingTransaction>>> GetByCurrentCode(string code)
	{
		var result = await _outCountingTransactionService.GetOutCountingTransactionsByCurrentCodeAsync(code);
		return result;
	}
}
