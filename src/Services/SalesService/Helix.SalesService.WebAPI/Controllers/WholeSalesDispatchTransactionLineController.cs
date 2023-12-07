using Helix.SalesService.Application.Repository;
using Helix.SalesService.Domain.AggregateModels;
using Helix.SalesService.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Helix.SalesService.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WholeSalesDispatchTransactionLineController : ControllerBase
{
	IWholeSalesDispatchTransactionLineService _wholeSalesDispatchTransactionLineService;
    public WholeSalesDispatchTransactionLineController(IWholeSalesDispatchTransactionLineService wholeSalesDispatchTransactionLineService)
    {
        _wholeSalesDispatchTransactionLineService = wholeSalesDispatchTransactionLineService;
    }
	[HttpGet]
	public async Task<DataResult<IEnumerable<WholeSalesDispatchTransactionLine>>> GetAll()
	{
		var result = await _wholeSalesDispatchTransactionLineService.GetWholeSalesDispatchTransactionLinesAsync();
		return result;
	}

	[HttpGet("Id/{id:int}")]
	public async Task<DataResult<WholeSalesDispatchTransactionLine>> GetById(int id)
	{
		var result = await _wholeSalesDispatchTransactionLineService.GetWholeSalesDispatchTransactionLineByIdAsync(id);
		return result;
	}



	[HttpGet("Current/Id/{id:int}")]
	public async Task<DataResult<IEnumerable<WholeSalesDispatchTransactionLine>>> GetByCurrentId(int id)
	{
		var result = await _wholeSalesDispatchTransactionLineService.GetWholeSalesDispatchTransactionLinesByCurrentIdAsync(id);
		return result;
	}

	[HttpGet("Current/Code/{code}")]
	public async Task<DataResult<IEnumerable<WholeSalesDispatchTransactionLine>>> GetByCurrentCode(string code)
	{
		var result = await _wholeSalesDispatchTransactionLineService.GetWholeSalesDispatchTransactionLinesByCurrentCodeAsync(code);
		return result;
	}

	[HttpGet("Product/Id/{id:int}")]
	public async Task<DataResult<IEnumerable<WholeSalesDispatchTransactionLine>>> GetByProductId(int id)
	{
		var result = await _wholeSalesDispatchTransactionLineService.GetWholeSalesDispatchTransactionLinesByProductIdAsync(id);
		return result;
	}

	[HttpGet("Product/Code/{code}")]
	public async Task<DataResult<IEnumerable<WholeSalesDispatchTransactionLine>>> GetByProductCode(string code)
	{
		var result = await _wholeSalesDispatchTransactionLineService.GetWholeSalesDispatchTransactionLinesByProductCodeAsync(code);
		return result;
	}

	[HttpGet("Fiche/Id/{id:int}")]
	public async Task<DataResult<IEnumerable<WholeSalesDispatchTransactionLine>>> GetByFicheId(int id)
	{
		var result = await _wholeSalesDispatchTransactionLineService.GetWholeSalesDispatchTransactionLinesByFicheIdAsync(id);
		return result;
	}

	[HttpGet("Fiche/Code/{code}")]
	public async Task<DataResult<IEnumerable<WholeSalesDispatchTransactionLine>>> GetByFicheCode(string code)
	{
		var result = await _wholeSalesDispatchTransactionLineService.GetWholeSalesDispatchTransactionLinesByFicheCodeAsync(code);
		return result;
	}
}
