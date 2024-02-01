using Helix.SalesService.Application.Repository;
using Helix.SalesService.Domain.AggregateModels;
using Helix.SalesService.Domain.Models;
using Helix.SalesService.Infrastructure.Helper.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Helix.SalesService.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
//[Authorize]
public class SalesOrderLineController : ControllerBase
{
	ISalesOrderLineService _salesOrderLineService;

	public SalesOrderLineController(ISalesOrderLineService salesOrderLineService)
	{
		_salesOrderLineService = salesOrderLineService;
	}

	[HttpGet("{includeWaiting}")]
	public async Task<DataResult<IEnumerable<SalesOrderLine>>> GetAll(bool includeWaiting = false, [FromQuery] string search = "", string orderBy = SalesOrderLineOrderBy.DueDateAsc, int page = 0, int pageSize = 20)
	{
		DataResult<IEnumerable<SalesOrderLine>> result = new();
		switch (orderBy)
		{

			case "customernamedesc":
				if (includeWaiting)
				{
					result = await _salesOrderLineService.GetWaitingSalesOrderLinesAsync(search, SalesOrderLineOrderBy.CustomerNameDesc, page, pageSize);
					return result;
				}
				result = await _salesOrderLineService.GetSalesOrderLinesAsync(search, SalesOrderLineOrderBy.CustomerNameDesc, page, pageSize);
				return result;
			case "customernameasc":
				if (includeWaiting)
				{
					result = await _salesOrderLineService.GetWaitingSalesOrderLinesAsync(search, SalesOrderLineOrderBy.CustomerNameAsc, page, pageSize);
					return result;
				}
				result = await _salesOrderLineService.GetSalesOrderLinesAsync(search, SalesOrderLineOrderBy.CustomerNameAsc, page, pageSize);
				return result;
			case "customercodedesc":
				if (includeWaiting)
				{
					result = await _salesOrderLineService.GetWaitingSalesOrderLinesAsync(search, SalesOrderLineOrderBy.CustomerCodeDesc, page, pageSize);
					return result;
				}
				result = await _salesOrderLineService.GetSalesOrderLinesAsync(search, SalesOrderLineOrderBy.CustomerCodeDesc, page, pageSize);
				return result;
			case "customercodeasc":
				if (includeWaiting)
				{
					result = await _salesOrderLineService.GetWaitingSalesOrderLinesAsync(search, SalesOrderLineOrderBy.CustomerCodeAsc, page, pageSize);
					return result;
				}
				result = await _salesOrderLineService.GetSalesOrderLinesAsync(search, SalesOrderLineOrderBy.CustomerCodeAsc, page, pageSize);
				return result;
			case "productnamedesc":
				if (includeWaiting)
				{
					result = await _salesOrderLineService.GetWaitingSalesOrderLinesAsync(search, SalesOrderLineOrderBy.ProductNameDesc, page, pageSize);
					return result;
				}
				result = await _salesOrderLineService.GetSalesOrderLinesAsync(search, SalesOrderLineOrderBy.ProductNameDesc, page, pageSize);
				return result;
			case "productnameasc":
				if (includeWaiting)
				{
					result = await _salesOrderLineService.GetWaitingSalesOrderLinesAsync(search, SalesOrderLineOrderBy.ProductNameAsc, page, pageSize);
					return result;
				}
				result = await _salesOrderLineService.GetSalesOrderLinesAsync(search, SalesOrderLineOrderBy.ProductNameAsc, page, pageSize);
				return result;
			case "productcodedesc":
				if (includeWaiting)
				{
					result = await _salesOrderLineService.GetWaitingSalesOrderLinesAsync(search, SalesOrderLineOrderBy.ProductCodeDesc, page, pageSize);
					return result;
				}
				result = await _salesOrderLineService.GetSalesOrderLinesAsync(search, SalesOrderLineOrderBy.ProductCodeDesc, page, pageSize);
				return result;
			case "productcodeasc":
				if (includeWaiting)
				{
					result = await _salesOrderLineService.GetWaitingSalesOrderLinesAsync(search, SalesOrderLineOrderBy.ProductCodeAsc, page, pageSize);
					return result;
				}
				result = await _salesOrderLineService.GetSalesOrderLinesAsync(search, SalesOrderLineOrderBy.ProductCodeAsc, page, pageSize);
				return result;
			case "duedateasc":
				if (includeWaiting)
				{
					result = await _salesOrderLineService.GetWaitingSalesOrderLinesAsync(search, SalesOrderLineOrderBy.DueDateAsc, page, pageSize);
					return result;
				}
				result = await _salesOrderLineService.GetSalesOrderLinesAsync(search, SalesOrderLineOrderBy.DueDateAsc, page, pageSize);
				return result;
			case "duedatedesc":
				if (includeWaiting)
				{
					result = await _salesOrderLineService.GetWaitingSalesOrderLinesAsync(search, SalesOrderLineOrderBy.DueDateDesc, page, pageSize);
					return result;
				}
				result = await _salesOrderLineService.GetSalesOrderLinesAsync(search, SalesOrderLineOrderBy.DueDateDesc, page, pageSize);
				return result;
			default:
				if (includeWaiting)
				{
					result = await _salesOrderLineService.GetWaitingSalesOrderLinesAsync(search, orderBy, page, pageSize);
					return result;
				}
				result = await _salesOrderLineService.GetSalesOrderLinesAsync(search, orderBy, page, pageSize);
				return result;

		}

	}
	[HttpGet("Fiche/Code/{code}&{includeWaiting}")]
	public async Task<DataResult<IEnumerable<SalesOrderLine>>> GetByFicheCode(string code, bool includeWaiting = false,  [FromQuery] string search = "", string orderBy = SalesOrderLineOrderBy.DueDateAsc, int page = 0, int pageSize = 20)
	{
		DataResult<IEnumerable<SalesOrderLine>> result = new();
		switch (orderBy)
		{

			case "customernamedesc":
				if (includeWaiting)
				{
					result = await _salesOrderLineService.GetWaitingSalesOrderLineFicheByCodeAsync(code,search, SalesOrderLineOrderBy.CustomerNameDesc, page, pageSize);
					return result;
				}
				result = await _salesOrderLineService.GetSalesOrderLineFicheByCodeAsync(code, search, SalesOrderLineOrderBy.CustomerNameDesc, page, pageSize);
				return result;
			case "customernameasc":
				if (includeWaiting)
				{
					result = await _salesOrderLineService.GetWaitingSalesOrderLineFicheByCodeAsync(code, search, SalesOrderLineOrderBy.CustomerNameAsc, page, pageSize);
					return result;
				}
				result = await _salesOrderLineService.GetSalesOrderLineFicheByCodeAsync(code, search, SalesOrderLineOrderBy.CustomerNameAsc, page, pageSize);
				return result;
			case "customercodedesc":
				if (includeWaiting)
				{
					result = await _salesOrderLineService.GetWaitingSalesOrderLineFicheByCodeAsync(code, search, SalesOrderLineOrderBy.CustomerCodeDesc, page, pageSize);
					return result;
				}
				result = await _salesOrderLineService.GetSalesOrderLineFicheByCodeAsync(code, search, SalesOrderLineOrderBy.CustomerCodeDesc, page, pageSize);
				return result;
			case "customercodeasc":
				if (includeWaiting)
				{
					result = await _salesOrderLineService.GetWaitingSalesOrderLineFicheByCodeAsync(code, search, SalesOrderLineOrderBy.CustomerCodeAsc, page, pageSize);
					return result;
				}
				result = await _salesOrderLineService.GetSalesOrderLineFicheByCodeAsync(code, search, SalesOrderLineOrderBy.CustomerCodeAsc, page, pageSize);
				return result;
			case "productnamedesc":
				if (includeWaiting)
				{
					result = await _salesOrderLineService.GetWaitingSalesOrderLineFicheByCodeAsync(code, search, SalesOrderLineOrderBy.ProductNameDesc, page, pageSize);
					return result;
				}
				result = await _salesOrderLineService.GetSalesOrderLineFicheByCodeAsync(code, search, SalesOrderLineOrderBy.ProductNameDesc, page, pageSize);
				return result;
			case "productnameasc":
				if (includeWaiting)
				{
					result = await _salesOrderLineService.GetWaitingSalesOrderLineFicheByCodeAsync(code, search, SalesOrderLineOrderBy.ProductNameAsc, page, pageSize);
					return result;
				}
				result = await _salesOrderLineService.GetSalesOrderLineFicheByCodeAsync(code, search, SalesOrderLineOrderBy.ProductNameAsc, page, pageSize);
				return result;
			case "productcodedesc":
				if (includeWaiting)
				{
					result = await _salesOrderLineService.GetWaitingSalesOrderLineFicheByCodeAsync(code, search, SalesOrderLineOrderBy.ProductCodeDesc, page, pageSize);
					return result;
				}
				result = await _salesOrderLineService.GetSalesOrderLineFicheByCodeAsync(code, search, SalesOrderLineOrderBy.ProductCodeDesc, page, pageSize);
				return result;
			case "productcodeasc":
				if (includeWaiting)
				{
					result = await _salesOrderLineService.GetWaitingSalesOrderLineFicheByCodeAsync(code, search, SalesOrderLineOrderBy.ProductCodeAsc, page, pageSize);
					return result;
				}
				result = await _salesOrderLineService.GetSalesOrderLineFicheByCodeAsync(code, search, SalesOrderLineOrderBy.ProductCodeAsc, page, pageSize);
				return result;
			case "duedateasc":
				if (includeWaiting)
				{
					result = await _salesOrderLineService.GetWaitingSalesOrderLineFicheByCodeAsync(code, search, SalesOrderLineOrderBy.DueDateAsc, page, pageSize);
					return result;
				}
				result = await _salesOrderLineService.GetSalesOrderLineFicheByCodeAsync(code, search, SalesOrderLineOrderBy.DueDateAsc, page, pageSize);
				return result;
			case "duedatedesc":
				if (includeWaiting)
				{
					result = await _salesOrderLineService.GetWaitingSalesOrderLineFicheByCodeAsync(code, search, SalesOrderLineOrderBy.DueDateDesc, page, pageSize);
					return result;
				}
				result = await _salesOrderLineService.GetSalesOrderLineFicheByCodeAsync(code, search, SalesOrderLineOrderBy.DueDateDesc, page, pageSize);
				return result;
			default:
				if (includeWaiting)
				{
					result = await _salesOrderLineService.GetWaitingSalesOrderLineFicheByCodeAsync(code, search, orderBy, page, pageSize);
					return result;
				}
				result = await _salesOrderLineService.GetSalesOrderLineFicheByCodeAsync(code,search, orderBy, page, pageSize);
				return result;

		}

	}

