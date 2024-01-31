using Helix.ProductService.Application.Repository;
using Helix.ProductService.Domain.AggregateModels;
using Helix.ProductService.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Helix.ProductService.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class OutCountingTransactionLineController : ControllerBase
{
	IOutCountingTransactionLineService _outCountingTransactionLineService;
	public OutCountingTransactionLineController(IOutCountingTransactionLineService outCountingTransactionLineService)
	{
		_outCountingTransactionLineService = outCountingTransactionLineService;
	}

	[HttpGet]
	public async Task<DataResult<IEnumerable<OutCountingTransactionLine>>> GetAll()
	{
		var result = await _outCountingTransactionLineService.GetOutCountingTransactionLinesAsync();
		return result;
	}

	[HttpGet("Id/{id:int}")]
	public async Task<DataResult<OutCountingTransactionLine>> GetById(int id)
	{
		var result = await _outCountingTransactionLineService.GetOutCountingTransactionLineByIdAsync(id);
		return result;
	}



	[HttpGet("Current/Id/{id:int}")]
	public async Task<DataResult<IEnumerable<OutCountingTransactionLine>>> GetByCurrentId(int id)
	{
		var result = await _outCountingTransactionLineService.GetOutCountingTransactionLinesByCurrentIdAsync(id);
		return result;
	}

	[HttpGet("Current/Code/{code}")]
	public async Task<DataResult<IEnumerable<OutCountingTransactionLine>>> GetByCurrentCode(string code)
	{
		var result = await _outCountingTransactionLineService.GetOutCountingTransactionLinesByCurrentCodeAsync(code);
		return result;
	}

	[HttpGet("Product/Id/{id:int}")]
	public async Task<DataResult<IEnumerable<OutCountingTransactionLine>>> GetByProductId(int id)
	{
		var result = await _outCountingTransactionLineService.GetOutCountingTransactionLinesByProductIdAsync(id);
		return result;
	}

	[HttpGet("Product/Code/{code}")]
	public async Task<DataResult<IEnumerable<OutCountingTransactionLine>>> GetByProductCode(string code)
	{
		var result = await _outCountingTransactionLineService.GetOutCountingTransactionLinesByProductCodeAsync(code);
		return result;
	}

	[HttpGet("Fiche/Id/{id:int}")]
	public async Task<DataResult<IEnumerable<OutCountingTransactionLine>>> GetByFicheId(int id)
	{
		var result = await _outCountingTransactionLineService.GetOutCountingTransactionLinesByFicheIdAsync(id);
		return result;
	}

	[HttpGet("Fiche/Code/{code}")]
	public async Task<DataResult<IEnumerable<OutCountingTransactionLine>>> GetByFicheCode(string code)
	{
		var result = await _outCountingTransactionLineService.GetOutCountingTransactionLinesByFicheCodeAsync(code);
		return result;
	}
}
