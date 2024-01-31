using Helix.SalesService.Application.Repository;
using Helix.SalesService.Domain.AggregateModels;
using Helix.SalesService.Domain.Models;
using Helix.SalesService.Infrastructure.Helper.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace Helix.SalesService.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class RetailSalesReturnDispatchTransactionLineController : ControllerBase
{
	IRetailSalesReturnDispatchTransactionLineService _retailSalesReturnDispatchTransactionLineService;

    public RetailSalesReturnDispatchTransactionLineController(IRetailSalesReturnDispatchTransactionLineService salesReturnDispatchTransactionLineService)
    {
			_retailSalesReturnDispatchTransactionLineService = salesReturnDispatchTransactionLineService;
    }

    [HttpGet]
	public async Task<DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>>> GetAll([FromQuery] string search = "", string orderBy = RetailSalesReturnDispatchLineOrderBy.DateDesc, int page = 0, int pageSize = 20)
	{
		DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>> result = new();
		switch (orderBy)
		{

			case "customernamedesc":
				result = await _retailSalesReturnDispatchTransactionLineService.GetRetailSalesReturnDispatchTransactionLinesAsync(search, RetailSalesReturnDispatchLineOrderBy.CustomerNameDesc, page, pageSize);
				return result;
			case "customernameasc":
				result = await _retailSalesReturnDispatchTransactionLineService.GetRetailSalesReturnDispatchTransactionLinesAsync(search, RetailSalesReturnDispatchLineOrderBy.CustomerNameAsc, page, pageSize);
				return result;
			case "customercodedesc":
				result = await _retailSalesReturnDispatchTransactionLineService.GetRetailSalesReturnDispatchTransactionLinesAsync(search, RetailSalesReturnDispatchLineOrderBy.CustomerCodeDesc, page, pageSize);
				return result;
			case "customercodeasc":
				result = await _retailSalesReturnDispatchTransactionLineService.GetRetailSalesReturnDispatchTransactionLinesAsync(search, RetailSalesReturnDispatchLineOrderBy.CustomerCodeAsc, page, pageSize);
				return result;
			case "productnameasc":
				result = await _retailSalesReturnDispatchTransactionLineService.GetRetailSalesReturnDispatchTransactionLinesAsync(search, RetailSalesReturnDispatchLineOrderBy.ProductNameAsc, page, pageSize);
				return result;
			case "productnamedesc":
				result = await _retailSalesReturnDispatchTransactionLineService.GetRetailSalesReturnDispatchTransactionLinesAsync(search, RetailSalesReturnDispatchLineOrderBy.ProductNameDesc, page, pageSize);
				return result;
			case "productcodeasc":
				result = await _retailSalesReturnDispatchTransactionLineService.GetRetailSalesReturnDispatchTransactionLinesAsync(search, RetailSalesReturnDispatchLineOrderBy.ProductCodeAsc, page, pageSize);
				return result;
			case "productcodedesc":
				result = await _retailSalesReturnDispatchTransactionLineService.GetRetailSalesReturnDispatchTransactionLinesAsync(search, RetailSalesReturnDispatchLineOrderBy.ProductCodeDesc, page, pageSize);
				return result;
			case "dateasc":
				result = await _retailSalesReturnDispatchTransactionLineService.GetRetailSalesReturnDispatchTransactionLinesAsync(search, RetailSalesReturnDispatchLineOrderBy.DateAsc, page, pageSize);
				return result;
			case "datedesc":
				result = await _retailSalesReturnDispatchTransactionLineService.GetRetailSalesReturnDispatchTransactionLinesAsync(search, RetailSalesReturnDispatchLineOrderBy.DateDesc, page, pageSize);
				return result;
			default:
				result = await _retailSalesReturnDispatchTransactionLineService.GetRetailSalesReturnDispatchTransactionLinesAsync(search, orderBy, page, pageSize);
				return result;
		}
	}

	[HttpGet("Id/{id:int}")]
	public async Task<DataResult<RetailSalesReturnDispatchTransactionLine>> GetById(int id)
	{
		var result = await _retailSalesReturnDispatchTransactionLineService.GetRetailSalesReturnDispatchTransactionLineByIdAsync(id);
		return result;
	}


	[HttpGet("Current/Id/{id:int}")]
	public async Task<DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>>> GetByCurrentId(int id, [FromQuery] string search = "", string orderBy = RetailSalesReturnDispatchLineOrderBy.DateDesc, int page = 0, int pageSize = 20)
	{
		DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>> result = new();
		switch (orderBy)
		{

			case "customernamedesc":
				result = await _retailSalesReturnDispatchTransactionLineService.GetRetailSalesReturnDispatchTransactionLinesByCurrentIdAsync(id, search, RetailSalesReturnDispatchLineOrderBy.CustomerNameDesc, page, pageSize);
				return result;
			case "customernameasc":
				result = await _retailSalesReturnDispatchTransactionLineService.GetRetailSalesReturnDispatchTransactionLinesByCurrentIdAsync(id, search, RetailSalesReturnDispatchLineOrderBy.CustomerNameAsc, page, pageSize);
				return result;
			case "customercodedesc":
				result = await _retailSalesReturnDispatchTransactionLineService.GetRetailSalesReturnDispatchTransactionLinesByCurrentIdAsync(id, search, RetailSalesReturnDispatchLineOrderBy.CustomerCodeDesc, page, pageSize);
				return result;
			case "customercodeasc":
				result = await _retailSalesReturnDispatchTransactionLineService.GetRetailSalesReturnDispatchTransactionLinesByCurrentIdAsync(id, search, RetailSalesReturnDispatchLineOrderBy.CustomerCodeAsc, page, pageSize);
				return result;
			case "productnameasc":
				result = await _retailSalesReturnDispatchTransactionLineService.GetRetailSalesReturnDispatchTransactionLinesByCurrentIdAsync(id, search, RetailSalesReturnDispatchLineOrderBy.ProductNameAsc, page, pageSize);
				return result;
			case "productnamedesc":
				result = await _retailSalesReturnDispatchTransactionLineService.GetRetailSalesReturnDispatchTransactionLinesByCurrentIdAsync(id, search, RetailSalesReturnDispatchLineOrderBy.ProductNameDesc, page, pageSize);
				return result;
			case "productcodeasc":
				result = await _retailSalesReturnDispatchTransactionLineService.GetRetailSalesReturnDispatchTransactionLinesByCurrentIdAsync(id, search, RetailSalesReturnDispatchLineOrderBy.ProductCodeAsc, page, pageSize);
				return result;
			case "productcodedesc":
				result = await _retailSalesReturnDispatchTransactionLineService.GetRetailSalesReturnDispatchTransactionLinesByCurrentIdAsync(id, search, RetailSalesReturnDispatchLineOrderBy.ProductCodeDesc, page, pageSize);
				return result;
			case "dateasc":
				result = await _retailSalesReturnDispatchTransactionLineService.GetRetailSalesReturnDispatchTransactionLinesByCurrentIdAsync(id, search, RetailSalesReturnDispatchLineOrderBy.DateAsc, page, pageSize);
				return result;
			case "datedesc":
				result = await _retailSalesReturnDispatchTransactionLineService.GetRetailSalesReturnDispatchTransactionLinesByCurrentIdAsync(id, search, RetailSalesReturnDispatchLineOrderBy.DateDesc, page, pageSize);
				return result;
			default:
				result = await _retailSalesReturnDispatchTransactionLineService.GetRetailSalesReturnDispatchTransactionLinesByCurrentIdAsync(id,search, orderBy, page, pageSize);
				return result;
		}
	}

	[HttpGet("Current/Code/{code}")]
	public async Task<DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>>> GetByCurrentCode(string code, [FromQuery] string search = "", string orderBy = RetailSalesReturnDispatchLineOrderBy.DateDesc, int page = 0, int pageSize = 20)
	{
		DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>> result = new();
		switch (orderBy)
		{

			case "customernamedesc":
				result = await _retailSalesReturnDispatchTransactionLineService.GetRetailSalesReturnDispatchTransactionLinesByCurrentCodeAsync(code, search, RetailSalesReturnDispatchLineOrderBy.CustomerNameDesc, page, pageSize);
				return result;
			case "customernameasc":
				result = await _retailSalesReturnDispatchTransactionLineService.GetRetailSalesReturnDispatchTransactionLinesByCurrentCodeAsync(code, search, RetailSalesReturnDispatchLineOrderBy.CustomerNameAsc, page, pageSize);
				return result;
			case "customercodedesc":
				result = await _retailSalesReturnDispatchTransactionLineService.GetRetailSalesReturnDispatchTransactionLinesByCurrentCodeAsync(code, search, RetailSalesReturnDispatchLineOrderBy.CustomerCodeDesc, page, pageSize);
				return result;
			case "customercodeasc":
				result = await _retailSalesReturnDispatchTransactionLineService.GetRetailSalesReturnDispatchTransactionLinesByCurrentCodeAsync(code, search, RetailSalesReturnDispatchLineOrderBy.CustomerCodeAsc, page, pageSize);
				return result;
			case "productnameasc":
				result = await _retailSalesReturnDispatchTransactionLineService.GetRetailSalesReturnDispatchTransactionLinesByCurrentCodeAsync(code, search, RetailSalesReturnDispatchLineOrderBy.ProductNameAsc, page, pageSize);
				return result;
			case "productnamedesc":
				result = await _retailSalesReturnDispatchTransactionLineService.GetRetailSalesReturnDispatchTransactionLinesByCurrentCodeAsync(code, search, RetailSalesReturnDispatchLineOrderBy.ProductNameDesc, page, pageSize);
				return result;
			case "productcodeasc":
				result = await _retailSalesReturnDispatchTransactionLineService.GetRetailSalesReturnDispatchTransactionLinesByCurrentCodeAsync(code, search, RetailSalesReturnDispatchLineOrderBy.ProductCodeAsc, page, pageSize);
				return result;
			case "productcodedesc":
				result = await _retailSalesReturnDispatchTransactionLineService.GetRetailSalesReturnDispatchTransactionLinesByCurrentCodeAsync(code, search, RetailSalesReturnDispatchLineOrderBy.ProductCodeDesc, page, pageSize);
				return result;
			case "dateasc":
				result = await _retailSalesReturnDispatchTransactionLineService.GetRetailSalesReturnDispatchTransactionLinesByCurrentCodeAsync(code, search, RetailSalesReturnDispatchLineOrderBy.DateAsc, page, pageSize);
				return result;
			case "datedesc":
				result = await _retailSalesReturnDispatchTransactionLineService.GetRetailSalesReturnDispatchTransactionLinesByCurrentCodeAsync(code,search, RetailSalesReturnDispatchLineOrderBy.DateDesc, page, pageSize);
				return result;
			default:
				result = await _retailSalesReturnDispatchTransactionLineService.GetRetailSalesReturnDispatchTransactionLinesByCurrentCodeAsync(code, search, orderBy, page, pageSize);
				return result;
		}
	}

	[HttpGet("Product/Id/{id:int}")]
	public async Task<DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>>> GetByProductId(int id, [FromQuery] string search = "", string orderBy = RetailSalesReturnDispatchLineOrderBy.DateDesc, int page = 0, int pageSize = 20)
	{
		DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>> result = new();
		switch (orderBy)
		{

			case "customernamedesc":
				result = await _retailSalesReturnDispatchTransactionLineService.GetRetailSalesReturnDispatchTransactionLinesByProductIdAsync(id, search, RetailSalesReturnDispatchLineOrderBy.CustomerNameDesc, page, pageSize);
				return result;
			case "customernameasc":
				result = await _retailSalesReturnDispatchTransactionLineService.GetRetailSalesReturnDispatchTransactionLinesByProductIdAsync(id, search, RetailSalesReturnDispatchLineOrderBy.CustomerNameAsc, page, pageSize);
				return result;
			case "customercodedesc":
				result = await _retailSalesReturnDispatchTransactionLineService.GetRetailSalesReturnDispatchTransactionLinesByProductIdAsync(id, search, RetailSalesReturnDispatchLineOrderBy.CustomerCodeDesc, page, pageSize);
				return result;
			case "customercodeasc":
				result = await _retailSalesReturnDispatchTransactionLineService.GetRetailSalesReturnDispatchTransactionLinesByProductIdAsync(id, search, RetailSalesReturnDispatchLineOrderBy.CustomerCodeAsc, page, pageSize);
				return result;
			case "productnameasc":
				result = await _retailSalesReturnDispatchTransactionLineService.GetRetailSalesReturnDispatchTransactionLinesByProductIdAsync(id, search, RetailSalesReturnDispatchLineOrderBy.ProductNameAsc, page, pageSize);
				return result;
			case "productnamedesc":
				result = await _retailSalesReturnDispatchTransactionLineService.GetRetailSalesReturnDispatchTransactionLinesByProductIdAsync(id, search, RetailSalesReturnDispatchLineOrderBy.ProductNameDesc, page, pageSize);
				return result;
			case "productcodeasc":
				result = await _retailSalesReturnDispatchTransactionLineService.GetRetailSalesReturnDispatchTransactionLinesByProductIdAsync(id, search, RetailSalesReturnDispatchLineOrderBy.ProductCodeAsc, page, pageSize);
				return result;
			case "productcodedesc":
				result = await _retailSalesReturnDispatchTransactionLineService.GetRetailSalesReturnDispatchTransactionLinesByProductIdAsync(id, search, RetailSalesReturnDispatchLineOrderBy.ProductCodeDesc, page, pageSize);
				return result;
			case "dateasc":
				result = await _retailSalesReturnDispatchTransactionLineService.GetRetailSalesReturnDispatchTransactionLinesByProductIdAsync(id, search, RetailSalesReturnDispatchLineOrderBy.DateAsc, page, pageSize);
				return result;
			case "datedesc":
				result = await _retailSalesReturnDispatchTransactionLineService.GetRetailSalesReturnDispatchTransactionLinesByProductIdAsync(id, search, RetailSalesReturnDispatchLineOrderBy.DateDesc, page, pageSize);
				return result;
			default:
				result = await _retailSalesReturnDispatchTransactionLineService.GetRetailSalesReturnDispatchTransactionLinesByProductIdAsync(id,search, orderBy, page, pageSize);
				return result;
		}
	}

	[HttpGet("Product/Code/{code}")]
	public async Task<DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>>> GetByProductCode(string code, [FromQuery] string search = "", string orderBy = RetailSalesReturnDispatchLineOrderBy.DateDesc, int page = 0, int pageSize = 20)
	{
		DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>> result = new();
		switch (orderBy)
		{

			case "customernamedesc":
				result = await _retailSalesReturnDispatchTransactionLineService.GetRetailSalesReturnDispatchTransactionLinesByProductCodeAsync(code, search, RetailSalesReturnDispatchLineOrderBy.CustomerNameDesc, page, pageSize);
				return result;
			case "customernameasc":
				result = await _retailSalesReturnDispatchTransactionLineService.GetRetailSalesReturnDispatchTransactionLinesByProductCodeAsync(code, search, RetailSalesReturnDispatchLineOrderBy.CustomerNameAsc, page, pageSize);
				return result;
			case "customercodedesc":
				result = await _retailSalesReturnDispatchTransactionLineService.GetRetailSalesReturnDispatchTransactionLinesByProductCodeAsync(code, search, RetailSalesReturnDispatchLineOrderBy.CustomerCodeDesc, page, pageSize);
				return result;
			case "customercodeasc":
				result = await _retailSalesReturnDispatchTransactionLineService.GetRetailSalesReturnDispatchTransactionLinesByProductCodeAsync(code, search, RetailSalesReturnDispatchLineOrderBy.CustomerCodeAsc, page, pageSize);
				return result;
			case "productnameasc":
				result = await _retailSalesReturnDispatchTransactionLineService.GetRetailSalesReturnDispatchTransactionLinesByProductCodeAsync(code, search, RetailSalesReturnDispatchLineOrderBy.ProductNameAsc, page, pageSize);
				return result;
			case "productnamedesc":
				result = await _retailSalesReturnDispatchTransactionLineService.GetRetailSalesReturnDispatchTransactionLinesByProductCodeAsync(code, search, RetailSalesReturnDispatchLineOrderBy.ProductNameDesc, page, pageSize);
				return result;
			case "productcodeasc":
				result = await _retailSalesReturnDispatchTransactionLineService.GetRetailSalesReturnDispatchTransactionLinesByProductCodeAsync(code, search, RetailSalesReturnDispatchLineOrderBy.ProductCodeAsc, page, pageSize);
				return result;
			case "productcodedesc":
				result = await _retailSalesReturnDispatchTransactionLineService.GetRetailSalesReturnDispatchTransactionLinesByProductCodeAsync(code, search, RetailSalesReturnDispatchLineOrderBy.ProductCodeDesc, page, pageSize);
				return result;
			case "dateasc":
				result = await _retailSalesReturnDispatchTransactionLineService.GetRetailSalesReturnDispatchTransactionLinesByProductCodeAsync(code, search, RetailSalesReturnDispatchLineOrderBy.DateAsc, page, pageSize);
				return result;
			case "datedesc":
				result = await _retailSalesReturnDispatchTransactionLineService.GetRetailSalesReturnDispatchTransactionLinesByProductCodeAsync(code, search, RetailSalesReturnDispatchLineOrderBy.DateDesc, page, pageSize);
				return result;
			default:
				result = await _retailSalesReturnDispatchTransactionLineService.GetRetailSalesReturnDispatchTransactionLinesByProductCodeAsync(code,search, orderBy, page, pageSize);
				return result;
		}
	}

	[HttpGet("Fiche/Id/{id:int}")]
	public async Task<DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>>> GetByFicheId(int id, [FromQuery] string search = "", string orderBy = RetailSalesReturnDispatchLineOrderBy.DateDesc, int page = 0, int pageSize = 20)
	{
		DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>> result = new();
		switch (orderBy)
		{

			case "customernamedesc":
				result = await _retailSalesReturnDispatchTransactionLineService.GetRetailSalesReturnDispatchTransactionLinesByFicheIdAsync(id,search, RetailSalesReturnDispatchLineOrderBy.CustomerNameDesc, page, pageSize);
				return result;
			case "customernameasc":
				result = await _retailSalesReturnDispatchTransactionLineService.GetRetailSalesReturnDispatchTransactionLinesByFicheIdAsync(id, search, RetailSalesReturnDispatchLineOrderBy.CustomerNameAsc, page, pageSize);
				return result;
			case "customercodedesc":
				result = await _retailSalesReturnDispatchTransactionLineService.GetRetailSalesReturnDispatchTransactionLinesByFicheIdAsync(id, search, RetailSalesReturnDispatchLineOrderBy.CustomerCodeDesc, page, pageSize);
				return result;
			case "customercodeasc":
				result = await _retailSalesReturnDispatchTransactionLineService.GetRetailSalesReturnDispatchTransactionLinesByFicheIdAsync(id, search, RetailSalesReturnDispatchLineOrderBy.CustomerCodeAsc, page, pageSize);
				return result;
			case "productnameasc":
				result = await _retailSalesReturnDispatchTransactionLineService.GetRetailSalesReturnDispatchTransactionLinesByFicheIdAsync(id, search, RetailSalesReturnDispatchLineOrderBy.ProductNameAsc, page, pageSize);
				return result;
			case "productnamedesc":
				result = await _retailSalesReturnDispatchTransactionLineService.GetRetailSalesReturnDispatchTransactionLinesByFicheIdAsync(id, search, RetailSalesReturnDispatchLineOrderBy.ProductNameDesc, page, pageSize);
				return result;
			case "productcodeasc":
				result = await _retailSalesReturnDispatchTransactionLineService.GetRetailSalesReturnDispatchTransactionLinesByFicheIdAsync(id, search, RetailSalesReturnDispatchLineOrderBy.ProductCodeAsc, page, pageSize);
				return result;
			case "productcodedesc":
				result = await _retailSalesReturnDispatchTransactionLineService.GetRetailSalesReturnDispatchTransactionLinesByFicheIdAsync(id, search, RetailSalesReturnDispatchLineOrderBy.ProductCodeDesc, page, pageSize);
				return result;
			case "dateasc":
				result = await _retailSalesReturnDispatchTransactionLineService.GetRetailSalesReturnDispatchTransactionLinesByFicheIdAsync(id, search, RetailSalesReturnDispatchLineOrderBy.DateAsc, page, pageSize);
				return result;
			case "datedesc":
				result = await _retailSalesReturnDispatchTransactionLineService.GetRetailSalesReturnDispatchTransactionLinesByFicheIdAsync(id, search, RetailSalesReturnDispatchLineOrderBy.DateDesc, page, pageSize);
				return result;
			default:
				result = await _retailSalesReturnDispatchTransactionLineService.GetRetailSalesReturnDispatchTransactionLinesByFicheIdAsync(id, search, orderBy, page, pageSize);
				return result;
		}
	}

	[HttpGet("Fiche/Code/{code}")]
	public async Task<DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>>> GetByFicheCode(string code, [FromQuery] string search = "", string orderBy = RetailSalesReturnDispatchLineOrderBy.DateDesc, int page = 0, int pageSize = 20)
	{
		DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>> result = new();
		switch (orderBy)
		{

			case "customernamedesc":
				result = await _retailSalesReturnDispatchTransactionLineService.GetRetailSalesReturnDispatchTransactionLinesByFicheCodeAsync(code,search, RetailSalesReturnDispatchLineOrderBy.CustomerNameDesc, page, pageSize);
				return result;
			case "customernameasc":
				result = await _retailSalesReturnDispatchTransactionLineService.GetRetailSalesReturnDispatchTransactionLinesByFicheCodeAsync(code, search, RetailSalesReturnDispatchLineOrderBy.CustomerNameAsc, page, pageSize);
				return result;
			case "customercodedesc":
				result = await _retailSalesReturnDispatchTransactionLineService.GetRetailSalesReturnDispatchTransactionLinesByFicheCodeAsync(code, search, RetailSalesReturnDispatchLineOrderBy.CustomerCodeDesc, page, pageSize);
				return result;
			case "customercodeasc":
				result = await _retailSalesReturnDispatchTransactionLineService.GetRetailSalesReturnDispatchTransactionLinesByFicheCodeAsync(code, search, RetailSalesReturnDispatchLineOrderBy.CustomerCodeAsc, page, pageSize);
				return result;
			case "productnameasc":
				result = await _retailSalesReturnDispatchTransactionLineService.GetRetailSalesReturnDispatchTransactionLinesByFicheCodeAsync(code, search, RetailSalesReturnDispatchLineOrderBy.ProductNameAsc, page, pageSize);
				return result;
			case "productnamedesc":
				result = await _retailSalesReturnDispatchTransactionLineService.GetRetailSalesReturnDispatchTransactionLinesByFicheCodeAsync(code, search, RetailSalesReturnDispatchLineOrderBy.ProductNameDesc, page, pageSize);
				return result;
			case "productcodeasc":
				result = await _retailSalesReturnDispatchTransactionLineService.GetRetailSalesReturnDispatchTransactionLinesByFicheCodeAsync(code, search, RetailSalesReturnDispatchLineOrderBy.ProductCodeAsc, page, pageSize);
				return result;
			case "productcodedesc":
				result = await _retailSalesReturnDispatchTransactionLineService.GetRetailSalesReturnDispatchTransactionLinesByFicheCodeAsync(code, search, RetailSalesReturnDispatchLineOrderBy.ProductCodeDesc, page, pageSize);
				return result;
			case "dateasc":
				result = await _retailSalesReturnDispatchTransactionLineService.GetRetailSalesReturnDispatchTransactionLinesByFicheCodeAsync(code, search, RetailSalesReturnDispatchLineOrderBy.DateAsc, page, pageSize);
				return result;
			case "datedesc":
				result = await _retailSalesReturnDispatchTransactionLineService.GetRetailSalesReturnDispatchTransactionLinesByFicheCodeAsync(code, search, RetailSalesReturnDispatchLineOrderBy.DateDesc, page, pageSize);
				return result;
			default:
				result = await _retailSalesReturnDispatchTransactionLineService.GetRetailSalesReturnDispatchTransactionLinesByFicheCodeAsync(code, search, orderBy, page, pageSize);
				return result;
		}
	}
}