	[HttpGet("Fiche/Id/{id:int}&{includeWaiting}")]
	public async Task<DataResult<IEnumerable<SalesOrderLine>>> GetByFicheId(int id, bool includeWaiting = false,  [FromQuery] string search = "", string orderBy = SalesOrderLineOrderBy.DueDateAsc, int page = 0, int pageSize = 20)
	{
		DataResult<IEnumerable<SalesOrderLine>> result = new();
		switch (orderBy)
		{

			case "customernamedesc":
				if (includeWaiting)
				{
					result = await _salesOrderLineService.GetWaitingSalesOrderLineByFicheIdAsync(id, search, SalesOrderLineOrderBy.CustomerNameDesc, page, pageSize);
					return result;
				}
				result = await _salesOrderLineService.GetSalesOrderLineByFicheIdAsync(id, search, SalesOrderLineOrderBy.CustomerNameDesc, page, pageSize);
				return result;
			case "customernameasc":
				if (includeWaiting)
				{
					result = await _salesOrderLineService.GetWaitingSalesOrderLineByFicheIdAsync(id, search, SalesOrderLineOrderBy.CustomerNameAsc, page, pageSize);
					return result;
				}
				result = await _salesOrderLineService.GetSalesOrderLineByFicheIdAsync(id, search, SalesOrderLineOrderBy.CustomerNameAsc, page, pageSize);
				return result;
			case "customercodedesc":
				if (includeWaiting)
				{
					result = await _salesOrderLineService.GetWaitingSalesOrderLineByFicheIdAsync(id, search, SalesOrderLineOrderBy.CustomerCodeDesc, page, pageSize);
					return result;
				}
				result = await _salesOrderLineService.GetSalesOrderLineByFicheIdAsync(id, search, SalesOrderLineOrderBy.CustomerCodeDesc, page, pageSize);
				return result;
			case "customercodeasc":
				if (includeWaiting)
				{
					result = await _salesOrderLineService.GetWaitingSalesOrderLineByFicheIdAsync(id, search, SalesOrderLineOrderBy.CustomerCodeAsc, page, pageSize);
					return result;
				}
				result = await _salesOrderLineService.GetSalesOrderLineByFicheIdAsync(id, search, SalesOrderLineOrderBy.CustomerCodeAsc, page, pageSize);
				return result;
			case "productnamedesc":
				if (includeWaiting)
				{
					result = await _salesOrderLineService.GetWaitingSalesOrderLineByFicheIdAsync(id, search, SalesOrderLineOrderBy.ProductNameDesc, page, pageSize);
					return result;
				}
				result = await _salesOrderLineService.GetSalesOrderLineByFicheIdAsync(id, search, SalesOrderLineOrderBy.ProductNameDesc, page, pageSize);
				return result;
			case "productnameasc":
				if (includeWaiting)
				{
					result = await _salesOrderLineService.GetWaitingSalesOrderLineByFicheIdAsync(id, search, SalesOrderLineOrderBy.ProductNameAsc, page, pageSize);
					return result;
				}
				result = await _salesOrderLineService.GetSalesOrderLineByFicheIdAsync(id, search, SalesOrderLineOrderBy.ProductNameAsc, page, pageSize);
				return result;
			case "productcodedesc":
				if (includeWaiting)
				{
					result = await _salesOrderLineService.GetWaitingSalesOrderLineByFicheIdAsync(id, search, SalesOrderLineOrderBy.ProductCodeDesc, page, pageSize);
					return result;
				}
				result = await _salesOrderLineService.GetSalesOrderLineByFicheIdAsync(id, search, SalesOrderLineOrderBy.ProductCodeDesc, page, pageSize);
				return result;
			case "productcodeasc":
				if (includeWaiting)
				{
					result = await _salesOrderLineService.GetWaitingSalesOrderLineByFicheIdAsync(id, search, SalesOrderLineOrderBy.ProductCodeAsc, page, pageSize);
					return result;
				}
				result = await _salesOrderLineService.GetSalesOrderLineByFicheIdAsync(id, search, SalesOrderLineOrderBy.ProductCodeAsc, page, pageSize);
				return result;
			case "duedateasc":
				if (includeWaiting)
				{
					result = await _salesOrderLineService.GetWaitingSalesOrderLineByFicheIdAsync(id, search, SalesOrderLineOrderBy.DueDateAsc, page, pageSize);
					return result;
				}
				result = await _salesOrderLineService.GetSalesOrderLineByFicheIdAsync(id, search, SalesOrderLineOrderBy.DueDateAsc, page, pageSize);
				return result;
			case "duedatedesc":
				if (includeWaiting)
				{
					result = await _salesOrderLineService.GetWaitingSalesOrderLineByFicheIdAsync(id, search, SalesOrderLineOrderBy.DueDateDesc, page, pageSize);
					return result;
				}
				result = await _salesOrderLineService.GetSalesOrderLineByFicheIdAsync(id, search, SalesOrderLineOrderBy.DueDateDesc, page, pageSize);
				return result;
			default:
				if (includeWaiting)
				{
					result = await _salesOrderLineService.GetWaitingSalesOrderLineByFicheIdAsync(id, search, orderBy, page, pageSize);
					return result;
				}
				result = await _salesOrderLineService.GetSalesOrderLineByFicheIdAsync(id, search, orderBy, page, pageSize);
				return result;

		}

	}

