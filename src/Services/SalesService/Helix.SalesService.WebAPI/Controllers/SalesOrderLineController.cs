using Helix.SalesService.Application.Repository;
using Helix.SalesService.Domain.AggregateModels;
using Helix.SalesService.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Helix.SalesService.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SalesOrderLineController : ControllerBase
{
	ISalesOrderLineService _salesOrderLineService;

    public SalesOrderLineController(ISalesOrderLineService salesOrderLineService)
    {
        _salesOrderLineService = salesOrderLineService;
    }

	[HttpGet("{includeWaiting}")]
	public async Task<DataResult<IEnumerable<SalesOrderLine>>> GetAll(bool includeWaiting = false)
	{
		if (includeWaiting)
		{
			var _result = await _salesOrderLineService.GetWaitingSalesOrderLinesAsync();
			return _result;
		}

		var result = await _salesOrderLineService.GetSalesOrderLinesAsync();
		return result;
	}
	[HttpGet("Code/{code}")]
	public async Task<DataResult<SalesOrderLine>> GetByCode(string code)
	{
		var result = await _salesOrderLineService.GetSalesOrderLineByCode(code);
		return result;
	}
	[HttpGet("Id/{id:int}")]
	public async Task<DataResult<SalesOrderLine>> GetById(int id)
	{
		var result = await _salesOrderLineService.GetSalesOrderLineByIdAsync(id);
		return result;
	}

	[HttpGet("Current/Id/{id:int}&{includeWaiting}")]
	public async Task<DataResult<IEnumerable<SalesOrderLine>>> GetByCurrentId(int id, bool includeWaiting = false)
	{
		if (includeWaiting)
		{
			var _result = await _salesOrderLineService.GetWaitingSalesOrdersByCurrentIdAsync(id);
			return _result;
		}

		var result = await _salesOrderLineService.GetSalesOrdersByCurrentIdAsync(id);
		return result;
	}

	[HttpGet("Current/Code/{code}&{includeWaiting}")]
	public async Task<DataResult<IEnumerable<SalesOrderLine>>> GetByCurrentCode(string code, bool includeWaiting = false)
	{
		if (includeWaiting)
		{
			var _result = await _salesOrderLineService.GetWaitingSalesOrdersByCurrentCodeAsync(code);
			return _result;
		}

		var result = await _salesOrderLineService.GetSalesOrdersByCurrentCodeAsync(code);
		return result;
	}

	[HttpGet("Product/Id/{id}&{includeWaiting}")]
	public async Task<DataResult<IEnumerable<SalesOrderLine>>> GetByProductId(int id, bool includeWaiting = false)
	{
		if (includeWaiting)
		{
			var _result = await _salesOrderLineService.GetWaitingSalesOrdersByProductIdAsync(id);
			return _result;
		}

		var result = await _salesOrderLineService.GetSalesOrdersByProductIdAsync(id);
		return result;
	}

	[HttpGet("Product/Code/{code}&{includeWaiting}")]
	public async Task<DataResult<IEnumerable<SalesOrderLine>>> GetByProductCode(string code, bool includeWaiting = false)
	{
		if (includeWaiting)
		{
			var _result = await _salesOrderLineService.GetWaitingSalesOrdersByProductCodeAsync(code);
			return _result;
		}

		var result = await _salesOrderLineService.GetSalesOrdersByProductCodeAsync(code);
		return result;
	}
}
