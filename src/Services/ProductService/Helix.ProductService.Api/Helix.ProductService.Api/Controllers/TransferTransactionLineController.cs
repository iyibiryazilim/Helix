using Helix.ProductService.Application.Repository;
using Helix.ProductService.Domain.AggregateModels;
using Helix.ProductService.Domain.Models;
using Microsoft.AspNetCore.Mvc;


namespace Helix.ProductService.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TransferTransactionLineController : ControllerBase
{
	ITransferTransactionLineService _transferTransactionLineService;
	public TransferTransactionLineController(ITransferTransactionLineService transferTransactionLineService)
	{
		_transferTransactionLineService = transferTransactionLineService;
	}

	[HttpGet]
	public async Task<DataResult<IEnumerable<TransferTransactionLine>>> GetAll()
	{
		var result = await _transferTransactionLineService.GetTransferTransactionLinesAsync();
		return result;
	}

	[HttpGet("Id/{id:int}")]
	public async Task<DataResult<TransferTransactionLine>> GetById(int id)
	{
		var result = await _transferTransactionLineService.GetTransferTransactionLineByIdAsync(id);
		return result;
	}

	[HttpGet("Current/Id/{id:int}")]
	public async Task<DataResult<IEnumerable<TransferTransactionLine>>> GetByCurrentId(int id)
	{
		var result = await _transferTransactionLineService.GetTransferTransactionLinesByCurrentIdAsync(id);
		return result;
	}

	[HttpGet("Current/Code/{code}")]
	public async Task<DataResult<IEnumerable<TransferTransactionLine>>> GetByCurrentCode(string code)
	{
		var result = await _transferTransactionLineService.GetTransferTransactionLinesByCurrentCodeAsync(code);
		return result;
	}

	[HttpGet("Product/Id/{id:int}")]
	public async Task<DataResult<IEnumerable<TransferTransactionLine>>> GetByProductId(int id)
	{
		var result = await _transferTransactionLineService.GetTransferTransactionLinesByProductIdAsync(id);
		return result;
	}

	[HttpGet("Product/Code/{code}")]
	public async Task<DataResult<IEnumerable<TransferTransactionLine>>> GetByProductCode(string code)
	{
		var result = await _transferTransactionLineService.GetTransferTransactionLinesByProductCodeAsync(code);
		return result;
	}

	[HttpGet("Fiche/Id/{id:int}")]
	public async Task<DataResult<IEnumerable<TransferTransactionLine>>> GetByFicheId(int id)
	{
		var result = await _transferTransactionLineService.GetTransferTransactionLinesByFicheIdAsync(id);
		return result;
	}

	[HttpGet("Fiche/Code/{code}")]
	public async Task<DataResult<IEnumerable<TransferTransactionLine>>> GetByFicheCode(string code)
	{
		var result = await _transferTransactionLineService.GetTransferTransactionLinesByFicheCodeAsync(code);
		return result;
	}
}