	[HttpGet("Current/Id/{id:int}&{includeWaiting}")]
	public async Task<DataResult<IEnumerable<SalesOrderLine>>> GetByCurrentId(int id, bool includeWaiting = false, [FromQuery] string search = "", string orderBy = SalesOrderLineOrderBy.DueDateAsc, int page = 0, int pageSize = 20)
	{
		DataResult<IEnumerable<SalesOrderLine>> result = new();
		switch (orderBy)
		{

			case "customernamedesc":
				if (includeWaiting)
				{
					result = await _salesOrderLineService.GetWaitingSalesOrdersByCurrentIdAsync(id,search, SalesOrderLineOrderBy.CustomerNameDesc, page, pageSize);
					return result;
				}
				result = await _salesOrderLineService.GetSalesOrdersByCurrentIdAsync(id, search, SalesOrderLineOrderBy.CustomerNameDesc, page, pageSize);
				return result;
			case "customernameasc":
				if (includeWaiting)
				{
					result = await _salesOrderLineService.GetWaitingSalesOrdersByCurrentIdAsync(id, search, SalesOrderLineOrderBy.CustomerNameAsc, page, pageSize);
					return result;
				}
				result = await _salesOrderLineService.GetSalesOrdersByCurrentIdAsync(id, search, SalesOrderLineOrderBy.CustomerNameAsc, page, pageSize);
				return result;
			case "customercodedesc":
				if (includeWaiting)
				{
					result = await _salesOrderLineService.GetWaitingSalesOrdersByCurrentIdAsync(id, search, SalesOrderLineOrderBy.CustomerCodeDesc, page, pageSize);
					return result;
				}
				result = await _salesOrderLineService.GetSalesOrdersByCurrentIdAsync(id, search, SalesOrderLineOrderBy.CustomerCodeDesc, page, pageSize);
				return result;
			case "customercodeasc":
				if (includeWaiting)
				{
					result = await _salesOrderLineService.GetWaitingSalesOrdersByCurrentIdAsync(id, search, SalesOrderLineOrderBy.CustomerCodeAsc, page, pageSize);
					return result;
				}
				result = await _salesOrderLineService.GetSalesOrdersByCurrentIdAsync(id, search, SalesOrderLineOrderBy.CustomerCodeAsc, page, pageSize);
				return result;
			case "productnamedesc":
				if (includeWaiting)
				{
					result = await _salesOrderLineService.GetWaitingSalesOrdersByCurrentIdAsync(id, search, SalesOrderLineOrderBy.ProductNameDesc, page, pageSize);
					return result;
				}
				result = await _salesOrderLineService.GetSalesOrdersByCurrentIdAsync(id, search, SalesOrderLineOrderBy.ProductNameDesc, page, pageSize);
				return result;
			case "productnameasc":
				if (includeWaiting)
				{
					result = await _salesOrderLineService.GetWaitingSalesOrdersByCurrentIdAsync(id, search, SalesOrderLineOrderBy.ProductNameAsc, page, pageSize);
					return result;
				}
				result = await _salesOrderLineService.GetSalesOrdersByCurrentIdAsync(id, search, SalesOrderLineOrderBy.ProductNameAsc, page, pageSize);
				return result;
			case "productcodedesc":
				if (includeWaiting)
				{
					result = await _salesOrderLineService.GetWaitingSalesOrdersByCurrentIdAsync(id, search, SalesOrderLineOrderBy.ProductCodeDesc, page, pageSize);
					return result;
				}
				result = await _salesOrderLineService.GetSalesOrdersByCurrentIdAsync(id, search, SalesOrderLineOrderBy.ProductCodeDesc, page, pageSize);
				return result;
			case "productcodeasc":
				if (includeWaiting)
				{
					result = await _salesOrderLineService.GetWaitingSalesOrdersByCurrentIdAsync(id, search, SalesOrderLineOrderBy.ProductCodeAsc, page, pageSize);
					return result;
				}
				result = await _salesOrderLineService.GetSalesOrdersByCurrentIdAsync(id, search, SalesOrderLineOrderBy.ProductCodeAsc, page, pageSize);
				return result;
			case "duedateasc":
				if (includeWaiting)
				{
					result = await _salesOrderLineService.GetWaitingSalesOrdersByCurrentIdAsync(id, search, SalesOrderLineOrderBy.DueDateAsc, page, pageSize);
					return result;
				}
				result = await _salesOrderLineService.GetSalesOrdersByCurrentIdAsync(id, search, SalesOrderLineOrderBy.DueDateAsc, page, pageSize);
				return result;
			case "duedatedesc":
				if (includeWaiting)
				{
					result = await _salesOrderLineService.GetWaitingSalesOrdersByCurrentIdAsync(id, search, SalesOrderLineOrderBy.DueDateDesc, page, pageSize);
					return result;
				}
				result = await _salesOrderLineService.GetSalesOrdersByCurrentIdAsync(id, search, SalesOrderLineOrderBy.DueDateDesc, page, pageSize);
				return result;
			default:
				if (includeWaiting)
				{
					result = await _salesOrderLineService.GetWaitingSalesOrdersByCurrentIdAsync(id, search, orderBy, page, pageSize);
					return result;
				}
				result = await _salesOrderLineService.GetSalesOrdersByCurrentIdAsync(id, search, orderBy, page, pageSize);
				return result;

		}
		
	}

