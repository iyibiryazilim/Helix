using Consul;
using Helix.SalesService.Application.Repository;
using Helix.SalesService.Domain.AggregateModels;
using Helix.SalesService.Domain.Models;
using Helix.SalesService.Infrastructure.Helper.Queries;
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
	public async Task<DataResult<IEnumerable<RetailSalesDispatchTransactionLine>>> GetAll([FromQuery] string search = "", string orderBy = RetailSalesDispatchLineOrderBy.DateDesc, int page = 0, int pageSize = 20)
	{
		DataResult<IEnumerable<RetailSalesDispatchTransactionLine>> result = new();
		switch (orderBy)
		{

			case "customernamedesc":
				result = await _retailSalesDispatchTransactionLineService.GetRetailSalesDispatchTransactionLinesAsync( search, RetailSalesDispatchLineOrderBy.CustomerNameDesc, page, pageSize);
				return result;
			case "customernameasc":
				result = await _retailSalesDispatchTransactionLineService.GetRetailSalesDispatchTransactionLinesAsync(search, RetailSalesDispatchLineOrderBy.CustomerNameAsc, page, pageSize);
				return result;
			case "customercodedesc":
				result = await _retailSalesDispatchTransactionLineService.GetRetailSalesDispatchTransactionLinesAsync(search, RetailSalesDispatchLineOrderBy.CustomerCodeDesc, page, pageSize);
				return result;
			case "customercodeasc":
				result = await _retailSalesDispatchTransactionLineService.GetRetailSalesDispatchTransactionLinesAsync(search, RetailSalesDispatchLineOrderBy.CustomerCodeAsc, page, pageSize);
				return result;
			case "productnameasc":
				result = await _retailSalesDispatchTransactionLineService.GetRetailSalesDispatchTransactionLinesAsync(search, RetailSalesDispatchLineOrderBy.ProductNameAsc, page, pageSize);
				return result;
			case "productnamedesc":
				result = await _retailSalesDispatchTransactionLineService.GetRetailSalesDispatchTransactionLinesAsync(search, RetailSalesDispatchLineOrderBy.ProductNameDesc, page, pageSize);
				return result;
			case "productcodeasc":
				result = await _retailSalesDispatchTransactionLineService.GetRetailSalesDispatchTransactionLinesAsync(search, RetailSalesDispatchLineOrderBy.ProductCodeAsc, page, pageSize);
				return result;
			case "productcodedesc":
				result = await _retailSalesDispatchTransactionLineService.GetRetailSalesDispatchTransactionLinesAsync(search, RetailSalesDispatchLineOrderBy.ProductCodeDesc, page, pageSize);
				return result;
			case "dateasc":
				result = await _retailSalesDispatchTransactionLineService.GetRetailSalesDispatchTransactionLinesAsync(search, RetailSalesDispatchLineOrderBy.DateAsc, page, pageSize);
				return result;
			case "datedesc":
				result = await _retailSalesDispatchTransactionLineService.GetRetailSalesDispatchTransactionLinesAsync(search, RetailSalesDispatchLineOrderBy.DateDesc, page, pageSize);
				return result;
			default:
				result = await _retailSalesDispatchTransactionLineService.GetRetailSalesDispatchTransactionLinesAsync(search, orderBy, page, pageSize);
				return result;
		}
	}

	[HttpGet("Id/{id:int}")]
	public async Task<DataResult<RetailSalesDispatchTransactionLine>> GetById(int id)
	{
		var result = await _retailSalesDispatchTransactionLineService.GetRetailSalesDispatchTransactionLineByIdAsync(id);
		return result;
	}


	[HttpGet("Current/Id/{id:int}")]
	public async Task<DataResult<IEnumerable<RetailSalesDispatchTransactionLine>>> GetByCurrentId(int id, [FromQuery] string search = "", string orderBy = RetailSalesDispatchLineOrderBy.DateDesc, int page = 0, int pageSize = 20)
	{
		DataResult<IEnumerable<RetailSalesDispatchTransactionLine>> result = new();
		switch (orderBy)
		{

			case "customernamedesc":
				result = await _retailSalesDispatchTransactionLineService.GetRetailSalesDispatchTransactionLinesByCurrentIdAsync(id,search, RetailSalesDispatchLineOrderBy.CustomerNameDesc, page, pageSize);
				return result;
			case "customernameasc":
				result = await _retailSalesDispatchTransactionLineService.GetRetailSalesDispatchTransactionLinesByCurrentIdAsync(id, search, RetailSalesDispatchLineOrderBy.CustomerNameAsc, page, pageSize);
				return result;
			case "customercodedesc":
				result = await _retailSalesDispatchTransactionLineService.GetRetailSalesDispatchTransactionLinesByCurrentIdAsync(id, search, RetailSalesDispatchLineOrderBy.CustomerCodeDesc, page, pageSize);
				return result;
			case "customercodeasc":
				result = await _retailSalesDispatchTransactionLineService.GetRetailSalesDispatchTransactionLinesByCurrentIdAsync(id, search, RetailSalesDispatchLineOrderBy.CustomerCodeAsc, page, pageSize);
				return result;
			case "productnameasc":
				result = await _retailSalesDispatchTransactionLineService.GetRetailSalesDispatchTransactionLinesByCurrentIdAsync(id, search, RetailSalesDispatchLineOrderBy.ProductNameAsc, page, pageSize);
				return result;
			case "productnamedesc":
				result = await _retailSalesDispatchTransactionLineService.GetRetailSalesDispatchTransactionLinesByCurrentIdAsync(id, search, RetailSalesDispatchLineOrderBy.ProductNameDesc, page, pageSize);
				return result;
			case "productcodeasc":
				result = await _retailSalesDispatchTransactionLineService.GetRetailSalesDispatchTransactionLinesByCurrentIdAsync(id, search, RetailSalesDispatchLineOrderBy.ProductCodeAsc, page, pageSize);
				return result;
			case "productcodedesc":
				result = await _retailSalesDispatchTransactionLineService.GetRetailSalesDispatchTransactionLinesByCurrentIdAsync(id, search, RetailSalesDispatchLineOrderBy.ProductCodeDesc, page, pageSize);
				return result;
			case "dateasc":
				result = await _retailSalesDispatchTransactionLineService.GetRetailSalesDispatchTransactionLinesByCurrentIdAsync(id, search, RetailSalesDispatchLineOrderBy.DateAsc, page, pageSize);
				return result;
			case "datedesc":
				result = await _retailSalesDispatchTransactionLineService.GetRetailSalesDispatchTransactionLinesByCurrentIdAsync(id, search, RetailSalesDispatchLineOrderBy.DateDesc, page, pageSize);
				return result;
			default:
				result = await _retailSalesDispatchTransactionLineService.GetRetailSalesDispatchTransactionLinesByCurrentIdAsync(id, search, orderBy, page, pageSize);
				return result;
		}
	}

	[HttpGet("Current/Code/{code}")]
	public async Task<DataResult<IEnumerable<RetailSalesDispatchTransactionLine>>> GetByCurrentCode(string code, [FromQuery] string search = "", string orderBy = RetailSalesDispatchLineOrderBy.DateDesc, int page = 0, int pageSize = 20)
	{
		DataResult<IEnumerable<RetailSalesDispatchTransactionLine>> result = new();
		switch (orderBy)
		{

			case "customernamedesc":
				result = await _retailSalesDispatchTransactionLineService.GetRetailSalesDispatchTransactionLinesByCurrentCodeAsync(code, search, RetailSalesDispatchLineOrderBy.CustomerNameDesc, page, pageSize);
				return result;
			case "customernameasc":
				result = await _retailSalesDispatchTransactionLineService.GetRetailSalesDispatchTransactionLinesByCurrentCodeAsync(code, search, RetailSalesDispatchLineOrderBy.CustomerNameAsc, page, pageSize);
				return result;
			case "customercodedesc":
				result = await _retailSalesDispatchTransactionLineService.GetRetailSalesDispatchTransactionLinesByCurrentCodeAsync(code, search, RetailSalesDispatchLineOrderBy.CustomerCodeDesc, page, pageSize);
				return result;
			case "customercodeasc":
				result = await _retailSalesDispatchTransactionLineService.GetRetailSalesDispatchTransactionLinesByCurrentCodeAsync(code, search, RetailSalesDispatchLineOrderBy.CustomerCodeAsc, page, pageSize);
				return result;
			case "productnameasc":
				result = await _retailSalesDispatchTransactionLineService.GetRetailSalesDispatchTransactionLinesByCurrentCodeAsync(code, search, RetailSalesDispatchLineOrderBy.ProductNameAsc, page, pageSize);
				return result;
			case "productnamedesc":
				result = await _retailSalesDispatchTransactionLineService.GetRetailSalesDispatchTransactionLinesByCurrentCodeAsync(code, search, RetailSalesDispatchLineOrderBy.ProductNameDesc, page, pageSize);
				return result;
			case "productcodeasc":
				result = await _retailSalesDispatchTransactionLineService.GetRetailSalesDispatchTransactionLinesByCurrentCodeAsync(code, search, RetailSalesDispatchLineOrderBy.ProductCodeAsc, page, pageSize);
				return result;
			case "productcodedesc":
				result = await _retailSalesDispatchTransactionLineService.GetRetailSalesDispatchTransactionLinesByCurrentCodeAsync(code, search, RetailSalesDispatchLineOrderBy.ProductCodeDesc, page, pageSize);
				return result;
			case "dateasc":
				result = await _retailSalesDispatchTransactionLineService.GetRetailSalesDispatchTransactionLinesByCurrentCodeAsync(code, search, RetailSalesDispatchLineOrderBy.DateAsc, page, pageSize);
				return result;
			case "datedesc":
				result = await _retailSalesDispatchTransactionLineService.GetRetailSalesDispatchTransactionLinesByCurrentCodeAsync(code, search, RetailSalesDispatchLineOrderBy.DateDesc, page, pageSize);
				return result;
			default:
				result = await _retailSalesDispatchTransactionLineService.GetRetailSalesDispatchTransactionLinesByCurrentCodeAsync(code, search, orderBy, page, pageSize);
				return result;
		}
	}

	[HttpGet("Product/Id/{id:int}")]
	public async Task<DataResult<IEnumerable<RetailSalesDispatchTransactionLine>>> GetByProductId(int id, [FromQuery] string search = "", string orderBy = RetailSalesDispatchLineOrderBy.DateDesc, int page = 0, int pageSize = 20)
	{
		DataResult<IEnumerable<RetailSalesDispatchTransactionLine>> result = new();
		switch (orderBy)
		{

			case "customernamedesc":
				result = await _retailSalesDispatchTransactionLineService.GetRetailSalesDispatchTransactionLinesByProductIdAsync(id, search, RetailSalesDispatchLineOrderBy.CustomerNameDesc, page, pageSize);
				return result;
			case "customernameasc":
				result = await _retailSalesDispatchTransactionLineService.GetRetailSalesDispatchTransactionLinesByProductIdAsync(id, search, RetailSalesDispatchLineOrderBy.CustomerNameAsc, page, pageSize);
				return result;
			case "customercodedesc":
				result = await _retailSalesDispatchTransactionLineService.GetRetailSalesDispatchTransactionLinesByProductIdAsync(id, search, RetailSalesDispatchLineOrderBy.CustomerCodeDesc, page, pageSize);
				return result;
			case "customercodeasc":
				result = await _retailSalesDispatchTransactionLineService.GetRetailSalesDispatchTransactionLinesByProductIdAsync(id, search, RetailSalesDispatchLineOrderBy.CustomerCodeAsc, page, pageSize);
				return result;
			case "productnameasc":
				result = await _retailSalesDispatchTransactionLineService.GetRetailSalesDispatchTransactionLinesByProductIdAsync(id, search, RetailSalesDispatchLineOrderBy.ProductNameAsc, page, pageSize);
				return result;
			case "productnamedesc":
				result = await _retailSalesDispatchTransactionLineService.GetRetailSalesDispatchTransactionLinesByProductIdAsync(id, search, RetailSalesDispatchLineOrderBy.ProductNameDesc, page, pageSize);
				return result;
			case "productcodeasc":
				result = await _retailSalesDispatchTransactionLineService.GetRetailSalesDispatchTransactionLinesByProductIdAsync(id, search, RetailSalesDispatchLineOrderBy.ProductCodeAsc, page, pageSize);
				return result;
			case "productcodedesc":
				result = await _retailSalesDispatchTransactionLineService.GetRetailSalesDispatchTransactionLinesByProductIdAsync(id, search, RetailSalesDispatchLineOrderBy.ProductCodeDesc, page, pageSize);
				return result;
			case "dateasc":
				result = await _retailSalesDispatchTransactionLineService.GetRetailSalesDispatchTransactionLinesByProductIdAsync(id, search, RetailSalesDispatchLineOrderBy.DateAsc, page, pageSize);
				return result;
			case "datedesc":
				result = await _retailSalesDispatchTransactionLineService.GetRetailSalesDispatchTransactionLinesByProductIdAsync(id, search, RetailSalesDispatchLineOrderBy.DateDesc, page, pageSize);
				return result;
			default:
				result = await _retailSalesDispatchTransactionLineService.GetRetailSalesDispatchTransactionLinesByProductIdAsync(id, search, orderBy, page, pageSize);
				return result;
		}
	}

	[HttpGet("Product/Code/{code}")]
	public async Task<DataResult<IEnumerable<RetailSalesDispatchTransactionLine>>> GetByProductCode(string code, [FromQuery] string search = "", string orderBy = RetailSalesDispatchLineOrderBy.DateDesc, int page = 0, int pageSize = 20)
	{
		DataResult<IEnumerable<RetailSalesDispatchTransactionLine>> result = new();
		switch (orderBy)
		{

			case "customernamedesc":
				result = await _retailSalesDispatchTransactionLineService.GetRetailSalesDispatchTransactionLinesByProductCodeAsync(code, search, RetailSalesDispatchLineOrderBy.CustomerNameDesc, page, pageSize);
				return result;
			case "customernameasc":
				result = await _retailSalesDispatchTransactionLineService.GetRetailSalesDispatchTransactionLinesByProductCodeAsync(code, search, RetailSalesDispatchLineOrderBy.CustomerNameAsc, page, pageSize);
				return result;
			case "customercodedesc":
				result = await _retailSalesDispatchTransactionLineService.GetRetailSalesDispatchTransactionLinesByProductCodeAsync(code, search, RetailSalesDispatchLineOrderBy.CustomerCodeDesc, page, pageSize);
				return result;
			case "customercodeasc":
				result = await _retailSalesDispatchTransactionLineService.GetRetailSalesDispatchTransactionLinesByProductCodeAsync(code, search, RetailSalesDispatchLineOrderBy.CustomerCodeAsc, page, pageSize);
				return result;
			case "productnameasc":
				result = await _retailSalesDispatchTransactionLineService.GetRetailSalesDispatchTransactionLinesByProductCodeAsync(code, search, RetailSalesDispatchLineOrderBy.ProductNameAsc, page, pageSize);
				return result;
			case "productnamedesc":
				result = await _retailSalesDispatchTransactionLineService.GetRetailSalesDispatchTransactionLinesByProductCodeAsync(code, search, RetailSalesDispatchLineOrderBy.ProductNameDesc, page, pageSize);
				return result;
			case "productcodeasc":
				result = await _retailSalesDispatchTransactionLineService.GetRetailSalesDispatchTransactionLinesByProductCodeAsync(code, search, RetailSalesDispatchLineOrderBy.ProductCodeAsc, page, pageSize);
				return result;
			case "productcodedesc":
				result = await _retailSalesDispatchTransactionLineService.GetRetailSalesDispatchTransactionLinesByProductCodeAsync(code, search, RetailSalesDispatchLineOrderBy.ProductCodeDesc, page, pageSize);
				return result;
			case "dateasc":
				result = await _retailSalesDispatchTransactionLineService.GetRetailSalesDispatchTransactionLinesByProductCodeAsync(code, search, RetailSalesDispatchLineOrderBy.DateAsc, page, pageSize);
				return result;
			case "datedesc":
				result = await _retailSalesDispatchTransactionLineService.GetRetailSalesDispatchTransactionLinesByProductCodeAsync(code, search, RetailSalesDispatchLineOrderBy.DateDesc, page, pageSize);
				return result;
			default:
				result = await _retailSalesDispatchTransactionLineService.GetRetailSalesDispatchTransactionLinesByProductCodeAsync(code, search, orderBy, page, pageSize);
				return result;
		}
	}

	[HttpGet("Fiche/Id/{id:int}")]
	public async Task<DataResult<IEnumerable<RetailSalesDispatchTransactionLine>>> GetByFicheId(int id, [FromQuery] string search = "", string orderBy = RetailSalesDispatchLineOrderBy.DateDesc, int page = 0, int pageSize = 20)
	{
		DataResult<IEnumerable<RetailSalesDispatchTransactionLine>> result = new();
		switch (orderBy)
		{

			case "customernamedesc":
				result = await _retailSalesDispatchTransactionLineService.GetRetailSalesDispatchTransactionLinesByFicheIdAsync(id, search, RetailSalesDispatchLineOrderBy.CustomerNameDesc, page, pageSize);
				return result;
			case "customernameasc":
				result = await _retailSalesDispatchTransactionLineService.GetRetailSalesDispatchTransactionLinesByFicheIdAsync(id, search, RetailSalesDispatchLineOrderBy.CustomerNameAsc, page, pageSize);
				return result;
			case "customercodedesc":
				result = await _retailSalesDispatchTransactionLineService.GetRetailSalesDispatchTransactionLinesByFicheIdAsync(id, search, RetailSalesDispatchLineOrderBy.CustomerCodeDesc, page, pageSize);
				return result;
			case "customercodeasc":
				result = await _retailSalesDispatchTransactionLineService.GetRetailSalesDispatchTransactionLinesByFicheIdAsync(id, search, RetailSalesDispatchLineOrderBy.CustomerCodeAsc, page, pageSize);
				return result;
			case "productnameasc":
				result = await _retailSalesDispatchTransactionLineService.GetRetailSalesDispatchTransactionLinesByFicheIdAsync(id, search, RetailSalesDispatchLineOrderBy.ProductNameAsc, page, pageSize);
				return result;
			case "productnamedesc":
				result = await _retailSalesDispatchTransactionLineService.GetRetailSalesDispatchTransactionLinesByFicheIdAsync(id, search, RetailSalesDispatchLineOrderBy.ProductNameDesc, page, pageSize);
				return result;
			case "productcodeasc":
				result = await _retailSalesDispatchTransactionLineService.GetRetailSalesDispatchTransactionLinesByFicheIdAsync(id, search, RetailSalesDispatchLineOrderBy.ProductCodeAsc, page, pageSize);
				return result;
			case "productcodedesc":
				result = await _retailSalesDispatchTransactionLineService.GetRetailSalesDispatchTransactionLinesByFicheIdAsync(id, search, RetailSalesDispatchLineOrderBy.ProductCodeDesc, page, pageSize);
				return result;
			case "dateasc":
				result = await _retailSalesDispatchTransactionLineService.GetRetailSalesDispatchTransactionLinesByFicheIdAsync(id, search, RetailSalesDispatchLineOrderBy.DateAsc, page, pageSize);
				return result;
			case "datedesc":
				result = await _retailSalesDispatchTransactionLineService.GetRetailSalesDispatchTransactionLinesByFicheIdAsync(id, search, RetailSalesDispatchLineOrderBy.DateDesc, page, pageSize);
				return result;
			default:
				result = await _retailSalesDispatchTransactionLineService.GetRetailSalesDispatchTransactionLinesByFicheIdAsync(id, search, orderBy, page, pageSize);
				return result;
		}
	}

	[HttpGet("Fiche/Code/{code}")]
	public async Task<DataResult<IEnumerable<RetailSalesDispatchTransactionLine>>> GetByFicheCode(string code, [FromQuery] string search = "", string orderBy = RetailSalesDispatchLineOrderBy.DateDesc, int page = 0, int pageSize = 20)
	{
		DataResult<IEnumerable<RetailSalesDispatchTransactionLine>> result = new();
		switch (orderBy)
		{

			case "customernamedesc":
				result = await _retailSalesDispatchTransactionLineService.GetRetailSalesDispatchTransactionLinesByFicheCodeAsync(code, search, RetailSalesDispatchLineOrderBy.CustomerNameDesc, page, pageSize);
				return result;
			case "customernameasc":
				result = await _retailSalesDispatchTransactionLineService.GetRetailSalesDispatchTransactionLinesByFicheCodeAsync(code, search, RetailSalesDispatchLineOrderBy.CustomerNameAsc, page, pageSize);
				return result;
			case "customercodedesc":
				result = await _retailSalesDispatchTransactionLineService.GetRetailSalesDispatchTransactionLinesByFicheCodeAsync(code, search, RetailSalesDispatchLineOrderBy.CustomerCodeDesc, page, pageSize);
				return result;
			case "customercodeasc":
				result = await _retailSalesDispatchTransactionLineService.GetRetailSalesDispatchTransactionLinesByFicheCodeAsync(code, search, RetailSalesDispatchLineOrderBy.CustomerCodeAsc, page, pageSize);
				return result;
			case "productnameasc":
				result = await _retailSalesDispatchTransactionLineService.GetRetailSalesDispatchTransactionLinesByFicheCodeAsync(code, search, RetailSalesDispatchLineOrderBy.ProductNameAsc, page, pageSize);
				return result;
			case "productnamedesc":
				result = await _retailSalesDispatchTransactionLineService.GetRetailSalesDispatchTransactionLinesByFicheCodeAsync(code, search, RetailSalesDispatchLineOrderBy.ProductNameDesc, page, pageSize);
				return result;
			case "productcodeasc":
				result = await _retailSalesDispatchTransactionLineService.GetRetailSalesDispatchTransactionLinesByFicheCodeAsync(code, search, RetailSalesDispatchLineOrderBy.ProductCodeAsc, page, pageSize);
				return result;
			case "productcodedesc":
				result = await _retailSalesDispatchTransactionLineService.GetRetailSalesDispatchTransactionLinesByFicheCodeAsync(code, search, RetailSalesDispatchLineOrderBy.ProductCodeDesc, page, pageSize);
				return result;
			case "dateasc":
				result = await _retailSalesDispatchTransactionLineService.GetRetailSalesDispatchTransactionLinesByFicheCodeAsync(code, search, RetailSalesDispatchLineOrderBy.DateAsc, page, pageSize);
				return result;
			case "datedesc":
				result = await _retailSalesDispatchTransactionLineService.GetRetailSalesDispatchTransactionLinesByFicheCodeAsync(code, search, RetailSalesDispatchLineOrderBy.DateDesc, page, pageSize);
				return result;
			default:
				result = await _retailSalesDispatchTransactionLineService.GetRetailSalesDispatchTransactionLinesByFicheCodeAsync(code, search, orderBy, page, pageSize);
				return result;
		}
	}
}
