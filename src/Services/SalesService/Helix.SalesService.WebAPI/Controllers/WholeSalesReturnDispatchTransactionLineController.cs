using Helix.SalesService.Application.Repository;
using Helix.SalesService.Domain.AggregateModels;
using Helix.SalesService.Domain.Models;
using Helix.SalesService.Infrastructure.Helper.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Helix.SalesService.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class WholeSalesReturnDispatchTransactionLineController : ControllerBase
{
	IWholeSalesReturnDispatchTransactionLineService _wholeSalesReturnDispatchTransactionLineService;
	public WholeSalesReturnDispatchTransactionLineController(IWholeSalesReturnDispatchTransactionLineService wholeSalesReturnDispatchTransactionLineService)
	{
		_wholeSalesReturnDispatchTransactionLineService = wholeSalesReturnDispatchTransactionLineService;
	}

	[HttpGet]
	public async Task<DataResult<IEnumerable<WholeSalesReturnDispatchTransactionLine>>> GetAll([FromQuery] string search = "", string orderBy = WholeSalesReturnDispatchLineOrderBy.DateDesc, int page = 0, int pageSize = 20)
	{
		DataResult<IEnumerable<WholeSalesReturnDispatchTransactionLine>> result = new();
		switch (orderBy)
		{

			case "customernamedesc":
				result = await _wholeSalesReturnDispatchTransactionLineService.GetWholeSalesReturnDispatchTransactionLinesAsync(search, WholeSalesReturnDispatchLineOrderBy.CustomerNameDesc, page, pageSize);
				return result;
			case "customernameasc":
				result = await _wholeSalesReturnDispatchTransactionLineService.GetWholeSalesReturnDispatchTransactionLinesAsync(search, WholeSalesReturnDispatchLineOrderBy.CustomerNameAsc, page, pageSize);
				return result;
			case "customercodedesc":
				result = await _wholeSalesReturnDispatchTransactionLineService.GetWholeSalesReturnDispatchTransactionLinesAsync(search, WholeSalesReturnDispatchLineOrderBy.CustomerCodeDesc, page, pageSize);
				return result;
			case "customercodeasc":
				result = await _wholeSalesReturnDispatchTransactionLineService.GetWholeSalesReturnDispatchTransactionLinesAsync(search, WholeSalesReturnDispatchLineOrderBy.CustomerCodeAsc, page, pageSize);
				return result;
			case "productnameasc":
				result = await _wholeSalesReturnDispatchTransactionLineService.GetWholeSalesReturnDispatchTransactionLinesAsync(search, WholeSalesReturnDispatchLineOrderBy.ProductNameAsc, page, pageSize);
				return result;
			case "productnamedesc":
				result = await _wholeSalesReturnDispatchTransactionLineService.GetWholeSalesReturnDispatchTransactionLinesAsync(search, WholeSalesReturnDispatchLineOrderBy.ProductNameDesc, page, pageSize);
				return result;
			case "productcodeasc":
				result = await _wholeSalesReturnDispatchTransactionLineService.GetWholeSalesReturnDispatchTransactionLinesAsync(search, WholeSalesReturnDispatchLineOrderBy.ProductCodeAsc, page, pageSize);
				return result;
			case "productcodedesc":
				result = await _wholeSalesReturnDispatchTransactionLineService.GetWholeSalesReturnDispatchTransactionLinesAsync(search, WholeSalesReturnDispatchLineOrderBy.ProductCodeDesc, page, pageSize);
				return result;
			case "dateasc":
				result = await _wholeSalesReturnDispatchTransactionLineService.GetWholeSalesReturnDispatchTransactionLinesAsync(search, WholeSalesReturnDispatchLineOrderBy.DateAsc, page, pageSize);
				return result;
			case "datedesc":
				result = await _wholeSalesReturnDispatchTransactionLineService.GetWholeSalesReturnDispatchTransactionLinesAsync(search, WholeSalesReturnDispatchLineOrderBy.DateDesc, page, pageSize);
				return result;
			default:
				result = await _wholeSalesReturnDispatchTransactionLineService.GetWholeSalesReturnDispatchTransactionLinesAsync(search, orderBy, page, pageSize);
				return result;
		}
	}

	[HttpGet("Id/{id:int}")]
	public async Task<DataResult<WholeSalesReturnDispatchTransactionLine>> GetById(int id)
	{
		var result = await _wholeSalesReturnDispatchTransactionLineService.GetWholeSalesReturnDispatchTransactionLineByIdAsync(id);
		return result;
	}


	[HttpGet("Current/Id/{id:int}")]
	public async Task<DataResult<IEnumerable<WholeSalesReturnDispatchTransactionLine>>> GetByCurrentId(int id, [FromQuery] string search = "", string orderBy = WholeSalesReturnDispatchLineOrderBy.DateDesc, int page = 0, int pageSize = 20)
	{
		DataResult<IEnumerable<WholeSalesReturnDispatchTransactionLine>> result = new();
		switch (orderBy)
		{

			case "customernamedesc":
				result = await _wholeSalesReturnDispatchTransactionLineService.GetWholeSalesReturnDispatchTransactionLinesByCurrentIdAsync(id, search, WholeSalesReturnDispatchLineOrderBy.CustomerNameDesc, page, pageSize);
				return result;
			case "customernameasc":
				result = await _wholeSalesReturnDispatchTransactionLineService.GetWholeSalesReturnDispatchTransactionLinesByCurrentIdAsync(id, search, WholeSalesReturnDispatchLineOrderBy.CustomerNameAsc, page, pageSize);
				return result;
			case "customercodedesc":
				result = await _wholeSalesReturnDispatchTransactionLineService.GetWholeSalesReturnDispatchTransactionLinesByCurrentIdAsync(id, search, WholeSalesReturnDispatchLineOrderBy.CustomerCodeDesc, page, pageSize);
				return result;
			case "customercodeasc":
				result = await _wholeSalesReturnDispatchTransactionLineService.GetWholeSalesReturnDispatchTransactionLinesByCurrentIdAsync(id, search, WholeSalesReturnDispatchLineOrderBy.CustomerCodeAsc, page, pageSize);
				return result;
			case "productnameasc":
				result = await _wholeSalesReturnDispatchTransactionLineService.GetWholeSalesReturnDispatchTransactionLinesByCurrentIdAsync(id, search, WholeSalesReturnDispatchLineOrderBy.ProductNameAsc, page, pageSize);
				return result;
			case "productnamedesc":
				result = await _wholeSalesReturnDispatchTransactionLineService.GetWholeSalesReturnDispatchTransactionLinesByCurrentIdAsync(id, search, WholeSalesReturnDispatchLineOrderBy.ProductNameDesc, page, pageSize);
				return result;
			case "productcodeasc":
				result = await _wholeSalesReturnDispatchTransactionLineService.GetWholeSalesReturnDispatchTransactionLinesByCurrentIdAsync(id, search, WholeSalesReturnDispatchLineOrderBy.ProductCodeAsc, page, pageSize);
				return result;
			case "productcodedesc":
				result = await _wholeSalesReturnDispatchTransactionLineService.GetWholeSalesReturnDispatchTransactionLinesByCurrentIdAsync(id, search, WholeSalesReturnDispatchLineOrderBy.ProductCodeDesc, page, pageSize);
				return result;
			case "dateasc":
				result = await _wholeSalesReturnDispatchTransactionLineService.GetWholeSalesReturnDispatchTransactionLinesByCurrentIdAsync(id, search, WholeSalesReturnDispatchLineOrderBy.DateAsc, page, pageSize);
				return result;
			case "datedesc":
				result = await _wholeSalesReturnDispatchTransactionLineService.GetWholeSalesReturnDispatchTransactionLinesByCurrentIdAsync(id, search, WholeSalesReturnDispatchLineOrderBy.DateDesc, page, pageSize);
				return result;
			default:
				result = await _wholeSalesReturnDispatchTransactionLineService.GetWholeSalesReturnDispatchTransactionLinesByCurrentIdAsync(id, search, orderBy, page, pageSize);
				return result;
		}
	}

	[HttpGet("Current/Code/{code}")]
	public async Task<DataResult<IEnumerable<WholeSalesReturnDispatchTransactionLine>>> GetByCurrentCode(string code, [FromQuery] string search = "", string orderBy = WholeSalesReturnDispatchLineOrderBy.DateDesc, int page = 0, int pageSize = 20)
	{
		DataResult<IEnumerable<WholeSalesReturnDispatchTransactionLine>> result = new();
		switch (orderBy)
		{

			case "customernamedesc":
				result = await _wholeSalesReturnDispatchTransactionLineService.GetWholeSalesReturnDispatchTransactionLinesByCurrentCodeAsync(code, search, WholeSalesReturnDispatchLineOrderBy.CustomerNameDesc, page, pageSize);
				return result;
			case "customernameasc":
				result = await _wholeSalesReturnDispatchTransactionLineService.GetWholeSalesReturnDispatchTransactionLinesByCurrentCodeAsync(code, search, WholeSalesReturnDispatchLineOrderBy.CustomerNameAsc, page, pageSize);
				return result;
			case "customercodedesc":
				result = await _wholeSalesReturnDispatchTransactionLineService.GetWholeSalesReturnDispatchTransactionLinesByCurrentCodeAsync(code, search, WholeSalesReturnDispatchLineOrderBy.CustomerCodeDesc, page, pageSize);
				return result;
			case "customercodeasc":
				result = await _wholeSalesReturnDispatchTransactionLineService.GetWholeSalesReturnDispatchTransactionLinesByCurrentCodeAsync(code, search, WholeSalesReturnDispatchLineOrderBy.CustomerCodeAsc, page, pageSize);
				return result;
			case "productnameasc":
				result = await _wholeSalesReturnDispatchTransactionLineService.GetWholeSalesReturnDispatchTransactionLinesByCurrentCodeAsync(code, search, WholeSalesReturnDispatchLineOrderBy.ProductNameAsc, page, pageSize);
				return result;
			case "productnamedesc":
				result = await _wholeSalesReturnDispatchTransactionLineService.GetWholeSalesReturnDispatchTransactionLinesByCurrentCodeAsync(code, search, WholeSalesReturnDispatchLineOrderBy.ProductNameDesc, page, pageSize);
				return result;
			case "productcodeasc":
				result = await _wholeSalesReturnDispatchTransactionLineService.GetWholeSalesReturnDispatchTransactionLinesByCurrentCodeAsync(code, search, WholeSalesReturnDispatchLineOrderBy.ProductCodeAsc, page, pageSize);
				return result;
			case "productcodedesc":
				result = await _wholeSalesReturnDispatchTransactionLineService.GetWholeSalesReturnDispatchTransactionLinesByCurrentCodeAsync(code, search, WholeSalesReturnDispatchLineOrderBy.ProductCodeDesc, page, pageSize);
				return result;
			case "dateasc":
				result = await _wholeSalesReturnDispatchTransactionLineService.GetWholeSalesReturnDispatchTransactionLinesByCurrentCodeAsync(code, search, WholeSalesReturnDispatchLineOrderBy.DateAsc, page, pageSize);
				return result;
			case "datedesc":
				result = await _wholeSalesReturnDispatchTransactionLineService.GetWholeSalesReturnDispatchTransactionLinesByCurrentCodeAsync(code, search, WholeSalesReturnDispatchLineOrderBy.DateDesc, page, pageSize);
				return result;
			default:
				result = await _wholeSalesReturnDispatchTransactionLineService.GetWholeSalesReturnDispatchTransactionLinesByCurrentCodeAsync(code, search, orderBy, page, pageSize);
				return result;
		}
	}

	[HttpGet("Product/Id/{id:int}")]
	public async Task<DataResult<IEnumerable<WholeSalesReturnDispatchTransactionLine>>> GetByProductId(int id, [FromQuery] string search = "", string orderBy = WholeSalesReturnDispatchLineOrderBy.DateDesc, int page = 0, int pageSize = 20)
	{
		DataResult<IEnumerable<WholeSalesReturnDispatchTransactionLine>> result = new();
		switch (orderBy)
		{

			case "customernamedesc":
				result = await _wholeSalesReturnDispatchTransactionLineService.GetWholeSalesReturnDispatchTransactionLinesByProductIdAsync(id, search, WholeSalesReturnDispatchLineOrderBy.CustomerNameDesc, page, pageSize);
				return result;
			case "customernameasc":
				result = await _wholeSalesReturnDispatchTransactionLineService.GetWholeSalesReturnDispatchTransactionLinesByProductIdAsync(id, search, WholeSalesReturnDispatchLineOrderBy.CustomerNameAsc, page, pageSize);
				return result;
			case "customercodedesc":
				result = await _wholeSalesReturnDispatchTransactionLineService.GetWholeSalesReturnDispatchTransactionLinesByProductIdAsync(id, search, WholeSalesReturnDispatchLineOrderBy.CustomerCodeDesc, page, pageSize);
				return result;
			case "customercodeasc":
				result = await _wholeSalesReturnDispatchTransactionLineService.GetWholeSalesReturnDispatchTransactionLinesByProductIdAsync(id, search, WholeSalesReturnDispatchLineOrderBy.CustomerCodeAsc, page, pageSize);
				return result;
			case "productnameasc":
				result = await _wholeSalesReturnDispatchTransactionLineService.GetWholeSalesReturnDispatchTransactionLinesByProductIdAsync(id, search, WholeSalesReturnDispatchLineOrderBy.ProductNameAsc, page, pageSize);
				return result;
			case "productnamedesc":
				result = await _wholeSalesReturnDispatchTransactionLineService.GetWholeSalesReturnDispatchTransactionLinesByProductIdAsync(id, search, WholeSalesReturnDispatchLineOrderBy.ProductNameDesc, page, pageSize);
				return result;
			case "productcodeasc":
				result = await _wholeSalesReturnDispatchTransactionLineService.GetWholeSalesReturnDispatchTransactionLinesByProductIdAsync(id, search, WholeSalesReturnDispatchLineOrderBy.ProductCodeAsc, page, pageSize);
				return result;
			case "productcodedesc":
				result = await _wholeSalesReturnDispatchTransactionLineService.GetWholeSalesReturnDispatchTransactionLinesByProductIdAsync(id, search, WholeSalesReturnDispatchLineOrderBy.ProductCodeDesc, page, pageSize);
				return result;
			case "dateasc":
				result = await _wholeSalesReturnDispatchTransactionLineService.GetWholeSalesReturnDispatchTransactionLinesByProductIdAsync(id, search, WholeSalesReturnDispatchLineOrderBy.DateAsc, page, pageSize);
				return result;
			case "datedesc":
				result = await _wholeSalesReturnDispatchTransactionLineService.GetWholeSalesReturnDispatchTransactionLinesByProductIdAsync(id, search, WholeSalesReturnDispatchLineOrderBy.DateDesc, page, pageSize);
				return result;
			default:
				result = await _wholeSalesReturnDispatchTransactionLineService.GetWholeSalesReturnDispatchTransactionLinesByProductIdAsync(id, search, orderBy, page, pageSize);
				return result;
		}
	}

	[HttpGet("Product/Code/{code}")]
	public async Task<DataResult<IEnumerable<WholeSalesReturnDispatchTransactionLine>>> GetByProductCode(string code, [FromQuery] string search = "", string orderBy = WholeSalesReturnDispatchLineOrderBy.DateDesc, int page = 0, int pageSize = 20)
	{
		DataResult<IEnumerable<WholeSalesReturnDispatchTransactionLine>> result = new();
		switch (orderBy)
		{

			case "customernamedesc":
				result = await _wholeSalesReturnDispatchTransactionLineService.GetWholeSalesReturnDispatchTransactionLinesByProductCodeAsync(code, search, WholeSalesReturnDispatchLineOrderBy.CustomerNameDesc, page, pageSize);
				return result;
			case "customernameasc":
				result = await _wholeSalesReturnDispatchTransactionLineService.GetWholeSalesReturnDispatchTransactionLinesByProductCodeAsync(code, search, WholeSalesReturnDispatchLineOrderBy.CustomerNameAsc, page, pageSize);
				return result;
			case "customercodedesc":
				result = await _wholeSalesReturnDispatchTransactionLineService.GetWholeSalesReturnDispatchTransactionLinesByProductCodeAsync(code, search, WholeSalesReturnDispatchLineOrderBy.CustomerCodeDesc, page, pageSize);
				return result;
			case "customercodeasc":
				result = await _wholeSalesReturnDispatchTransactionLineService.GetWholeSalesReturnDispatchTransactionLinesByProductCodeAsync(code, search, WholeSalesReturnDispatchLineOrderBy.CustomerCodeAsc, page, pageSize);
				return result;
			case "productnameasc":
				result = await _wholeSalesReturnDispatchTransactionLineService.GetWholeSalesReturnDispatchTransactionLinesByProductCodeAsync(code, search, WholeSalesReturnDispatchLineOrderBy.ProductNameAsc, page, pageSize);
				return result;
			case "productnamedesc":
				result = await _wholeSalesReturnDispatchTransactionLineService.GetWholeSalesReturnDispatchTransactionLinesByProductCodeAsync(code, search, WholeSalesReturnDispatchLineOrderBy.ProductNameDesc, page, pageSize);
				return result;
			case "productcodeasc":
				result = await _wholeSalesReturnDispatchTransactionLineService.GetWholeSalesReturnDispatchTransactionLinesByProductCodeAsync(code, search, WholeSalesReturnDispatchLineOrderBy.ProductCodeAsc, page, pageSize);
				return result;
			case "productcodedesc":
				result = await _wholeSalesReturnDispatchTransactionLineService.GetWholeSalesReturnDispatchTransactionLinesByProductCodeAsync(code, search, WholeSalesReturnDispatchLineOrderBy.ProductCodeDesc, page, pageSize);
				return result;
			case "dateasc":
				result = await _wholeSalesReturnDispatchTransactionLineService.GetWholeSalesReturnDispatchTransactionLinesByProductCodeAsync(code, search, WholeSalesReturnDispatchLineOrderBy.DateAsc, page, pageSize);
				return result;
			case "datedesc":
				result = await _wholeSalesReturnDispatchTransactionLineService.GetWholeSalesReturnDispatchTransactionLinesByProductCodeAsync(code, search, WholeSalesReturnDispatchLineOrderBy.DateDesc, page, pageSize);
				return result;
			default:
				result = await _wholeSalesReturnDispatchTransactionLineService.GetWholeSalesReturnDispatchTransactionLinesByProductCodeAsync(code, search, orderBy, page, pageSize);
				return result;
		}
	}

	[HttpGet("Fiche/Id/{id:int}")]
	public async Task<DataResult<IEnumerable<WholeSalesReturnDispatchTransactionLine>>> GetByFicheId(int id, [FromQuery] string search = "", string orderBy = WholeSalesReturnDispatchLineOrderBy.DateDesc, int page = 0, int pageSize = 20)
	{
		DataResult<IEnumerable<WholeSalesReturnDispatchTransactionLine>> result = new();
		switch (orderBy)
		{

			case "customernamedesc":
				result = await _wholeSalesReturnDispatchTransactionLineService.GetWholeSalesReturnDispatchTransactionLinesByFicheIdAsync(id, search, WholeSalesReturnDispatchLineOrderBy.CustomerNameDesc, page, pageSize);
				return result;
			case "customernameasc":
				result = await _wholeSalesReturnDispatchTransactionLineService.GetWholeSalesReturnDispatchTransactionLinesByFicheIdAsync(id, search, WholeSalesReturnDispatchLineOrderBy.CustomerNameAsc, page, pageSize);
				return result;
			case "customercodedesc":
				result = await _wholeSalesReturnDispatchTransactionLineService.GetWholeSalesReturnDispatchTransactionLinesByFicheIdAsync(id, search, WholeSalesReturnDispatchLineOrderBy.CustomerCodeDesc, page, pageSize);
				return result;
			case "customercodeasc":
				result = await _wholeSalesReturnDispatchTransactionLineService.GetWholeSalesReturnDispatchTransactionLinesByFicheIdAsync(id, search, WholeSalesReturnDispatchLineOrderBy.CustomerCodeAsc, page, pageSize);
				return result;
			case "productnameasc":
				result = await _wholeSalesReturnDispatchTransactionLineService.GetWholeSalesReturnDispatchTransactionLinesByFicheIdAsync(id, search, WholeSalesReturnDispatchLineOrderBy.ProductNameAsc, page, pageSize);
				return result;
			case "productnamedesc":
				result = await _wholeSalesReturnDispatchTransactionLineService.GetWholeSalesReturnDispatchTransactionLinesByFicheIdAsync(id, search, WholeSalesReturnDispatchLineOrderBy.ProductNameDesc, page, pageSize);
				return result;
			case "productcodeasc":
				result = await _wholeSalesReturnDispatchTransactionLineService.GetWholeSalesReturnDispatchTransactionLinesByFicheIdAsync(id, search, WholeSalesReturnDispatchLineOrderBy.ProductCodeAsc, page, pageSize);
				return result;
			case "productcodedesc":
				result = await _wholeSalesReturnDispatchTransactionLineService.GetWholeSalesReturnDispatchTransactionLinesByFicheIdAsync(id, search, WholeSalesReturnDispatchLineOrderBy.ProductCodeDesc, page, pageSize);
				return result;
			case "dateasc":
				result = await _wholeSalesReturnDispatchTransactionLineService.GetWholeSalesReturnDispatchTransactionLinesByFicheIdAsync(id, search, WholeSalesReturnDispatchLineOrderBy.DateAsc, page, pageSize);
				return result;
			case "datedesc":
				result = await _wholeSalesReturnDispatchTransactionLineService.GetWholeSalesReturnDispatchTransactionLinesByFicheIdAsync(id, search, WholeSalesReturnDispatchLineOrderBy.DateDesc, page, pageSize);
				return result;
			default:
				result = await _wholeSalesReturnDispatchTransactionLineService.GetWholeSalesReturnDispatchTransactionLinesByFicheIdAsync(id, search, orderBy, page, pageSize);
				return result;
		}
	}

	[HttpGet("Fiche/Code/{code}")]
	public async Task<DataResult<IEnumerable<WholeSalesReturnDispatchTransactionLine>>> GetByFicheCode(string code, [FromQuery] string search = "", string orderBy = WholeSalesReturnDispatchLineOrderBy.DateDesc, int page = 0, int pageSize = 20)
	{
		DataResult<IEnumerable<WholeSalesReturnDispatchTransactionLine>> result = new();
		switch (orderBy)
		{

			case "customernamedesc":
				result = await _wholeSalesReturnDispatchTransactionLineService.GetWholeSalesReturnDispatchTransactionLinesByFicheCodeAsync(code, search, WholeSalesReturnDispatchLineOrderBy.CustomerNameDesc, page, pageSize);
				return result;
			case "customernameasc":
				result = await _wholeSalesReturnDispatchTransactionLineService.GetWholeSalesReturnDispatchTransactionLinesByFicheCodeAsync(code, search, WholeSalesReturnDispatchLineOrderBy.CustomerNameAsc, page, pageSize);
				return result;
			case "customercodedesc":
				result = await _wholeSalesReturnDispatchTransactionLineService.GetWholeSalesReturnDispatchTransactionLinesByFicheCodeAsync(code, search, WholeSalesReturnDispatchLineOrderBy.CustomerCodeDesc, page, pageSize);
				return result;
			case "customercodeasc":
				result = await _wholeSalesReturnDispatchTransactionLineService.GetWholeSalesReturnDispatchTransactionLinesByFicheCodeAsync(code, search, WholeSalesReturnDispatchLineOrderBy.CustomerCodeAsc, page, pageSize);
				return result;
			case "productnameasc":
				result = await _wholeSalesReturnDispatchTransactionLineService.GetWholeSalesReturnDispatchTransactionLinesByFicheCodeAsync(code, search, WholeSalesReturnDispatchLineOrderBy.ProductNameAsc, page, pageSize);
				return result;
			case "productnamedesc":
				result = await _wholeSalesReturnDispatchTransactionLineService.GetWholeSalesReturnDispatchTransactionLinesByFicheCodeAsync(code, search, WholeSalesReturnDispatchLineOrderBy.ProductNameDesc, page, pageSize);
				return result;
			case "productcodeasc":
				result = await _wholeSalesReturnDispatchTransactionLineService.GetWholeSalesReturnDispatchTransactionLinesByFicheCodeAsync(code, search, WholeSalesReturnDispatchLineOrderBy.ProductCodeAsc, page, pageSize);
				return result;
			case "productcodedesc":
				result = await _wholeSalesReturnDispatchTransactionLineService.GetWholeSalesReturnDispatchTransactionLinesByFicheCodeAsync(code, search, WholeSalesReturnDispatchLineOrderBy.ProductCodeDesc, page, pageSize);
				return result;
			case "dateasc":
				result = await _wholeSalesReturnDispatchTransactionLineService.GetWholeSalesReturnDispatchTransactionLinesByFicheCodeAsync(code, search, WholeSalesReturnDispatchLineOrderBy.DateAsc, page, pageSize);
				return result;
			case "datedesc":
				result = await _wholeSalesReturnDispatchTransactionLineService.GetWholeSalesReturnDispatchTransactionLinesByFicheCodeAsync(code, search, WholeSalesReturnDispatchLineOrderBy.DateDesc, page, pageSize);
				return result;
			default:
				result = await _wholeSalesReturnDispatchTransactionLineService.GetWholeSalesReturnDispatchTransactionLinesByFicheCodeAsync(code, search, orderBy, page, pageSize);
				return result;
		}
	}
}