    [HttpGet("CurrentAndWarehouse/Id/{id:int}&{includeWaiting}&{warehouseNumber:int}")]
    public async Task<DataResult<IEnumerable<SalesOrderLine>>> GetByCurrentIdAndWarehouseNumber(int id,int warehouseNumber, bool includeWaiting = false, [FromQuery] string search = "", string orderBy = SalesOrderLineOrderBy.DueDateAsc, int page = 0, int pageSize = 20)
    {
        DataResult<IEnumerable<SalesOrderLine>> result = new();
        switch (orderBy)
        {

            case "customernamedesc":
                if (includeWaiting)
                {
                    result = await _salesOrderLineService.GetWaitingSalesOrdersByCurrentIdAndWarehouseNumberAsync(id,warehouseNumber, search, SalesOrderLineOrderBy.CustomerNameDesc, page, pageSize);
                    return result;
                }
                result = await _salesOrderLineService.GetWaitingSalesOrdersByCurrentIdAndWarehouseNumberAsync(id,warehouseNumber ,search, SalesOrderLineOrderBy.CustomerNameDesc, page, pageSize);
                return result;
            case "customernameasc":
                if (includeWaiting)
                {
                    result = await _salesOrderLineService.GetWaitingSalesOrdersByCurrentIdAndWarehouseNumberAsync(id, warehouseNumber, search, SalesOrderLineOrderBy.CustomerNameAsc, page, pageSize);
                    return result;
                }
                result = await _salesOrderLineService.GetWaitingSalesOrdersByCurrentIdAndWarehouseNumberAsync(id, warehouseNumber, search, SalesOrderLineOrderBy.CustomerNameAsc, page, pageSize);
                return result;
            case "customercodedesc":
                if (includeWaiting)
                {
                    result = await _salesOrderLineService.GetWaitingSalesOrdersByCurrentIdAndWarehouseNumberAsync(id, warehouseNumber, search, SalesOrderLineOrderBy.CustomerCodeDesc, page, pageSize);
                    return result;
                }
                result = await _salesOrderLineService.GetWaitingSalesOrdersByCurrentIdAndWarehouseNumberAsync(id, warehouseNumber, search, SalesOrderLineOrderBy.CustomerCodeDesc, page, pageSize);
                return result;
            case "customercodeasc":
                if (includeWaiting)
                {
                    result = await _salesOrderLineService.GetWaitingSalesOrdersByCurrentIdAndWarehouseNumberAsync(id, warehouseNumber, search, SalesOrderLineOrderBy.CustomerCodeAsc, page, pageSize);
                    return result;
                }
                result = await _salesOrderLineService.GetWaitingSalesOrdersByCurrentIdAndWarehouseNumberAsync(id, warehouseNumber, search, SalesOrderLineOrderBy.CustomerCodeAsc, page, pageSize);
                return result;
            case "productnamedesc":
                if (includeWaiting)
                {
                    result = await _salesOrderLineService.GetWaitingSalesOrdersByCurrentIdAndWarehouseNumberAsync(id, warehouseNumber, search, SalesOrderLineOrderBy.ProductNameDesc, page, pageSize);
                    return result;
                }
                result = await _salesOrderLineService.GetWaitingSalesOrdersByCurrentIdAndWarehouseNumberAsync(id, warehouseNumber, search, SalesOrderLineOrderBy.ProductNameDesc, page, pageSize);
                return result;
            case "productnameasc":
                if (includeWaiting)
                {
                    result = await _salesOrderLineService.GetWaitingSalesOrdersByCurrentIdAndWarehouseNumberAsync(id, warehouseNumber, search, SalesOrderLineOrderBy.ProductNameAsc, page, pageSize);
                    return result;
                }
                result = await _salesOrderLineService.GetWaitingSalesOrdersByCurrentIdAndWarehouseNumberAsync(id, warehouseNumber, search, SalesOrderLineOrderBy.ProductNameAsc, page, pageSize);
                return result;
            case "productcodedesc":
                if (includeWaiting)
                {
                    result = await _salesOrderLineService.GetWaitingSalesOrdersByCurrentIdAndWarehouseNumberAsync(id, warehouseNumber, search, SalesOrderLineOrderBy.ProductCodeDesc, page, pageSize);
                    return result;
                }
                result = await _salesOrderLineService.GetWaitingSalesOrdersByCurrentIdAndWarehouseNumberAsync(id, warehouseNumber, search, SalesOrderLineOrderBy.ProductCodeDesc, page, pageSize);
                return result;
            case "productcodeasc":
                if (includeWaiting)
                {
                    result = await _salesOrderLineService.GetWaitingSalesOrdersByCurrentIdAndWarehouseNumberAsync(id, warehouseNumber, search, SalesOrderLineOrderBy.ProductCodeAsc, page, pageSize);
                    return result;
                }
                result = await _salesOrderLineService.GetWaitingSalesOrdersByCurrentIdAndWarehouseNumberAsync(id, warehouseNumber, search, SalesOrderLineOrderBy.ProductCodeAsc, page, pageSize);
                return result;
            case "duedateasc":
                if (includeWaiting)
                {
                    result = await _salesOrderLineService.GetWaitingSalesOrdersByCurrentIdAndWarehouseNumberAsync(id, warehouseNumber, search, SalesOrderLineOrderBy.DueDateAsc, page, pageSize);
                    return result;
                }
                result = await _salesOrderLineService.GetWaitingSalesOrdersByCurrentIdAndWarehouseNumberAsync(id, warehouseNumber, search, SalesOrderLineOrderBy.DueDateAsc, page, pageSize);
                return result;
            case "duedatedesc":
                if (includeWaiting)
                {
                    result = await _salesOrderLineService.GetWaitingSalesOrdersByCurrentIdAndWarehouseNumberAsync(id, warehouseNumber, search, SalesOrderLineOrderBy.DueDateDesc, page, pageSize);
                    return result;
                }
                result = await _salesOrderLineService.GetWaitingSalesOrdersByCurrentIdAndWarehouseNumberAsync(id, warehouseNumber, search, SalesOrderLineOrderBy.DueDateDesc, page, pageSize);
                return result;
            default:
                if (includeWaiting)
                {
                    result = await _salesOrderLineService.GetWaitingSalesOrdersByCurrentIdAndWarehouseNumberAsync(id, warehouseNumber, search, orderBy, page, pageSize);
                    return result;
                }
                result = await _salesOrderLineService.GetWaitingSalesOrdersByCurrentIdAndWarehouseNumberAsync(id,warehouseNumber, search, orderBy, page, pageSize);
                return result;

        }

    }
    
