using Helix.ProductService.Application.Repository;
using Helix.ProductService.Domain.AggregateModels;
using Helix.ProductService.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Helix.ProductService.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
//[Authorize]
public class ProductionTransactionLineController : ControllerBase
{
	IProductionTransactionLineService _productionTransactionLineService;
	public ProductionTransactionLineController(IProductionTransactionLineService productionTransactionLineService)
	{
		_productionTransactionLineService = productionTransactionLineService;
	}

	[HttpGet]
	public async Task<DataResult<IEnumerable<ProductionTransactionLine>>> GetAll()
	{
		var result = await _productionTransactionLineService.GetProductionTransactionLinesAsync();
		return result;
	}

	[HttpGet("Id/{id:int}")]
	public async Task<DataResult<ProductionTransactionLine>> GetById(int id)
	{
		var result = await _productionTransactionLineService.GetProductionTransactionLineByIdAsync(id);
		return result;
	}



	[HttpGet("Current/Id/{id:int}")]
	public async Task<DataResult<IEnumerable<ProductionTransactionLine>>> GetByCurrentId(int id)
	{
		var result = await _productionTransactionLineService.GetProductionTransactionLinesByCurrentIdAsync(id);
		return result;
	}

	[HttpGet("Current/Code/{code}")]
	public async Task<DataResult<IEnumerable<ProductionTransactionLine>>> GetByCurrentCode(string code)
	{
		var result = await _productionTransactionLineService.GetProductionTransactionLinesByCurrentCodeAsync(code);
		return result;
	}

	[HttpGet("Product/Id/{id:int}")]
	public async Task<DataResult<IEnumerable<ProductionTransactionLine>>> GetByProductId(int id)
	{
		var result = await _productionTransactionLineService.GetProductionTransactionLinesByProductIdAsync(id);
		return result;
	}

	[HttpGet("Product/Code/{code}")]
	public async Task<DataResult<IEnumerable<ProductionTransactionLine>>> GetByProductCode(string code)
	{
		var result = await _productionTransactionLineService.GetProductionTransactionLinesByProductCodeAsync(code);
		return result;
	}

	[HttpGet("Fiche/Id/{id:int}")]
	public async Task<DataResult<IEnumerable<ProductionTransactionLine>>> GetByFicheId(int id)
	{
		var result = await _productionTransactionLineService.GetProductionTransactionLinesByFicheIdAsync(id);
		return result;
	}

	[HttpGet("Fiche/Code/{code}")]
	public async Task<DataResult<IEnumerable<ProductionTransactionLine>>> GetByFicheCode(string code)
	{
		var result = await _productionTransactionLineService.GetProductionTransactionLinesByFicheCodeAsync(code);
		return result;
	}
}
