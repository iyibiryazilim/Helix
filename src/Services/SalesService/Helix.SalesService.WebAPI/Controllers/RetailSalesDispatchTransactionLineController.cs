using Helix.SalesService.Application.Repository;
using Helix.SalesService.Domain.AggregateModels;
using Helix.SalesService.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Helix.SalesService.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RetailSalesDispatchTransactionLineController : ControllerBase
{
	IRetailSalesDispatchTransactionLineService _retailSalesDispatchTransactionLineService;
	public RetailSalesDispatchTransactionLineController(IRetailSalesDispatchTransactionLineService retailSalesDispatchTransactionLineService)
	{
		_retailSalesDispatchTransactionLineService = retailSalesDispatchTransactionLineService;
	}
	[HttpGet]
	public async Task<DataResult<IEnumerable<RetailSalesDispatchTransactionLine>>> GetAll()
	{
		var result = await _retailSalesDispatchTransactionLineService.GetRetailSalesDispatchTransactionLinesAsync();
		return result;
	}

	[HttpGet("Id/{id:int}")]
	public async Task<DataResult<RetailSalesDispatchTransactionLine>> GetById(int id)
	{
		var result = await _retailSalesDispatchTransactionLineService.GetRetailSalesDispatchTransactionLineByIdAsync(id);
		return result;
	}


	[HttpGet("Current/Id/{id:int}")]
	public async Task<DataResult<IEnumerable<RetailSalesDispatchTransactionLine>>> GetByCurrentId(int id)
	{
		var result = await _retailSalesDispatchTransactionLineService.GetRetailSalesDispatchTransactionLinesByCurrentIdAsync(id);
		return result;
	}

	[HttpGet("Current/Code/{code}")]
	public async Task<DataResult<IEnumerable<RetailSalesDispatchTransactionLine>>> GetByCurrentCode(string code)
	{
		var result = await _retailSalesDispatchTransactionLineService.GetRetailSalesDispatchTransactionLinesByCurrentCodeAsync(code);
		return result;
	}

	[HttpGet("Product/Id/{id:int}")]
	public async Task<DataResult<IEnumerable<RetailSalesDispatchTransactionLine>>> GetByProductId(int id)
	{
		var result = await _retailSalesDispatchTransactionLineService.GetRetailSalesDispatchTransactionLinesByProductIdAsync(id);
		return result;
	}

	[HttpGet("Product/Code/{code}")]
	public async Task<DataResult<IEnumerable<RetailSalesDispatchTransactionLine>>> GetByProductCode(string code)
	{
		var result = await _retailSalesDispatchTransactionLineService.GetRetailSalesDispatchTransactionLinesByProductCodeAsync(code);
		return result;
	}

	[HttpGet("Fiche/Id/{id:int}")]
	public async Task<DataResult<IEnumerable<RetailSalesDispatchTransactionLine>>> GetByFicheId(int id)
	{
		var result = await _retailSalesDispatchTransactionLineService.GetRetailSalesDispatchTransactionLinesByFicheIdAsync(id);
		return result;
	}

	[HttpGet("Fiche/Code/{code}")]
	public async Task<DataResult<IEnumerable<RetailSalesDispatchTransactionLine>>> GetByFicheCode(string code)
	{
		var result = await _retailSalesDispatchTransactionLineService.GetRetailSalesDispatchTransactionLinesByFicheCodeAsync(code);
		return result;
	}
}