	[HttpGet("CurrentAndWarehouseAndShipInfo/Id/{id:int}&{includeWaiting}&{warehouseNumber:int}&{shipInfoReferenceId:int}")]
    public async Task<DataResult<IEnumerable<SalesOrderLine>>> GetByCurrentIdAndWarehouseNumberAndShipInfo(int id, int warehouseNumber,int shipInfoReferenceId, bool includeWaiting = false, [FromQuery] string search = "", string orderBy = SalesOrderLineOrderBy.DueDateAsc, int page = 0, int pageSize = 20)
    {
        DataResult<IEnumerable<SalesOrderLine>> result = new();
        switch (orderBy)
        {

            case "customernamedesc":
                if (includeWaiting)
                {
                    result = await _salesOrderLineService.GetWaitingSalesOrdersByCurrentIdAndWarehouseNumberAndShipInfoAsync(id, warehouseNumber, shipInfoReferenceId, search, SalesOrderLineOrderBy.CustomerNameDesc, page, pageSize);
                    return result;
                }
                result = await _salesOrderLineService.GetWaitingSalesOrdersByCurrentIdAndWarehouseNumberAndShipInfoAsync(id, warehouseNumber, shipInfoReferenceId, search, SalesOrderLineOrderBy.CustomerNameDesc, page, pageSize);
                return result;
            case "customernameasc":
                if (includeWaiting)
                {
                    result = await _salesOrderLineService.GetWaitingSalesOrdersByCurrentIdAndWarehouseNumberAndShipInfoAsync(id, warehouseNumber, shipInfoReferenceId, search, SalesOrderLineOrderBy.CustomerNameAsc, page, pageSize);
                    return result;
                }
                result = await _salesOrderLineService.GetWaitingSalesOrdersByCurrentIdAndWarehouseNumberAndShipInfoAsync(id, warehouseNumber, shipInfoReferenceId, search, SalesOrderLineOrderBy.CustomerNameAsc, page, pageSize);
                return result;
            case "customercodedesc":
                if (includeWaiting)
                {
                    result = await _salesOrderLineService.GetWaitingSalesOrdersByCurrentIdAndWarehouseNumberAndShipInfoAsync(id, warehouseNumber, shipInfoReferenceId, search, SalesOrderLineOrderBy.CustomerCodeDesc, page, pageSize);
                    return result;
                }
                result = await _salesOrderLineService.GetWaitingSalesOrdersByCurrentIdAndWarehouseNumberAndShipInfoAsync(id, warehouseNumber, shipInfoReferenceId, search, SalesOrderLineOrderBy.CustomerCodeDesc, page, pageSize);
                return result;
            case "customercodeasc":
                if (includeWaiting)
                {
                    result = await _salesOrderLineService.GetWaitingSalesOrdersByCurrentIdAndWarehouseNumberAndShipInfoAsync(id, warehouseNumber, shipInfoReferenceId, search, SalesOrderLineOrderBy.CustomerCodeAsc, page, pageSize);
                    return result;
                }
                result = await _salesOrderLineService.GetWaitingSalesOrdersByCurrentIdAndWarehouseNumberAndShipInfoAsync(id, warehouseNumber, shipInfoReferenceId, search, SalesOrderLineOrderBy.CustomerCodeAsc, page, pageSize);
                return result;
            case "productnamedesc":
                if (includeWaiting)
                {
                    result = await _salesOrderLineService.GetWaitingSalesOrdersByCurrentIdAndWarehouseNumberAndShipInfoAsync(id, warehouseNumber, shipInfoReferenceId, search, SalesOrderLineOrderBy.ProductNameDesc, page, pageSize);
                    return result;
                }
                result = await _salesOrderLineService.GetWaitingSalesOrdersByCurrentIdAndWarehouseNumberAndShipInfoAsync(id, warehouseNumber, shipInfoReferenceId, search, SalesOrderLineOrderBy.ProductNameDesc, page, pageSize);
                return result;
            case "productnameasc":
                if (includeWaiting)
                {
                    result = await _salesOrderLineService.GetWaitingSalesOrdersByCurrentIdAndWarehouseNumberAndShipInfoAsync(id, warehouseNumber, shipInfoReferenceId, search, SalesOrderLineOrderBy.ProductNameAsc, page, pageSize);
                    return result;
                }
                result = await _salesOrderLineService.GetWaitingSalesOrdersByCurrentIdAndWarehouseNumberAndShipInfoAsync(id, warehouseNumber, shipInfoReferenceId, search, SalesOrderLineOrderBy.ProductNameAsc, page, pageSize);
                return result;
            case "productcodedesc":
                if (includeWaiting)
                {
                    result = await _salesOrderLineService.GetWaitingSalesOrdersByCurrentIdAndWarehouseNumberAndShipInfoAsync(id, warehouseNumber, shipInfoReferenceId, search, SalesOrderLineOrderBy.ProductCodeDesc, page, pageSize);
                    return result;
                }
                result = await _salesOrderLineService.GetWaitingSalesOrdersByCurrentIdAndWarehouseNumberAndShipInfoAsync(id, warehouseNumber, shipInfoReferenceId, search, SalesOrderLineOrderBy.ProductCodeDesc, page, pageSize);
                return result;
            case "productcodeasc":
                if (includeWaiting)
                {
                    result = await _salesOrderLineService.GetWaitingSalesOrdersByCurrentIdAndWarehouseNumberAndShipInfoAsync(id, warehouseNumber, shipInfoReferenceId, search, SalesOrderLineOrderBy.ProductCodeAsc, page, pageSize);
                    return result;
                }
                result = await _salesOrderLineService.GetWaitingSalesOrdersByCurrentIdAndWarehouseNumberAndShipInfoAsync(id, warehouseNumber, shipInfoReferenceId, search, SalesOrderLineOrderBy.ProductCodeAsc, page, pageSize);
                return result;
            case "duedateasc":
                if (includeWaiting)
                {
                    result = await _salesOrderLineService.GetWaitingSalesOrdersByCurrentIdAndWarehouseNumberAndShipInfoAsync(id, warehouseNumber, shipInfoReferenceId, search, SalesOrderLineOrderBy.DueDateAsc, page, pageSize);
                    return result;
                }
                result = await _salesOrderLineService.GetWaitingSalesOrdersByCurrentIdAndWarehouseNumberAndShipInfoAsync(id, warehouseNumber, shipInfoReferenceId, search, SalesOrderLineOrderBy.DueDateAsc, page, pageSize);
                return result;
            case "duedatedesc":
                if (includeWaiting)
                {
                    result = await _salesOrderLineService.GetWaitingSalesOrdersByCurrentIdAndWarehouseNumberAndShipInfoAsync(id, warehouseNumber, shipInfoReferenceId, search, SalesOrderLineOrderBy.DueDateDesc, page, pageSize);
                    return result;
                }
                result = await _salesOrderLineService.GetWaitingSalesOrdersByCurrentIdAndWarehouseNumberAndShipInfoAsync(id, warehouseNumber, shipInfoReferenceId, search, SalesOrderLineOrderBy.DueDateDesc, page, pageSize);
                return result;
            default:
                if (includeWaiting)
                {
                    result = await _salesOrderLineService.GetWaitingSalesOrdersByCurrentIdAndWarehouseNumberAndShipInfoAsync(id, warehouseNumber, shipInfoReferenceId, search, orderBy, page, pageSize);
                    return result;
                }
                result = await _salesOrderLineService.GetWaitingSalesOrdersByCurrentIdAndWarehouseNumberAndShipInfoAsync(id, warehouseNumber, shipInfoReferenceId, search, orderBy, page, pageSize);
                return result;

        }

    }


