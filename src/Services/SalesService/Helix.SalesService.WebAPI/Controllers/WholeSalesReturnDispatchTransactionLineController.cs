using Helix.SalesService.Application.Repository;
using Helix.SalesService.Domain.AggregateModels;
using Helix.SalesService.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Helix.SalesService.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WholeSalesReturnDispatchTransactionLineController : ControllerBase
{
	IWholeSalesReturnDispatchTransactionLineService _wholeSalesReturnDispatchTransactionLineService;
	public WholeSalesReturnDispatchTransactionLineController(IWholeSalesReturnDispatchTransactionLineService wholeSalesReturnDispatchTransactionLineService)
	{
		_wholeSalesReturnDispatchTransactionLineService = wholeSalesReturnDispatchTransactionLineService;
	}

	[HttpGet]
	public async Task<DataResult<IEnumerable<WholeSalesReturnDispatchTransactionLine>>> GetAll()
	{
		var result = await _wholeSalesReturnDispatchTransactionLineService.GetWholeSalesReturnDispatchTransactionLinesAsync();
		return result;
	}

	[HttpGet("Id/{id:int}")]
	public async Task<DataResult<WholeSalesReturnDispatchTransactionLine>> GetById(int id)
	{
		var result = await _wholeSalesReturnDispatchTransactionLineService.GetWholeSalesReturnDispatchTransactionLineByIdAsync(id);
		return result;
	}

	[HttpGet("Current/Id/{id:int}")]
	public async Task<DataResult<IEnumerable<WholeSalesReturnDispatchTransactionLine>>> GetByCurrentId(int id)
	{
		var result = await _wholeSalesReturnDispatchTransactionLineService.GetWholeSalesReturnDispatchTransactionLinesByCurrentIdAsync(id);
		return result;
	}

	[HttpGet("Current/Code/{code}")]
	public async Task<DataResult<IEnumerable<WholeSalesReturnDispatchTransactionLine>>> GetByCurrentCode(string code)
	{
		var result = await _wholeSalesReturnDispatchTransactionLineService.GetWholeSalesReturnDispatchTransactionLinesByCurrentCodeAsync(code);
		return result;
	}

	[HttpGet("Product/Id/{id:int}")]
	public async Task<DataResult<IEnumerable<WholeSalesReturnDispatchTransactionLine>>> GetByProductId(int id)
	{
		var result = await _wholeSalesReturnDispatchTransactionLineService.GetWholeSalesReturnDispatchTransactionLinesByProductIdAsync(id);
		return result;
	}

	[HttpGet("Product/Code/{code}")]
	public async Task<DataResult<IEnumerable<WholeSalesReturnDispatchTransactionLine>>> GetByProductCode(string code)
	{
		var result = await _wholeSalesReturnDispatchTransactionLineService.GetWholeSalesReturnDispatchTransactionLinesByProductCodeAsync(code);
		return result;
	}

	[HttpGet("Fiche/Id/{id:int}")]
	public async Task<DataResult<IEnumerable<WholeSalesReturnDispatchTransactionLine>>> GetByFicheId(int id)
	{
		var result = await _wholeSalesReturnDispatchTransactionLineService.GetWholeSalesReturnDispatchTransactionLinesByFicheIdAsync(id);
		return result;
	}

	[HttpGet("Fiche/Code/{code}")]
	public async Task<DataResult<IEnumerable<WholeSalesReturnDispatchTransactionLine>>> GetByFicheCode(string code)
	{
		var result = await _wholeSalesReturnDispatchTransactionLineService.GetWholeSalesReturnDispatchTransactionLinesByFicheCodeAsync(code);
		return result;
	}
}
