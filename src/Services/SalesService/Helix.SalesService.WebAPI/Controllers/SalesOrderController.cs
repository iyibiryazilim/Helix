using Helix.EventBus.Base.Abstractions;
using Helix.SalesService.Application.Repository;
using Helix.SalesService.Domain.AggregateModels;
using Helix.SalesService.Domain.Dtos;
using Helix.SalesService.Domain.Events;
using Helix.SalesService.Domain.Models;
using Helix.SalesService.Infrastructure.Helper.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Helix.SalesService.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
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
	public async Task<DataResult<IEnumerable<SalesOrder>>> GetAll([FromQuery] string search = "", string orderBy = SalesOrdersOrderBy.DateDesc, int page = 0, int pageSize = 20)
	{
		DataResult<IEnumerable<SalesOrder>> result = new();
		switch (orderBy)
		{

			case "customernamedesc":
				result = await _salesOrderService.GetSalesOrdersAsync(search, SalesOrdersOrderBy.CustomerNameDesc, page, pageSize);
				return result;
			case "customernameasc":
				result = await _salesOrderService.GetSalesOrdersAsync(search, SalesOrdersOrderBy.CustomerNameAsc, page, pageSize);
				return result;
			case "customercodedesc":
				result = await _salesOrderService.GetSalesOrdersAsync(search, SalesOrdersOrderBy.CustomerCodeDesc, page, pageSize);
				return result;
			case "customercodeasc":
				result = await _salesOrderService.GetSalesOrdersAsync(search, SalesOrdersOrderBy.CustomerCodeAsc, page, pageSize);
				return result;
			case "nettotalasc":
				result = await _salesOrderService.GetSalesOrdersAsync(search, SalesOrdersOrderBy.NetTotalAsc, page, pageSize);
				return result;
			case "nettotaldesc":
				result = await _salesOrderService.GetSalesOrdersAsync(search, SalesOrdersOrderBy.NetTotalDesc, page, pageSize);
				return result;
			case "dateasc":
				result = await _salesOrderService.GetSalesOrdersAsync(search, SalesOrdersOrderBy.DateAsc, page, pageSize);
				return result;
			case "datedesc":
				result = await _salesOrderService.GetSalesOrdersAsync(search, SalesOrdersOrderBy.DateDesc, page, pageSize);
				return result;
			default:
				result = await _salesOrderService.GetSalesOrdersAsync(search, orderBy, page, pageSize);
				return result;
		}
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
	public async Task<DataResult<IEnumerable<SalesOrder>>> GetByCurrentId(int id, [FromQuery] string search = "", string orderBy = SalesOrdersOrderBy.DateDesc, int page = 0, int pageSize = 20)
	{
		DataResult<IEnumerable<SalesOrder>> result = new();
		switch (orderBy)
		{

			case "customernamedesc":
				result = await _salesOrderService.GetSalesOrdersByCurrentIdAsync(id, search, SalesOrdersOrderBy.CustomerNameDesc, page, pageSize);
				return result;													 
			case "customernameasc":												 
				result = await _salesOrderService.GetSalesOrdersByCurrentIdAsync(id, search, SalesOrdersOrderBy.CustomerNameAsc, page, pageSize);
				return result;													 
			case "customercodedesc":											 
				result = await _salesOrderService.GetSalesOrdersByCurrentIdAsync(id, search, SalesOrdersOrderBy.CustomerCodeDesc, page, pageSize);
				return result;													 
			case "customercodeasc":												 
				result = await _salesOrderService.GetSalesOrdersByCurrentIdAsync(id, search, SalesOrdersOrderBy.CustomerCodeAsc, page, pageSize);
				return result;													 
			case "nettotalasc":													 
				result = await _salesOrderService.GetSalesOrdersByCurrentIdAsync(id, search, SalesOrdersOrderBy.NetTotalAsc, page, pageSize);
				return result;													 
			case "nettotaldesc":												 
				result = await _salesOrderService.GetSalesOrdersByCurrentIdAsync(id, search, SalesOrdersOrderBy.NetTotalDesc, page, pageSize);
				return result;													 
			case "dateasc":														 
				result = await _salesOrderService.GetSalesOrdersByCurrentIdAsync(id, search, SalesOrdersOrderBy.DateAsc, page, pageSize);
				return result;													 
			case "datedesc":													 
				result = await _salesOrderService.GetSalesOrdersByCurrentIdAsync(id, search, SalesOrdersOrderBy.DateDesc, page, pageSize);
				return result;													 
			default:															 
				result = await _salesOrderService.GetSalesOrdersByCurrentIdAsync(id,search, orderBy, page, pageSize);
				return result;
		}
	}

    [HttpGet("CurrentAndWarehouse/Id/{id:int}&{number:int}")]
    public async Task<DataResult<IEnumerable<SalesOrder>>> GetByCurrentIdAndWarehouseNumber(int id,int number, [FromQuery] string search = "", string orderBy = SalesOrdersOrderBy.DateDesc, int page = 0, int pageSize = 20)
    {
        DataResult<IEnumerable<SalesOrder>> result = new();
        switch (orderBy)
        {

            case "customernamedesc":
                result = await _salesOrderService.GetSalesOrdersByCurrentIdAndWarehouseNumberAsync(id, number, search, SalesOrdersOrderBy.CustomerNameDesc, page, pageSize);
                return result;
            case "customernameasc":
                result = await _salesOrderService.GetSalesOrdersByCurrentIdAndWarehouseNumberAsync(id, number, search, SalesOrdersOrderBy.CustomerNameAsc, page, pageSize);
                return result;
            case "customercodedesc":
                result = await _salesOrderService.GetSalesOrdersByCurrentIdAndWarehouseNumberAsync(id, number, search, SalesOrdersOrderBy.CustomerCodeDesc, page, pageSize);
                return result;
            case "customercodeasc":
                result = await _salesOrderService.GetSalesOrdersByCurrentIdAndWarehouseNumberAsync(id, number, search, SalesOrdersOrderBy.CustomerCodeAsc, page, pageSize);
                return result;
            case "nettotalasc":
                result = await _salesOrderService.GetSalesOrdersByCurrentIdAndWarehouseNumberAsync(id, number, search, SalesOrdersOrderBy.NetTotalAsc, page, pageSize);
                return result;
            case "nettotaldesc":
                result = await _salesOrderService.GetSalesOrdersByCurrentIdAndWarehouseNumberAsync(id, number, search, SalesOrdersOrderBy.NetTotalDesc, page, pageSize);
                return result;
            case "dateasc":
                result = await _salesOrderService.GetSalesOrdersByCurrentIdAndWarehouseNumberAsync(id, number, search, SalesOrdersOrderBy.DateAsc, page, pageSize);
                return result;
            case "datedesc":
                result = await _salesOrderService.GetSalesOrdersByCurrentIdAndWarehouseNumberAsync(id, number, search, SalesOrdersOrderBy.DateDesc, page, pageSize);
                return result;
            default:
                result = await _salesOrderService.GetSalesOrdersByCurrentIdAndWarehouseNumberAsync(id,number, search, orderBy, page, pageSize);
                return result;
        }
    }

    [HttpGet("CurrentAndWarehouseAndShipInfo/Id/{id:int}&{number:int}&{shipInfoReferenceId:int}")]
    public async Task<DataResult<IEnumerable<SalesOrder>>> GetByCurrentIdAndWarehouseNumberAndShipInfo(int id, int number,int shipInfoReferenceId, [FromQuery] string search = "", string orderBy = SalesOrdersOrderBy.DateDesc, int page = 0, int pageSize = 20)
    {
        DataResult<IEnumerable<SalesOrder>> result = new();
        switch (orderBy)
        {

            case "customernamedesc":
                result = await _salesOrderService.GetSalesOrdersByCurrentIdAndWarehouseNumberAndShipInfoAsync(id, number, shipInfoReferenceId, search, SalesOrdersOrderBy.CustomerNameDesc, page, pageSize);
                return result;
            case "customernameasc":
                result = await _salesOrderService.GetSalesOrdersByCurrentIdAndWarehouseNumberAndShipInfoAsync(id, number, shipInfoReferenceId, search, SalesOrdersOrderBy.CustomerNameAsc, page, pageSize);
                return result;
            case "customercodedesc":
                result = await _salesOrderService.GetSalesOrdersByCurrentIdAndWarehouseNumberAndShipInfoAsync(id, number, shipInfoReferenceId, search, SalesOrdersOrderBy.CustomerCodeDesc, page, pageSize);
                return result;
            case "customercodeasc":
                result = await _salesOrderService.GetSalesOrdersByCurrentIdAndWarehouseNumberAndShipInfoAsync(id, number, shipInfoReferenceId, search, SalesOrdersOrderBy.CustomerCodeAsc, page, pageSize);
                return result;
            case "nettotalasc":
                result = await _salesOrderService.GetSalesOrdersByCurrentIdAndWarehouseNumberAndShipInfoAsync(id, number, shipInfoReferenceId, search, SalesOrdersOrderBy.NetTotalAsc, page, pageSize);
                return result;
            case "nettotaldesc":
                result = await _salesOrderService.GetSalesOrdersByCurrentIdAndWarehouseNumberAndShipInfoAsync(id, number, shipInfoReferenceId, search, SalesOrdersOrderBy.NetTotalDesc, page, pageSize);
                return result;
            case "dateasc":
                result = await _salesOrderService.GetSalesOrdersByCurrentIdAndWarehouseNumberAndShipInfoAsync(id, number, shipInfoReferenceId, search, SalesOrdersOrderBy.DateAsc, page, pageSize);
                return result;
            case "datedesc":
                result = await _salesOrderService.GetSalesOrdersByCurrentIdAndWarehouseNumberAndShipInfoAsync(id, number, shipInfoReferenceId, search, SalesOrdersOrderBy.DateDesc, page, pageSize);
                return result;
            default:
                result = await _salesOrderService.GetSalesOrdersByCurrentIdAndWarehouseNumberAndShipInfoAsync(id, number,shipInfoReferenceId, search, orderBy, page, pageSize);
                return result;
        }
    }

    [HttpGet("Current/Code/{code}")]
	public async Task<DataResult<IEnumerable<SalesOrder>>> GetByCurrentCode(string code, [FromQuery] string search = "", string orderBy = SalesOrdersOrderBy.DateDesc, int page = 0, int pageSize = 20)
	{
		DataResult<IEnumerable<SalesOrder>> result = new();
		switch (orderBy)
		{

			case "customernamedesc":
				result = await _salesOrderService.GetSalesOrdersByCurrentCodeAsync(code, search, SalesOrdersOrderBy.CustomerNameDesc, page, pageSize);
				return result;
			case "customernameasc":
				result = await _salesOrderService.GetSalesOrdersByCurrentCodeAsync(code, search, SalesOrdersOrderBy.CustomerNameAsc, page, pageSize);
				return result;
			case "customercodedesc":
				result = await _salesOrderService.GetSalesOrdersByCurrentCodeAsync(code, search, SalesOrdersOrderBy.CustomerCodeDesc, page, pageSize);
				return result;
			case "customercodeasc":
				result = await _salesOrderService.GetSalesOrdersByCurrentCodeAsync(code, search, SalesOrdersOrderBy.CustomerCodeAsc, page, pageSize);
				return result;
			case "nettotalasc":
				result = await _salesOrderService.GetSalesOrdersByCurrentCodeAsync(code, search, SalesOrdersOrderBy.NetTotalAsc, page, pageSize);
				return result;
			case "nettotaldesc":
				result = await _salesOrderService.GetSalesOrdersByCurrentCodeAsync(code, search, SalesOrdersOrderBy.NetTotalDesc, page, pageSize);
				return result;
			case "dateasc":
				result = await _salesOrderService.GetSalesOrdersByCurrentCodeAsync(code, search, SalesOrdersOrderBy.DateAsc, page, pageSize);
				return result;
			case "datedesc":
				result = await _salesOrderService.GetSalesOrdersByCurrentCodeAsync(code, search, SalesOrdersOrderBy.DateDesc, page, pageSize);
				return result;
			default:
				result = await _salesOrderService.GetSalesOrdersByCurrentCodeAsync(code, search, orderBy, page, pageSize);
				return result;
		}
	}

	[HttpPost]
	public async Task SalesOrderInsert([FromBody] SalesOrderDto salesOrderDto)
	{
		
		_eventBus.Publish(new SalesOrderInsertingIntegrationEvent(salesOrderDto.referenceId, salesOrderDto.code, salesOrderDto.orderDate));
	}
}