    [HttpGet("Current/Code/{code}&{includeWaiting}")]
	public async Task<DataResult<IEnumerable<SalesOrderLine>>> GetByCurrentCode(string code, bool includeWaiting = false, [FromQuery] string search = "", string orderBy = SalesOrderLineOrderBy.DueDateAsc, int page = 0, int pageSize = 20)
	{
		DataResult<IEnumerable<SalesOrderLine>> result = new();
		switch (orderBy)
		{

			case "customernamedesc":
				if (includeWaiting)
				{
					result = await _salesOrderLineService.GetWaitingSalesOrdersByCurrentCodeAsync(code, search, SalesOrderLineOrderBy.CustomerNameDesc, page, pageSize);
					return result;
				}
				result = await _salesOrderLineService.GetSalesOrdersByCurrentCodeAsync(code, search, SalesOrderLineOrderBy.CustomerNameDesc, page, pageSize);
				return result;
			case "customernameasc":
				if (includeWaiting)
				{
					result = await _salesOrderLineService.GetWaitingSalesOrdersByCurrentCodeAsync(code, search, SalesOrderLineOrderBy.CustomerNameAsc, page, pageSize);
					return result;
				}
				result = await _salesOrderLineService.GetSalesOrdersByCurrentCodeAsync(code, search, SalesOrderLineOrderBy.CustomerNameAsc, page, pageSize);
				return result;
			case "customercodedesc":
				if (includeWaiting)
				{
					result = await _salesOrderLineService.GetWaitingSalesOrdersByCurrentCodeAsync(code, search, SalesOrderLineOrderBy.CustomerCodeDesc, page, pageSize);
					return result;
				}
				result = await _salesOrderLineService.GetSalesOrdersByCurrentCodeAsync(code, search, SalesOrderLineOrderBy.CustomerCodeDesc, page, pageSize);
				return result;
			case "customercodeasc":
				if (includeWaiting)
				{
					result = await _salesOrderLineService.GetWaitingSalesOrdersByCurrentCodeAsync(code, search, SalesOrderLineOrderBy.CustomerCodeAsc, page, pageSize);
					return result;
				}
				result = await _salesOrderLineService.GetSalesOrdersByCurrentCodeAsync(code, search, SalesOrderLineOrderBy.CustomerCodeAsc, page, pageSize);
				return result;
			case "productnamedesc":
				if (includeWaiting)
				{
					result = await _salesOrderLineService.GetWaitingSalesOrdersByCurrentCodeAsync(code, search, SalesOrderLineOrderBy.ProductNameDesc, page, pageSize);
					return result;
				}
				result = await _salesOrderLineService.GetSalesOrdersByCurrentCodeAsync(code, search, SalesOrderLineOrderBy.ProductNameDesc, page, pageSize);
				return result;
			case "productnameasc":
				if (includeWaiting)
				{
					result = await _salesOrderLineService.GetWaitingSalesOrdersByCurrentCodeAsync(code, search, SalesOrderLineOrderBy.ProductNameAsc, page, pageSize);
					return result;
				}
				result = await _salesOrderLineService.GetSalesOrdersByCurrentCodeAsync(code, search, SalesOrderLineOrderBy.ProductNameAsc, page, pageSize);
				return result;
			case "productcodedesc":
				if (includeWaiting)
				{
					result = await _salesOrderLineService.GetWaitingSalesOrdersByCurrentCodeAsync(code, search, SalesOrderLineOrderBy.ProductCodeDesc, page, pageSize);
					return result;
				}
				result = await _salesOrderLineService.GetSalesOrdersByCurrentCodeAsync(code, search, SalesOrderLineOrderBy.ProductCodeDesc, page, pageSize);
				return result;
			case "productcodeasc":
				if (includeWaiting)
				{
					result = await _salesOrderLineService.GetWaitingSalesOrdersByCurrentCodeAsync(code, search, SalesOrderLineOrderBy.ProductCodeAsc, page, pageSize);
					return result;
				}
				result = await _salesOrderLineService.GetSalesOrdersByCurrentCodeAsync(code, search, SalesOrderLineOrderBy.ProductCodeAsc, page, pageSize);
				return result;
			case "duedateasc":
				if (includeWaiting)
				{
					result = await _salesOrderLineService.GetWaitingSalesOrdersByCurrentCodeAsync(code, search, SalesOrderLineOrderBy.DueDateAsc, page, pageSize);
					return result;
				}
				result = await _salesOrderLineService.GetSalesOrdersByCurrentCodeAsync(code, search, SalesOrderLineOrderBy.DueDateAsc, page, pageSize);
				return result;
			case "duedatedesc":
				if (includeWaiting)
				{
					result = await _salesOrderLineService.GetWaitingSalesOrdersByCurrentCodeAsync(code, search, SalesOrderLineOrderBy.DueDateDesc, page, pageSize);
					return result;
				}
				result = await _salesOrderLineService.GetSalesOrdersByCurrentCodeAsync(code, search, SalesOrderLineOrderBy.DueDateDesc, page, pageSize);
				return result;
			default:
				if (includeWaiting)
				{
					result = await _salesOrderLineService.GetWaitingSalesOrdersByCurrentCodeAsync(code, search, orderBy, page, pageSize);
					return result;
				}
				result = await _salesOrderLineService.GetSalesOrdersByCurrentCodeAsync(code, search, orderBy, page, pageSize);
				return result;

		}

	}

