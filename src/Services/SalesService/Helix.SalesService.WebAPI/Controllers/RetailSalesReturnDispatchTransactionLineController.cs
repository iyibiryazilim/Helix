using Helix.SalesService.Application.Repository;
using Helix.SalesService.Domain.AggregateModels;
using Helix.SalesService.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Helix.SalesService.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RetailSalesReturnDispatchTransactionLineController : ControllerBase
{
	IRetailSalesReturnDispatchTransactionLineService _retailSalesReturnDispatchTransactionLineService;

    public RetailSalesReturnDispatchTransactionLineController(IRetailSalesReturnDispatchTransactionLineService salesReturnDispatchTransactionLineService)
    {
			_retailSalesReturnDispatchTransactionLineService = salesReturnDispatchTransactionLineService;
    }

    [HttpGet]
	public async Task<DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>>> GetAll()
	{
		var result = await _retailSalesReturnDispatchTransactionLineService.GetRetailSalesReturnDispatchTransactionLinesAsync();
		return result;
	}

	[HttpGet("Id/{id:int}")]
	public async Task<DataResult<RetailSalesReturnDispatchTransactionLine>> GetById(int id)
	{
		var result = await _retailSalesReturnDispatchTransactionLineService.GetRetailSalesReturnDispatchTransactionLineByIdAsync(id);
		return result;
	}


	[HttpGet("Current/Id/{id:int}")]
	public async Task<DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>>> GetByCurrentId(int id)
	{
		var result = await _retailSalesReturnDispatchTransactionLineService.GetRetailSalesReturnDispatchTransactionLinesByCurrentIdAsync(id);
		return result;
	}

	[HttpGet("Current/Code/{code}")]
	public async Task<DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>>> GetByCurrentCode(string code)
	{
		var result = await _retailSalesReturnDispatchTransactionLineService.GetRetailSalesReturnDispatchTransactionLinesByCurrentCodeAsync(code);
		return result;
	}

	[HttpGet("Product/Id/{id:int}")]
	public async Task<DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>>> GetByProductId(int id)
	{
		var result = await _retailSalesReturnDispatchTransactionLineService.GetRetailSalesReturnDispatchTransactionLinesByProductIdAsync(id);
		return result;
	}

	[HttpGet("Product/Code/{code}")]
	public async Task<DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>>> GetByProductCode(string code)
	{
		var result = await _retailSalesReturnDispatchTransactionLineService.GetRetailSalesReturnDispatchTransactionLinesByProductCodeAsync(code);
		return result;
	}

	[HttpGet("Fiche/Id/{id:int}")]
	public async Task<DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>>> GetByFicheId(int id)
	{
		var result = await _retailSalesReturnDispatchTransactionLineService.GetRetailSalesReturnDispatchTransactionLinesByFicheIdAsync(id);
		return result;
	}

	[HttpGet("Fiche/Code/{code}")]
	public async Task<DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>>> GetByFicheCode(string code)
	{
		var result = await _retailSalesReturnDispatchTransactionLineService.GetRetailSalesReturnDispatchTransactionLinesByFicheCodeAsync(code);
		return result;
	}
}
