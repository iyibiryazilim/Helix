using Helix.EventBus.Base.Abstractions;
using Helix.SalesService.Application.Repository;
using Helix.SalesService.Domain.AggregateModels;
using Helix.SalesService.Domain.Dtos;
using Helix.SalesService.Domain.Events;
using Helix.SalesService.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Helix.SalesService.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SalesOrderController : ControllerBase
{
	ISalesOrderService _salesOrderService;
	IEventBus _eventBus;

	public SalesOrderController(ISalesOrderService salesOrderService,IEventBus eventBus)
    {
        _salesOrderService = salesOrderService;
		_eventBus = eventBus;
    }

    [HttpGet]
	public async Task<DataResult<IEnumerable<SalesOrder>>> GetAll()
	{
		var result = await _salesOrderService.GetSalesOrdersAsync();
		return result;
	}
	[HttpGet("Code/{code}")]
	public async Task<DataResult<SalesOrder>> GetByCode(string code)
	{
		var result = await _salesOrderService.GetSalesOrderByCode(code);
		return result;
	}
	[HttpGet("Id/{id:int}")]
	public async Task<DataResult<SalesOrder>> GetById(int id)
	{
		var result = await _salesOrderService.GetSalesOrderByIdAsync(id);
		return result;
	}

	[HttpGet("Current/Id/{id:int}")]
	public async Task<DataResult<IEnumerable<SalesOrder>>> GetByCurrentId(int id)
	{
		var result = await _salesOrderService.GetSalesOrdersByCurrentIdAsync(id);
		return result;
	}

	[HttpGet("Current/Code/{code}")]
	public async Task<DataResult<IEnumerable<SalesOrder>>> GetByCurrentCode(string code)
	{
		var result = await _salesOrderService.GetSalesOrdersByCurrentCodeAsync(code);
		return result;
	}

	[HttpPost]
	public async Task SalesOrderInsert([FromBody] SalesOrderDto salesOrderDto)
	{

		_eventBus.Publish(new SalesOrderInsertedIntegrationEvent(salesOrderDto.referenceId, salesOrderDto.code, salesOrderDto.orderDate));
	}
}