	[HttpGet("Product/Id/{id}&{includeWaiting}")]
	public async Task<DataResult<IEnumerable<SalesOrderLine>>> GetByProductId(int id, bool includeWaiting = false, [FromQuery] string search = "", string orderBy = SalesOrderLineOrderBy.DueDateAsc, int page = 0, int pageSize = 20)
	{
		DataResult<IEnumerable<SalesOrderLine>> result = new();
		switch (orderBy)
		{

			case "customernamedesc":
				if (includeWaiting)
				{
					result = await _salesOrderLineService.GetWaitingSalesOrdersByProductIdAsync(id, search, SalesOrderLineOrderBy.CustomerNameDesc, page, pageSize);
					return result;
				}
				result = await _salesOrderLineService.GetSalesOrdersByProductIdAsync(id, search, SalesOrderLineOrderBy.CustomerNameDesc, page, pageSize);
				return result;
			case "customernameasc":
				if (includeWaiting)
				{
					result = await _salesOrderLineService.GetWaitingSalesOrdersByProductIdAsync(id, search, SalesOrderLineOrderBy.CustomerNameAsc, page, pageSize);
					return result;
				}
				result = await _salesOrderLineService.GetSalesOrdersByProductIdAsync(id, search, SalesOrderLineOrderBy.CustomerNameAsc, page, pageSize);
				return result;
			case "customercodedesc":
				if (includeWaiting)
				{
					result = await _salesOrderLineService.GetWaitingSalesOrdersByProductIdAsync(id, search, SalesOrderLineOrderBy.CustomerCodeDesc, page, pageSize);
					return result;
				}
				result = await _salesOrderLineService.GetSalesOrdersByProductIdAsync(id, search, SalesOrderLineOrderBy.CustomerCodeDesc, page, pageSize);
				return result;
			case "customercodeasc":
				if (includeWaiting)
				{
					result = await _salesOrderLineService.GetWaitingSalesOrdersByProductIdAsync(id, search, SalesOrderLineOrderBy.CustomerCodeAsc, page, pageSize);
					return result;
				}
				result = await _salesOrderLineService.GetSalesOrdersByProductIdAsync(id, search, SalesOrderLineOrderBy.CustomerCodeAsc, page, pageSize);
				return result;
			case "productnamedesc":
				if (includeWaiting)
				{
					result = await _salesOrderLineService.GetWaitingSalesOrdersByProductIdAsync(id, search, SalesOrderLineOrderBy.ProductNameDesc, page, pageSize);
					return result;
				}
				result = await _salesOrderLineService.GetSalesOrdersByProductIdAsync(id, search, SalesOrderLineOrderBy.ProductNameDesc, page, pageSize);
				return result;
			case "productnameasc":
				if (includeWaiting)
				{
					result = await _salesOrderLineService.GetWaitingSalesOrdersByProductIdAsync(id, search, SalesOrderLineOrderBy.ProductNameAsc, page, pageSize);
					return result;
				}
				result = await _salesOrderLineService.GetSalesOrdersByProductIdAsync(id, search, SalesOrderLineOrderBy.ProductNameAsc, page, pageSize);
				return result;
			case "productcodedesc":
				if (includeWaiting)
				{
					result = await _salesOrderLineService.GetWaitingSalesOrdersByProductIdAsync(id, search, SalesOrderLineOrderBy.ProductCodeDesc, page, pageSize);
					return result;
				}
				result = await _salesOrderLineService.GetSalesOrdersByProductIdAsync(id, search, SalesOrderLineOrderBy.ProductCodeDesc, page, pageSize);
				return result;
			case "productcodeasc":
				if (includeWaiting)
				{
					result = await _salesOrderLineService.GetWaitingSalesOrdersByProductIdAsync(id, search, SalesOrderLineOrderBy.ProductCodeAsc, page, pageSize);
					return result;
				}
				result = await _salesOrderLineService.GetSalesOrdersByProductIdAsync(id, search, SalesOrderLineOrderBy.ProductCodeAsc, page, pageSize);
				return result;
			case "duedateasc":
				if (includeWaiting)
				{
					result = await _salesOrderLineService.GetWaitingSalesOrdersByProductIdAsync(id, search, SalesOrderLineOrderBy.DueDateAsc, page, pageSize);
					return result;
				}
				result = await _salesOrderLineService.GetSalesOrdersByProductIdAsync(id, search, SalesOrderLineOrderBy.DueDateAsc, page, pageSize);
				return result;
			case "duedatedesc":
				if (includeWaiting)
				{
					result = await _salesOrderLineService.GetWaitingSalesOrdersByProductIdAsync(id, search, SalesOrderLineOrderBy.DueDateDesc, page, pageSize);
					return result;
				}
				result = await _salesOrderLineService.GetSalesOrdersByProductIdAsync(id, search, SalesOrderLineOrderBy.DueDateDesc, page, pageSize);
				return result;
			default:
				if (includeWaiting)
				{
					result = await _salesOrderLineService.GetWaitingSalesOrdersByProductIdAsync(id, search, orderBy, page, pageSize);
					return result;
				}
				result = await _salesOrderLineService.GetSalesOrdersByProductIdAsync(id, search, orderBy, page, pageSize);
				return result;

		}

	}

