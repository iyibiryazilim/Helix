using Helix.ProductService.Application.Repository;
using Helix.ProductService.Domain.AggregateModels;
using Helix.ProductService.Domain.Models;
using Microsoft.AspNetCore.Mvc;


namespace Helix.ProductService.Api.Controllers;


[Route("api/[controller]")]
[ApiController]
public class InCountingTransactionLineController : ControllerBase
{
	IInCountingTransactionLineService _inCountingTransactionLineService;
	public InCountingTransactionLineController(IInCountingTransactionLineService inCountingTransactionLineService)
	{
		_inCountingTransactionLineService = inCountingTransactionLineService;
	}

	[HttpGet]
	public async Task<DataResult<IEnumerable<InCountingTransactionLine>>> GetAll()
	{
		var result = await _inCountingTransactionLineService.GetInCountingTransactionLinesAsync();
		return result;
	}

	[HttpGet("Id/{id:int}")]
	public async Task<DataResult<InCountingTransactionLine>> GetById(int id)
	{
		var result = await _inCountingTransactionLineService.GetInCountingTransactionLineByIdAsync(id);
		return result;
	}



	[HttpGet("Current/Id/{id:int}")]
	public async Task<DataResult<IEnumerable<InCountingTransactionLine>>> GetByCurrentId(int id)
	{
		var result = await _inCountingTransactionLineService.GetInCountingTransactionLinesByCurrentIdAsync(id);
		return result;
	}

	[HttpGet("Current/Code/{code}")]
	public async Task<DataResult<IEnumerable<InCountingTransactionLine>>> GetByCurrentCode(string code)
	{
		var result = await _inCountingTransactionLineService.GetInCountingTransactionLinesByCurrentCodeAsync(code);
		return result;
	}

	[HttpGet("Product/Id/{id:int}")]
	public async Task<DataResult<IEnumerable<InCountingTransactionLine>>> GetByProductId(int id)
	{
		var result = await _inCountingTransactionLineService.GetInCountingTransactionLinesByProductIdAsync(id);
		return result;
	}

	[HttpGet("Product/Code/{code}")]
	public async Task<DataResult<IEnumerable<InCountingTransactionLine>>> GetByProductCode(string code)
	{
		var result = await _inCountingTransactionLineService.GetInCountingTransactionLinesByProductCodeAsync(code);
		return result;
	}

	[HttpGet("Fiche/Id/{id:int}")]
	public async Task<DataResult<IEnumerable<InCountingTransactionLine>>> GetByFicheId(int id)
	{
		var result = await _inCountingTransactionLineService.GetInCountingTransactionLinesByFicheIdAsync(id);
		return result;
	}

	[HttpGet("Fiche/Code/{code}")]
	public async Task<DataResult<IEnumerable<InCountingTransactionLine>>> GetByFicheCode(string code)
	{
		var result = await _inCountingTransactionLineService.GetInCountingTransactionLinesByFicheCodeAsync(code);
		return result;
	}
}
