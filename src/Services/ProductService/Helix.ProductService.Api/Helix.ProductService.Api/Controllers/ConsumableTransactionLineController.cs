using Helix.ProductService.Application.Repository;
using Helix.ProductService.Domain.Models;
using Helix.ProductService.Domain.AggregateModels;
using Microsoft.AspNetCore.Mvc;


namespace Helix.ProductService.Api.Controllers;


[Route("api/[controller]")]
[ApiController]
public class ConsumableTransactionLineController : ControllerBase
{
	IConsumableTransactionLineService _consumableTransactionLineService;
	public ConsumableTransactionLineController(IConsumableTransactionLineService consumableTransactionLineService)
	{
		_consumableTransactionLineService = consumableTransactionLineService;
	}

	[HttpGet]
	public async Task<DataResult<IEnumerable<ConsumableTransactionLine>>> GetAll()
	{
		var result = await _consumableTransactionLineService.GetConsumableTransactionLinesAsync();
		return result;
	}

	[HttpGet("Id/{id:int}")]
	public async Task<DataResult<ConsumableTransactionLine>> GetById(int id)
	{
		var result = await _consumableTransactionLineService.GetConsumableTransactionLineByIdAsync(id);
		return result;
	}



	[HttpGet("Current/Id/{id:int}")]
	public async Task<DataResult<IEnumerable<ConsumableTransactionLine>>> GetByCurrentId(int id)
	{
		var result = await _consumableTransactionLineService.GetConsumableTransactionLinesByCurrentIdAsync(id);
		return result;
	}

	[HttpGet("Current/Code/{code}")]
	public async Task<DataResult<IEnumerable<ConsumableTransactionLine>>> GetByCurrentCode(string code)
	{
		var result = await _consumableTransactionLineService.GetConsumableTransactionLinesByCurrentCodeAsync(code);
		return result;
	}

	[HttpGet("Product/Id/{id:int}")]
	public async Task<DataResult<IEnumerable<ConsumableTransactionLine>>> GetByProductId(int id)
	{
		var result = await _consumableTransactionLineService.GetConsumableTransactionLinesByProductIdAsync(id);
		return result;
	}

	[HttpGet("Product/Code/{code}")]
	public async Task<DataResult<IEnumerable<ConsumableTransactionLine>>> GetByProductCode(string code)
	{
		var result = await _consumableTransactionLineService.GetConsumableTransactionLinesByProductCodeAsync(code);
		return result;
	}

	[HttpGet("Fiche/Id/{id:int}")]
	public async Task<DataResult<IEnumerable<ConsumableTransactionLine>>> GetByFicheId(int id)
	{
		var result = await _consumableTransactionLineService.GetConsumableTransactionLinesByFicheIdAsync(id);
		return result;
	}

	[HttpGet("Fiche/Code/{code}")]
	public async Task<DataResult<IEnumerable<ConsumableTransactionLine>>> GetByFicheCode(string code)
	{
		var result = await _consumableTransactionLineService.GetConsumableTransactionLinesByFicheCodeAsync(code);
		return result;
	}
}
