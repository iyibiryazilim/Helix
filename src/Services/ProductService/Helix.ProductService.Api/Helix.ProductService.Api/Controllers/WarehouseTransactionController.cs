using Helix.ProductService.Application.Repository;
using Helix.ProductService.Domain.Models;
using Helix.ProductService.Infrastructure.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Helix.ProductService.Infrastructure.Helpers.Queries.WarehouseTransactionQuery;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Helix.ProductService.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class WarehouseTransactionController : ControllerBase
{
	IWarehouseTransactionService _warehouseTransactionService;
	public WarehouseTransactionController(IWarehouseTransactionService warehouseTransactionService)
	{
		_warehouseTransactionService = warehouseTransactionService;
	}

	[HttpGet("Warehouse/Number/{number:int}")]
	public async Task<DataResult<IEnumerable<WarehouseTransaction>>> GetTransactionsByWarehouseNumber(int number, [FromQuery] string search = "", string orderBy = WarehouseTransactionOrderBy.DateDesc, int page = 0, int pageSize = 20)
	{
		DataResult<IEnumerable<WarehouseTransaction>> result = new();
		switch (orderBy)
		{
			case "QuantityAsc":
				result = await _warehouseTransactionService.GetTransactionsByWarehouseNumber(number, search, WarehouseTransactionOrderBy.QuantityAsc, page, pageSize);
				return result;
			case "QuantityDesc":
				result = await _warehouseTransactionService.GetTransactionsByWarehouseNumber(number, search, WarehouseTransactionOrderBy.QuantityDesc, page, pageSize);
				return result;
			case "DateAsc":
				result = await _warehouseTransactionService.GetTransactionsByWarehouseNumber(number, search, WarehouseTransactionOrderBy.DateAsc, page, pageSize);
				return result;
			case "DateDesc":
				result = await _warehouseTransactionService.GetTransactionsByWarehouseNumber(number, search, WarehouseTransactionOrderBy.DateDesc, page, pageSize);
				return result;
			default:
				result = await _warehouseTransactionService.GetTransactionsByWarehouseNumber(number, search, orderBy, page, pageSize);
				return result;
		}
	}

	[HttpGet("Warehouse/Number/{number:int}/Input")]
	public async Task<DataResult<IEnumerable<WarehouseTransaction>>> GetInputTransactionByWarehouseNumberAsync(int number, [FromQuery] string search = "", string orderBy = WarehouseTransactionOrderBy.DateDesc, int page = 0, int pageSize = 20)
	{
		DataResult<IEnumerable<WarehouseTransaction>> result = new();
		switch(orderBy)
		{
			case "QuantityAsc":
				result = await _warehouseTransactionService.GetInputTransactionByWarehouseNumberAsync(number, search, WarehouseTransactionOrderBy.QuantityAsc, page, pageSize);
				return result;
			case "QuantityDesc":
				result = await _warehouseTransactionService.GetInputTransactionByWarehouseNumberAsync(number, search, WarehouseTransactionOrderBy.QuantityDesc, page, pageSize);
				return result;
			case "DateAsc":
				result = await _warehouseTransactionService.GetInputTransactionByWarehouseNumberAsync(number, search, WarehouseTransactionOrderBy.DateAsc, page, pageSize);
				return result;
			case "DateDesc":
				result = await _warehouseTransactionService.GetInputTransactionByWarehouseNumberAsync(number, search, WarehouseTransactionOrderBy.DateDesc, page, pageSize);
				return result;
			default:
				result = await _warehouseTransactionService.GetInputTransactionByWarehouseNumberAsync(number, search, orderBy,page, pageSize);
				return result;
		}
	}

	[HttpGet("Warehouse/Id/{id:int}/Input")]
	public async Task<DataResult<IEnumerable<WarehouseTransaction>>> GetInputTransactionByWarehouseReferenceIdAsync(int id, [FromQuery] string search="", string orderBy = WarehouseTransactionOrderBy.DateAsc, int page = 0, int pageSize = 20)
	{
		DataResult<IEnumerable<WarehouseTransaction>> result = new();

		switch (orderBy)
		{
			case "QuantityAsc":
				result = await _warehouseTransactionService.GetInputTransactionByWarehouseReferenceIdAsync(id, search, WarehouseTransactionOrderBy.QuantityAsc, page, pageSize);
				return result;
			case "QuantityDesc":
				result = await _warehouseTransactionService.GetInputTransactionByWarehouseReferenceIdAsync(id, search, WarehouseTransactionOrderBy.QuantityDesc, page, pageSize);
				return result;
			case "DateAsc":
				result = await _warehouseTransactionService.GetInputTransactionByWarehouseReferenceIdAsync(id, search, WarehouseTransactionOrderBy.DateAsc, page, pageSize);
				return result;
			case "DateDesc":
				result = await _warehouseTransactionService.GetInputTransactionByWarehouseReferenceIdAsync(id, search, WarehouseTransactionOrderBy.DateDesc, page, pageSize);
				return result;
			default:
				result = await _warehouseTransactionService.GetInputTransactionByWarehouseReferenceIdAsync(id, search, orderBy, page, pageSize);
				return result;
		}
	}

	[HttpGet("Warehouse/Number/{number:int}/Output")]
	public async Task<DataResult<IEnumerable<WarehouseTransaction>>> GetOutputTransactionByWarehouseNumberAsync(int number, [FromQuery] string search = "", string orderBy = WarehouseTransactionOrderBy.DateAsc, int page = 0, int pageSize = 20)
	{
		DataResult<IEnumerable<WarehouseTransaction>> result = new();
		switch (orderBy)
		{
			case "QuantityAsc":
				result = await _warehouseTransactionService.GetOutputTransactionByWarehouseNumberAsync(number, search, WarehouseTransactionOrderBy.QuantityAsc, page, pageSize);
				return result;
			case "QuantityDesc":
				result = await _warehouseTransactionService.GetOutputTransactionByWarehouseNumberAsync(number, search, WarehouseTransactionOrderBy.QuantityDesc, page, pageSize);
				return result;
			case "DateAsc":
				result = await _warehouseTransactionService.GetOutputTransactionByWarehouseNumberAsync(number, search, WarehouseTransactionOrderBy.DateAsc, page, pageSize);
				return result;
			case "DateDesc":
				result = await _warehouseTransactionService.GetOutputTransactionByWarehouseNumberAsync(number, search, WarehouseTransactionOrderBy.DateDesc, page, pageSize);
				return result;
			default:
				result = await _warehouseTransactionService.GetOutputTransactionByWarehouseNumberAsync(number, search, orderBy, page, pageSize);
				return result;
		}
	}

	[HttpGet("Warehouse/Id/{id:int}/Output")]
	public async Task<DataResult<IEnumerable<WarehouseTransaction>>> GetOutputTransactionByWarehouseReferenceIdAsync(int id, [FromQuery] string search = "", string orderBy = WarehouseTransactionOrderBy.DateAsc, int page = 0, int pageSize = 20)
	{
		DataResult<IEnumerable<WarehouseTransaction>> result = new();

		switch (orderBy)
		{
			case "QuantityAsc":
				result = await _warehouseTransactionService.GetOutputTransactionByWarehouseReferenceIdAsync(id, search, WarehouseTransactionOrderBy.QuantityAsc, page, pageSize);
				return result;
			case "QuantityDesc":
				result = await _warehouseTransactionService.GetOutputTransactionByWarehouseReferenceIdAsync(id, search, WarehouseTransactionOrderBy.QuantityDesc, page, pageSize);
				return result;
			case "DateAsc":
				result = await _warehouseTransactionService.GetOutputTransactionByWarehouseReferenceIdAsync(id, search, WarehouseTransactionOrderBy.DateAsc, page, pageSize);
				return result;
			case "DateDesc":
				result = await _warehouseTransactionService.GetOutputTransactionByWarehouseReferenceIdAsync(id, search, WarehouseTransactionOrderBy.DateDesc, page, pageSize);
				return result;
			default:
				result = await _warehouseTransactionService.GetOutputTransactionByWarehouseReferenceIdAsync(id, search, orderBy, page, pageSize);
				return result;
		}
	}
}