	[HttpGet("Product/Code/{code}&{includeWaiting}")]
	public async Task<DataResult<IEnumerable<SalesOrderLine>>> GetByProductCode(string code, bool includeWaiting = false, [FromQuery] string search = "", string orderBy = SalesOrderLineOrderBy.DueDateAsc, int page = 0, int pageSize = 20)
	{
		DataResult<IEnumerable<SalesOrderLine>> result = new();
		switch (orderBy)
		{

			case "customernamedesc":
				if (includeWaiting)
				{
					result = await _salesOrderLineService.GetWaitingSalesOrdersByProductCodeAsync(code, search, SalesOrderLineOrderBy.CustomerNameDesc, page, pageSize);
					return result;
				}
				result = await _salesOrderLineService.GetSalesOrdersByProductCodeAsync(code, search, SalesOrderLineOrderBy.CustomerNameDesc, page, pageSize);
				return result;
			case "customernameasc":
				if (includeWaiting)
				{
					result = await _salesOrderLineService.GetWaitingSalesOrdersByProductCodeAsync(code, search, SalesOrderLineOrderBy.CustomerNameAsc, page, pageSize);
					return result;
				}
				result = await _salesOrderLineService.GetSalesOrdersByProductCodeAsync(code, search, SalesOrderLineOrderBy.CustomerNameAsc, page, pageSize);
				return result;
			case "customercodedesc":
				if (includeWaiting)
				{
					result = await _salesOrderLineService.GetWaitingSalesOrdersByProductCodeAsync(code, search, SalesOrderLineOrderBy.CustomerCodeDesc, page, pageSize);
					return result;
				}
				result = await _salesOrderLineService.GetSalesOrdersByProductCodeAsync(code, search, SalesOrderLineOrderBy.CustomerCodeDesc, page, pageSize);
				return result;
			case "customercodeasc":
				if (includeWaiting)
				{
					result = await _salesOrderLineService.GetWaitingSalesOrdersByProductCodeAsync(code, search, SalesOrderLineOrderBy.CustomerCodeAsc, page, pageSize);
					return result;
				}
				result = await _salesOrderLineService.GetSalesOrdersByProductCodeAsync(code, search, SalesOrderLineOrderBy.CustomerCodeAsc, page, pageSize);
				return result;
			case "productnamedesc":
				if (includeWaiting)
				{
					result = await _salesOrderLineService.GetWaitingSalesOrdersByProductCodeAsync(code, search, SalesOrderLineOrderBy.ProductNameDesc, page, pageSize);
					return result;
				}
				result = await _salesOrderLineService.GetSalesOrdersByProductCodeAsync(code, search, SalesOrderLineOrderBy.ProductNameDesc, page, pageSize);
				return result;
			case "productnameasc":
				if (includeWaiting)
				{
					result = await _salesOrderLineService.GetWaitingSalesOrdersByProductCodeAsync(code, search, SalesOrderLineOrderBy.ProductNameAsc, page, pageSize);
					return result;
				}
				result = await _salesOrderLineService.GetSalesOrdersByProductCodeAsync(code, search, SalesOrderLineOrderBy.ProductNameAsc, page, pageSize);
				return result;
			case "productcodedesc":
				if (includeWaiting)
				{
					result = await _salesOrderLineService.GetWaitingSalesOrdersByProductCodeAsync(code, search, SalesOrderLineOrderBy.ProductCodeDesc, page, pageSize);
					return result;
				}
				result = await _salesOrderLineService.GetSalesOrdersByProductCodeAsync(code, search, SalesOrderLineOrderBy.ProductCodeDesc, page, pageSize);
				return result;
			case "productcodeasc":
				if (includeWaiting)
				{
					result = await _salesOrderLineService.GetWaitingSalesOrdersByProductCodeAsync(code, search, SalesOrderLineOrderBy.ProductCodeAsc, page, pageSize);
					return result;
				}
				result = await _salesOrderLineService.GetSalesOrdersByProductCodeAsync(code, search, SalesOrderLineOrderBy.ProductCodeAsc, page, pageSize);
				return result;
			case "duedateasc":
				if (includeWaiting)
				{
					result = await _salesOrderLineService.GetWaitingSalesOrdersByProductCodeAsync(code, search, SalesOrderLineOrderBy.DueDateAsc, page, pageSize);
					return result;
				}
				result = await _salesOrderLineService.GetSalesOrdersByProductCodeAsync(code, search, SalesOrderLineOrderBy.DueDateAsc, page, pageSize);
				return result;
			case "duedatedesc":
				if (includeWaiting)
				{
					result = await _salesOrderLineService.GetWaitingSalesOrdersByProductCodeAsync(code, search, SalesOrderLineOrderBy.DueDateDesc, page, pageSize);
					return result;
				}
				result = await _salesOrderLineService.GetSalesOrdersByProductCodeAsync(code, search, SalesOrderLineOrderBy.DueDateDesc, page, pageSize);
				return result;
			default:
				if (includeWaiting)
				{
					result = await _salesOrderLineService.GetWaitingSalesOrdersByProductCodeAsync(code, search, orderBy, page, pageSize);
					return result;
				}
				result = await _salesOrderLineService.GetSalesOrdersByProductCodeAsync(code, search, orderBy, page, pageSize);
				return result;

		}

	}
}
