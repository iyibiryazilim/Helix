using Helix.ProductService.Application.Repository;
using Helix.ProductService.Domain.AggregateModels;
using Helix.ProductService.Domain.Models;
using Microsoft.AspNetCore.Mvc;


namespace Helix.ProductService.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TransferTransactionController : ControllerBase
{
	ITransferTransactionService _transferTransactionService;
	public TransferTransactionController(ITransferTransactionService transferTransactionService)
	{
		_transferTransactionService = transferTransactionService;
	}


	[HttpGet]
	public async Task<DataResult<IEnumerable<TransferTransaction>>> GetAll()
	{
		var result = await _transferTransactionService.GetTransferTransactionsAsync();
		return result;
	}

	[HttpGet("Id/{id:int}")]
	public async Task<DataResult<TransferTransaction>> GetById(int id)
	{
		var result = await _transferTransactionService.GetTransferTransactionByIdAsync(id);
		return result;
	}

	[HttpGet("Code/{code}")]
	public async Task<DataResult<TransferTransaction>> GetByCode(string code)
	{
		var result = await _transferTransactionService.GetTransferTransactionByCode(code);
		return result;
	}

	[HttpGet("Current/Id/{id:int}")]
	public async Task<DataResult<IEnumerable<TransferTransaction>>> GetByCurrentId(int id)
	{
		var result = await _transferTransactionService.GetTransferTransactionsByCurrentIdAsync(id);
		return result;
	}

	[HttpGet("Current/Code/{code}")]
	public async Task<DataResult<IEnumerable<TransferTransaction>>> GetByCurrentCode(string code)
	{
		var result = await _transferTransactionService.GetTransferTransactionsByCurrentCodeAsync(code);
		return result;
	}
}
