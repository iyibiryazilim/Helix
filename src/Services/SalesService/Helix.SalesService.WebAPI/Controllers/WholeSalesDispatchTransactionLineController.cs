using Helix.SalesService.Application.Repository;
using Helix.SalesService.Domain.AggregateModels;
using Helix.SalesService.Domain.Models;
using Helix.SalesService.Infrastructure.Helper.Queries;
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
	public async Task<DataResult<IEnumerable<WholeSalesDispatchTransactionLine>>> GetAll([FromQuery] string search = "", string orderBy = WholeSalesDispatchLineOrderBy.DateDesc, int page = 0, int pageSize = 20)
	{
		DataResult<IEnumerable<WholeSalesDispatchTransactionLine>> result = new();
		switch (orderBy)
		{

			case "customernamedesc":
				result = await _wholeSalesDispatchTransactionLineService.GetWholeSalesDispatchTransactionLinesAsync(search, WholeSalesDispatchLineOrderBy.CustomerNameDesc, page, pageSize);
				return result;
			case "customernameasc":
				result = await _wholeSalesDispatchTransactionLineService.GetWholeSalesDispatchTransactionLinesAsync(search, WholeSalesDispatchLineOrderBy.CustomerNameAsc, page, pageSize);
				return result;
			case "customercodedesc":
				result = await _wholeSalesDispatchTransactionLineService.GetWholeSalesDispatchTransactionLinesAsync(search, WholeSalesDispatchLineOrderBy.CustomerCodeDesc, page, pageSize);
				return result;
			case "customercodeasc":
				result = await _wholeSalesDispatchTransactionLineService.GetWholeSalesDispatchTransactionLinesAsync(search, WholeSalesDispatchLineOrderBy.CustomerCodeAsc, page, pageSize);
				return result;
			case "productnameasc":
				result = await _wholeSalesDispatchTransactionLineService.GetWholeSalesDispatchTransactionLinesAsync(search, WholeSalesDispatchLineOrderBy.ProductNameAsc, page, pageSize);
				return result;
			case "productnamedesc":
				result = await _wholeSalesDispatchTransactionLineService.GetWholeSalesDispatchTransactionLinesAsync(search, WholeSalesDispatchLineOrderBy.ProductNameDesc, page, pageSize);
				return result;
			case "productcodeasc":
				result = await _wholeSalesDispatchTransactionLineService.GetWholeSalesDispatchTransactionLinesAsync(search, WholeSalesDispatchLineOrderBy.ProductCodeAsc, page, pageSize);
				return result;
			case "productcodedesc":
				result = await _wholeSalesDispatchTransactionLineService.GetWholeSalesDispatchTransactionLinesAsync(search, WholeSalesDispatchLineOrderBy.ProductCodeDesc, page, pageSize);
				return result;
			case "dateasc":
				result = await _wholeSalesDispatchTransactionLineService.GetWholeSalesDispatchTransactionLinesAsync(search, WholeSalesDispatchLineOrderBy.DateAsc, page, pageSize);
				return result;
			case "datedesc":
				result = await _wholeSalesDispatchTransactionLineService.GetWholeSalesDispatchTransactionLinesAsync(search, WholeSalesDispatchLineOrderBy.DateDesc, page, pageSize);
				return result;
			default:
				result = await _wholeSalesDispatchTransactionLineService.GetWholeSalesDispatchTransactionLinesAsync(search, orderBy, page, pageSize);
				return result;
		}
	}

	[HttpGet("Id/{id:int}")]
	public async Task<DataResult<WholeSalesDispatchTransactionLine>> GetById(int id)
	{
		var result = await _wholeSalesDispatchTransactionLineService.GetWholeSalesDispatchTransactionLineByIdAsync(id);
		return result;
	}


	[HttpGet("Current/Id/{id:int}")]
	public async Task<DataResult<IEnumerable<WholeSalesDispatchTransactionLine>>> GetByCurrentId(int id, [FromQuery] string search = "", string orderBy = WholeSalesDispatchLineOrderBy.DateDesc, int page = 0, int pageSize = 20)
	{
		DataResult<IEnumerable<WholeSalesDispatchTransactionLine>> result = new();
		switch (orderBy)
		{

			case "customernamedesc":
				result = await _wholeSalesDispatchTransactionLineService.GetWholeSalesDispatchTransactionLinesByCurrentIdAsync(id, search, WholeSalesDispatchLineOrderBy.CustomerNameDesc, page, pageSize);
				return result;
			case "customernameasc":
				result = await _wholeSalesDispatchTransactionLineService.GetWholeSalesDispatchTransactionLinesByCurrentIdAsync(id, search, WholeSalesDispatchLineOrderBy.CustomerNameAsc, page, pageSize);
				return result;
			case "customercodedesc":
				result = await _wholeSalesDispatchTransactionLineService.GetWholeSalesDispatchTransactionLinesByCurrentIdAsync(id, search, WholeSalesDispatchLineOrderBy.CustomerCodeDesc, page, pageSize);
				return result;
			case "customercodeasc":
				result = await _wholeSalesDispatchTransactionLineService.GetWholeSalesDispatchTransactionLinesByCurrentIdAsync(id, search, WholeSalesDispatchLineOrderBy.CustomerCodeAsc, page, pageSize);
				return result;
			case "productnameasc":
				result = await _wholeSalesDispatchTransactionLineService.GetWholeSalesDispatchTransactionLinesByCurrentIdAsync(id, search, WholeSalesDispatchLineOrderBy.ProductNameAsc, page, pageSize);
				return result;
			case "productnamedesc":
				result = await _wholeSalesDispatchTransactionLineService.GetWholeSalesDispatchTransactionLinesByCurrentIdAsync(id, search, WholeSalesDispatchLineOrderBy.ProductNameDesc, page, pageSize);
				return result;
			case "productcodeasc":
				result = await _wholeSalesDispatchTransactionLineService.GetWholeSalesDispatchTransactionLinesByCurrentIdAsync(id, search, WholeSalesDispatchLineOrderBy.ProductCodeAsc, page, pageSize);
				return result;
			case "productcodedesc":
				result = await _wholeSalesDispatchTransactionLineService.GetWholeSalesDispatchTransactionLinesByCurrentIdAsync(id, search, WholeSalesDispatchLineOrderBy.ProductCodeDesc, page, pageSize);
				return result;
			case "dateasc":
				result = await _wholeSalesDispatchTransactionLineService.GetWholeSalesDispatchTransactionLinesByCurrentIdAsync(id, search, WholeSalesDispatchLineOrderBy.DateAsc, page, pageSize);
				return result;
			case "datedesc":
				result = await _wholeSalesDispatchTransactionLineService.GetWholeSalesDispatchTransactionLinesByCurrentIdAsync(id, search, WholeSalesDispatchLineOrderBy.DateDesc, page, pageSize);
				return result;
			default:
				result = await _wholeSalesDispatchTransactionLineService.GetWholeSalesDispatchTransactionLinesByCurrentIdAsync(id, search, orderBy, page, pageSize);
				return result;
		}
	}

	[HttpGet("Current/Code/{code}")]
	public async Task<DataResult<IEnumerable<WholeSalesDispatchTransactionLine>>> GetByCurrentCode(string code, [FromQuery] string search = "", string orderBy = WholeSalesDispatchLineOrderBy.DateDesc, int page = 0, int pageSize = 20)
	{
		DataResult<IEnumerable<WholeSalesDispatchTransactionLine>> result = new();
		switch (orderBy)
		{

			case "customernamedesc":
				result = await _wholeSalesDispatchTransactionLineService.GetWholeSalesDispatchTransactionLinesByCurrentCodeAsync(code, search, WholeSalesDispatchLineOrderBy.CustomerNameDesc, page, pageSize);
				return result;
			case "customernameasc":
				result = await _wholeSalesDispatchTransactionLineService.GetWholeSalesDispatchTransactionLinesByCurrentCodeAsync(code, search, WholeSalesDispatchLineOrderBy.CustomerNameAsc, page, pageSize);
				return result;
			case "customercodedesc":
				result = await _wholeSalesDispatchTransactionLineService.GetWholeSalesDispatchTransactionLinesByCurrentCodeAsync(code, search, WholeSalesDispatchLineOrderBy.CustomerCodeDesc, page, pageSize);
				return result;
			case "customercodeasc":
				result = await _wholeSalesDispatchTransactionLineService.GetWholeSalesDispatchTransactionLinesByCurrentCodeAsync(code, search, WholeSalesDispatchLineOrderBy.CustomerCodeAsc, page, pageSize);
				return result;
			case "productnameasc":
				result = await _wholeSalesDispatchTransactionLineService.GetWholeSalesDispatchTransactionLinesByCurrentCodeAsync(code, search, WholeSalesDispatchLineOrderBy.ProductNameAsc, page, pageSize);
				return result;
			case "productnamedesc":
				result = await _wholeSalesDispatchTransactionLineService.GetWholeSalesDispatchTransactionLinesByCurrentCodeAsync(code, search, WholeSalesDispatchLineOrderBy.ProductNameDesc, page, pageSize);
				return result;
			case "productcodeasc":
				result = await _wholeSalesDispatchTransactionLineService.GetWholeSalesDispatchTransactionLinesByCurrentCodeAsync(code, search, WholeSalesDispatchLineOrderBy.ProductCodeAsc, page, pageSize);
				return result;
			case "productcodedesc":
				result = await _wholeSalesDispatchTransactionLineService.GetWholeSalesDispatchTransactionLinesByCurrentCodeAsync(code, search, WholeSalesDispatchLineOrderBy.ProductCodeDesc, page, pageSize);
				return result;
			case "dateasc":
				result = await _wholeSalesDispatchTransactionLineService.GetWholeSalesDispatchTransactionLinesByCurrentCodeAsync(code, search, WholeSalesDispatchLineOrderBy.DateAsc, page, pageSize);
				return result;
			case "datedesc":
				result = await _wholeSalesDispatchTransactionLineService.GetWholeSalesDispatchTransactionLinesByCurrentCodeAsync(code, search, WholeSalesDispatchLineOrderBy.DateDesc, page, pageSize);
				return result;
			default:
				result = await _wholeSalesDispatchTransactionLineService.GetWholeSalesDispatchTransactionLinesByCurrentCodeAsync(code, search, orderBy, page, pageSize);
				return result;
		}
	}

	[HttpGet("Product/Id/{id:int}")]
	public async Task<DataResult<IEnumerable<WholeSalesDispatchTransactionLine>>> GetByProductId(int id, [FromQuery] string search = "", string orderBy = WholeSalesDispatchLineOrderBy.DateDesc, int page = 0, int pageSize = 20)
	{
		DataResult<IEnumerable<WholeSalesDispatchTransactionLine>> result = new();
		switch (orderBy)
		{

			case "customernamedesc":
				result = await _wholeSalesDispatchTransactionLineService.GetWholeSalesDispatchTransactionLinesByProductIdAsync(id, search, WholeSalesDispatchLineOrderBy.CustomerNameDesc, page, pageSize);
				return result;
			case "customernameasc":
				result = await _wholeSalesDispatchTransactionLineService.GetWholeSalesDispatchTransactionLinesByProductIdAsync(id, search, WholeSalesDispatchLineOrderBy.CustomerNameAsc, page, pageSize);
				return result;
			case "customercodedesc":
				result = await _wholeSalesDispatchTransactionLineService.GetWholeSalesDispatchTransactionLinesByProductIdAsync(id, search, WholeSalesDispatchLineOrderBy.CustomerCodeDesc, page, pageSize);
				return result;
			case "customercodeasc":
				result = await _wholeSalesDispatchTransactionLineService.GetWholeSalesDispatchTransactionLinesByProductIdAsync(id, search, WholeSalesDispatchLineOrderBy.CustomerCodeAsc, page, pageSize);
				return result;
			case "productnameasc":
				result = await _wholeSalesDispatchTransactionLineService.GetWholeSalesDispatchTransactionLinesByProductIdAsync(id, search, WholeSalesDispatchLineOrderBy.ProductNameAsc, page, pageSize);
				return result;
			case "productnamedesc":
				result = await _wholeSalesDispatchTransactionLineService.GetWholeSalesDispatchTransactionLinesByProductIdAsync(id, search, WholeSalesDispatchLineOrderBy.ProductNameDesc, page, pageSize);
				return result;
			case "productcodeasc":
				result = await _wholeSalesDispatchTransactionLineService.GetWholeSalesDispatchTransactionLinesByProductIdAsync(id, search, WholeSalesDispatchLineOrderBy.ProductCodeAsc, page, pageSize);
				return result;
			case "productcodedesc":
				result = await _wholeSalesDispatchTransactionLineService.GetWholeSalesDispatchTransactionLinesByProductIdAsync(id, search, WholeSalesDispatchLineOrderBy.ProductCodeDesc, page, pageSize);
				return result;
			case "dateasc":
				result = await _wholeSalesDispatchTransactionLineService.GetWholeSalesDispatchTransactionLinesByProductIdAsync(id, search, WholeSalesDispatchLineOrderBy.DateAsc, page, pageSize);
				return result;
			case "datedesc":
				result = await _wholeSalesDispatchTransactionLineService.GetWholeSalesDispatchTransactionLinesByProductIdAsync(id, search, WholeSalesDispatchLineOrderBy.DateDesc, page, pageSize);
				return result;
			default:
				result = await _wholeSalesDispatchTransactionLineService.GetWholeSalesDispatchTransactionLinesByProductIdAsync(id, search, orderBy, page, pageSize);
				return result;
		}
	}

	[HttpGet("Product/Code/{code}")]
	public async Task<DataResult<IEnumerable<WholeSalesDispatchTransactionLine>>> GetByProductCode(string code, [FromQuery] string search = "", string orderBy = WholeSalesDispatchLineOrderBy.DateDesc, int page = 0, int pageSize = 20)
	{
		DataResult<IEnumerable<WholeSalesDispatchTransactionLine>> result = new();
		switch (orderBy)
		{

			case "customernamedesc":
				result = await _wholeSalesDispatchTransactionLineService.GetWholeSalesDispatchTransactionLinesByProductCodeAsync(code, search, WholeSalesDispatchLineOrderBy.CustomerNameDesc, page, pageSize);
				return result;
			case "customernameasc":
				result = await _wholeSalesDispatchTransactionLineService.GetWholeSalesDispatchTransactionLinesByProductCodeAsync(code, search, WholeSalesDispatchLineOrderBy.CustomerNameAsc, page, pageSize);
				return result;
			case "customercodedesc":
				result = await _wholeSalesDispatchTransactionLineService.GetWholeSalesDispatchTransactionLinesByProductCodeAsync(code, search, WholeSalesDispatchLineOrderBy.CustomerCodeDesc, page, pageSize);
				return result;
			case "customercodeasc":
				result = await _wholeSalesDispatchTransactionLineService.GetWholeSalesDispatchTransactionLinesByProductCodeAsync(code, search, WholeSalesDispatchLineOrderBy.CustomerCodeAsc, page, pageSize);
				return result;
			case "productnameasc":
				result = await _wholeSalesDispatchTransactionLineService.GetWholeSalesDispatchTransactionLinesByProductCodeAsync(code, search, WholeSalesDispatchLineOrderBy.ProductNameAsc, page, pageSize);
				return result;
			case "productnamedesc":
				result = await _wholeSalesDispatchTransactionLineService.GetWholeSalesDispatchTransactionLinesByProductCodeAsync(code, search, WholeSalesDispatchLineOrderBy.ProductNameDesc, page, pageSize);
				return result;
			case "productcodeasc":
				result = await _wholeSalesDispatchTransactionLineService.GetWholeSalesDispatchTransactionLinesByProductCodeAsync(code, search, WholeSalesDispatchLineOrderBy.ProductCodeAsc, page, pageSize);
				return result;
			case "productcodedesc":
				result = await _wholeSalesDispatchTransactionLineService.GetWholeSalesDispatchTransactionLinesByProductCodeAsync(code, search, WholeSalesDispatchLineOrderBy.ProductCodeDesc, page, pageSize);
				return result;
			case "dateasc":
				result = await _wholeSalesDispatchTransactionLineService.GetWholeSalesDispatchTransactionLinesByProductCodeAsync(code, search, WholeSalesDispatchLineOrderBy.DateAsc, page, pageSize);
				return result;
			case "datedesc":
				result = await _wholeSalesDispatchTransactionLineService.GetWholeSalesDispatchTransactionLinesByProductCodeAsync(code, search, WholeSalesDispatchLineOrderBy.DateDesc, page, pageSize);
				return result;
			default:
				result = await _wholeSalesDispatchTransactionLineService.GetWholeSalesDispatchTransactionLinesByProductCodeAsync(code, search, orderBy, page, pageSize);
				return result;
		}
	}

	[HttpGet("Fiche/Id/{id:int}")]
	public async Task<DataResult<IEnumerable<WholeSalesDispatchTransactionLine>>> GetByFicheId(int id, [FromQuery] string search = "", string orderBy = WholeSalesDispatchLineOrderBy.DateDesc, int page = 0, int pageSize = 20)
	{
		DataResult<IEnumerable<WholeSalesDispatchTransactionLine>> result = new();
		switch (orderBy)
		{

			case "customernamedesc":
				result = await _wholeSalesDispatchTransactionLineService.GetWholeSalesDispatchTransactionLinesByFicheIdAsync(id, search, WholeSalesDispatchLineOrderBy.CustomerNameDesc, page, pageSize);
				return result;
			case "customernameasc":
				result = await _wholeSalesDispatchTransactionLineService.GetWholeSalesDispatchTransactionLinesByFicheIdAsync(id, search, WholeSalesDispatchLineOrderBy.CustomerNameAsc, page, pageSize);
				return result;
			case "customercodedesc":
				result = await _wholeSalesDispatchTransactionLineService.GetWholeSalesDispatchTransactionLinesByFicheIdAsync(id, search, WholeSalesDispatchLineOrderBy.CustomerCodeDesc, page, pageSize);
				return result;
			case "customercodeasc":
				result = await _wholeSalesDispatchTransactionLineService.GetWholeSalesDispatchTransactionLinesByFicheIdAsync(id, search, WholeSalesDispatchLineOrderBy.CustomerCodeAsc, page, pageSize);
				return result;
			case "productnameasc":
				result = await _wholeSalesDispatchTransactionLineService.GetWholeSalesDispatchTransactionLinesByFicheIdAsync(id, search, WholeSalesDispatchLineOrderBy.ProductNameAsc, page, pageSize);
				return result;
			case "productnamedesc":
				result = await _wholeSalesDispatchTransactionLineService.GetWholeSalesDispatchTransactionLinesByFicheIdAsync(id, search, WholeSalesDispatchLineOrderBy.ProductNameDesc, page, pageSize);
				return result;
			case "productcodeasc":
				result = await _wholeSalesDispatchTransactionLineService.GetWholeSalesDispatchTransactionLinesByFicheIdAsync(id, search, WholeSalesDispatchLineOrderBy.ProductCodeAsc, page, pageSize);
				return result;
			case "productcodedesc":
				result = await _wholeSalesDispatchTransactionLineService.GetWholeSalesDispatchTransactionLinesByFicheIdAsync(id, search, WholeSalesDispatchLineOrderBy.ProductCodeDesc, page, pageSize);
				return result;
			case "dateasc":
				result = await _wholeSalesDispatchTransactionLineService.GetWholeSalesDispatchTransactionLinesByFicheIdAsync(id, search, WholeSalesDispatchLineOrderBy.DateAsc, page, pageSize);
				return result;
			case "datedesc":
				result = await _wholeSalesDispatchTransactionLineService.GetWholeSalesDispatchTransactionLinesByFicheIdAsync(id, search, WholeSalesDispatchLineOrderBy.DateDesc, page, pageSize);
				return result;
			default:
				result = await _wholeSalesDispatchTransactionLineService.GetWholeSalesDispatchTransactionLinesByFicheIdAsync(id, search, orderBy, page, pageSize);
				return result;
		}
	}

	[HttpGet("Fiche/Code/{code}")]
	public async Task<DataResult<IEnumerable<WholeSalesDispatchTransactionLine>>> GetByFicheCode(string code, [FromQuery] string search = "", string orderBy = WholeSalesDispatchLineOrderBy.DateDesc, int page = 0, int pageSize = 20)
	{
		DataResult<IEnumerable<WholeSalesDispatchTransactionLine>> result = new();
		switch (orderBy)
		{

			case "customernamedesc":
				result = await _wholeSalesDispatchTransactionLineService.GetWholeSalesDispatchTransactionLinesByFicheCodeAsync(code, search, WholeSalesDispatchLineOrderBy.CustomerNameDesc, page, pageSize);
				return result;
			case "customernameasc":
				result = await _wholeSalesDispatchTransactionLineService.GetWholeSalesDispatchTransactionLinesByFicheCodeAsync(code, search, WholeSalesDispatchLineOrderBy.CustomerNameAsc, page, pageSize);
				return result;
			case "customercodedesc":
				result = await _wholeSalesDispatchTransactionLineService.GetWholeSalesDispatchTransactionLinesByFicheCodeAsync(code, search, WholeSalesDispatchLineOrderBy.CustomerCodeDesc, page, pageSize);
				return result;
			case "customercodeasc":
				result = await _wholeSalesDispatchTransactionLineService.GetWholeSalesDispatchTransactionLinesByFicheCodeAsync(code, search, WholeSalesDispatchLineOrderBy.CustomerCodeAsc, page, pageSize);
				return result;
			case "productnameasc":
				result = await _wholeSalesDispatchTransactionLineService.GetWholeSalesDispatchTransactionLinesByFicheCodeAsync(code, search, WholeSalesDispatchLineOrderBy.ProductNameAsc, page, pageSize);
				return result;
			case "productnamedesc":
				result = await _wholeSalesDispatchTransactionLineService.GetWholeSalesDispatchTransactionLinesByFicheCodeAsync(code, search, WholeSalesDispatchLineOrderBy.ProductNameDesc, page, pageSize);
				return result;
			case "productcodeasc":
				result = await _wholeSalesDispatchTransactionLineService.GetWholeSalesDispatchTransactionLinesByFicheCodeAsync(code, search, WholeSalesDispatchLineOrderBy.ProductCodeAsc, page, pageSize);
				return result;
			case "productcodedesc":
				result = await _wholeSalesDispatchTransactionLineService.GetWholeSalesDispatchTransactionLinesByFicheCodeAsync(code, search, WholeSalesDispatchLineOrderBy.ProductCodeDesc, page, pageSize);
				return result;
			case "dateasc":
				result = await _wholeSalesDispatchTransactionLineService.GetWholeSalesDispatchTransactionLinesByFicheCodeAsync(code, search, WholeSalesDispatchLineOrderBy.DateAsc, page, pageSize);
				return result;
			case "datedesc":
				result = await _wholeSalesDispatchTransactionLineService.GetWholeSalesDispatchTransactionLinesByFicheCodeAsync(code, search, WholeSalesDispatchLineOrderBy.DateDesc, page, pageSize);
				return result;
			default:
				result = await _wholeSalesDispatchTransactionLineService.GetWholeSalesDispatchTransactionLinesByFicheCodeAsync(code, search, orderBy, page, pageSize);
				return result;
		}
	}
}
