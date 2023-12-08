using Helix.ProductService.Application.Repository;
using Helix.ProductService.Domain.AggregateModels;
using Helix.ProductService.Domain.Models;
using Microsoft.AspNetCore.Mvc;


namespace Helix.ProductService.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WastageTransactionLineController : ControllerBase
{
	IWastageTransactionLineService _wastageTransactionLineService;
	public WastageTransactionLineController(IWastageTransactionLineService wastageTransactionLineService)
	{
		_wastageTransactionLineService = wastageTransactionLineService;
	}

	[HttpGet]
	public async Task<DataResult<IEnumerable<WastageTransactionLine>>> GetAll()
	{
		var result = await _wastageTransactionLineService.GetWastageTransactionLinesAsync();
		return result;
	}

	[HttpGet("Id/{id:int}")]
	public async Task<DataResult<WastageTransactionLine>> GetById(int id)
	{
		var result = await _wastageTransactionLineService.GetWastageTransactionLineByIdAsync(id);
		return result;
	}

	[HttpGet("Current/Id/{id:int}")]
	public async Task<DataResult<IEnumerable<WastageTransactionLine>>> GetByCurrentId(int id)
	{
		var result = await _wastageTransactionLineService.GetWastageTransactionLinesByCurrentIdAsync(id);
		return result;
	}

	[HttpGet("Current/Code/{code}")]
	public async Task<DataResult<IEnumerable<WastageTransactionLine>>> GetByCurrentCode(string code)
	{
		var result = await _wastageTransactionLineService.GetWastageTransactionLinesByCurrentCodeAsync(code);
		return result;
	}

	[HttpGet("Product/Id/{id:int}")]
	public async Task<DataResult<IEnumerable<WastageTransactionLine>>> GetByProductId(int id)
	{
		var result = await _wastageTransactionLineService.GetWastageTransactionLinesByProductIdAsync(id);
		return result;
	}

	[HttpGet("Product/Code/{code}")]
	public async Task<DataResult<IEnumerable<WastageTransactionLine>>> GetByProductCode(string code)
	{
		var result = await _wastageTransactionLineService.GetWastageTransactionLinesByProductCodeAsync(code);
		return result;
	}

	[HttpGet("Fiche/Id/{id:int}")]
	public async Task<DataResult<IEnumerable<WastageTransactionLine>>> GetByFicheId(int id)
	{
		var result = await _wastageTransactionLineService.GetWastageTransactionLinesByFicheIdAsync(id);
		return result;
	}

	[HttpGet("Fiche/Code/{code}")]
	public async Task<DataResult<IEnumerable<WastageTransactionLine>>> GetByFicheCode(string code)
	{
		var result = await _wastageTransactionLineService.GetWastageTransactionLinesByFicheCodeAsync(code);
		return result;
	}
}
