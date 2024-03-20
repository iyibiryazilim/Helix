using Helix.EventBus.Base.Abstractions;
using Helix.PurchaseService.Application.Services;
using Helix.PurchaseService.Domain.AggregateModelss;
using Helix.PurchaseService.Domain.Dtos;
using Helix.PurchaseService.Domain.Events;
using Helix.PurchaseService.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Helix.PurchaseService.Infrastructure.Helper.Queries.PurchaseOrderQuery;
namespace Helix.PurchaseService.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class PurchaseOrderController : ControllerBase
	{
		IConfiguration _configuration;
		IPurchaseOrderService _purchaseOrderService;
		IEventBus _eventBus;
		public PurchaseOrderController(IConfiguration configuration, IPurchaseOrderService purchaseOrderService, IEventBus eventBus)
		{
			_configuration = configuration;
			_purchaseOrderService = purchaseOrderService;
			_eventBus = eventBus;
		}

		[HttpGet]
		public async Task<DataResult<IEnumerable<PurchaseOrder>>> GetAll([FromQuery] string search = "", string orderBy = "datedesc", int page = 0, int pageSize = 20)
		{
			var result = new DataResult<IEnumerable<PurchaseOrder>>();
			switch (orderBy)
			{
				case "currentcodedesc":
					result = await _purchaseOrderService.GetPurchaseOrderList(search, PurchaseOrdersOrderBy.CurrentCodeDesc, page, pageSize);
					return result;
				case "currentcodeasc":
					result = await _purchaseOrderService.GetPurchaseOrderList(search, PurchaseOrdersOrderBy.CurrentCodeAsc, page, pageSize);
					return result;
				case "currentnamedesc":
					result = await _purchaseOrderService.GetPurchaseOrderList(search, PurchaseOrdersOrderBy.CurrentNameDesc, page, pageSize);
					return result;
				case "currentnameasc":
					result = await _purchaseOrderService.GetPurchaseOrderList(search, PurchaseOrdersOrderBy.CurrentNameAsc, page, pageSize);
					return result;
				case "dateasc":
					result = await _purchaseOrderService.GetPurchaseOrderList(search, PurchaseOrdersOrderBy.DateAsc, page, pageSize);
					return result;
				case "datedesc":
					result = await _purchaseOrderService.GetPurchaseOrderList(search, PurchaseOrdersOrderBy.DateDesc, page, pageSize);
					return result;
				case "nettotalasc":
					result = await _purchaseOrderService.GetPurchaseOrderList(search, PurchaseOrdersOrderBy.NetTotalDesc, page, pageSize);
					return result;
				case "nettotaldesc":
					result = await _purchaseOrderService.GetPurchaseOrderList(search, PurchaseOrdersOrderBy.NetTotalAsc, page, pageSize);
					return result;
				default:
                    result = await _purchaseOrderService.GetPurchaseOrderList(search, PurchaseOrdersOrderBy.DateDesc, page, pageSize);
                    return result;
            }

		}
		[HttpGet("Code/{code}")]
		public async Task<DataResult<PurchaseOrder>> GetByCode(string code)
		{
			var result = await _purchaseOrderService.GetPurchaseOrderByCode(code);
			return result;
		}
		[HttpGet("Id/{id:int}")]
		public async Task<DataResult<PurchaseOrder>> GetById(int id)
		{
			var result = await _purchaseOrderService.GetPurchaseOrderById(id);
			return result;
		}

		[HttpGet("Current/Id/{id:int}")]
		public async Task<DataResult<IEnumerable<PurchaseOrder>>> GetByCurrentId(int id, [FromQuery] string search = "", string orderBy = "datedesc", int page = 0, int pageSize = 20)
		{
			var result = new DataResult<IEnumerable<PurchaseOrder>>();
			switch (orderBy)
			{
				case "currentcodedesc":
					result = await _purchaseOrderService.GetPurchaseOrderByCurrentId(search, PurchaseOrdersOrderBy.CurrentCodeDesc, id, page, pageSize);
					return result;
				case "currentcodeasc":
					result = await _purchaseOrderService.GetPurchaseOrderByCurrentId(search, PurchaseOrdersOrderBy.CurrentCodeAsc, id, page, pageSize);
					return result;
				case "currentnamedesc":
					result = await _purchaseOrderService.GetPurchaseOrderByCurrentId(search, PurchaseOrdersOrderBy.CurrentNameDesc, id, page, pageSize);
					return result;
				case "currentnameasc":
					result = await _purchaseOrderService.GetPurchaseOrderByCurrentId(search, PurchaseOrdersOrderBy.CurrentNameAsc, id, page, pageSize);
					return result;
				case "dateasc":
					result = await _purchaseOrderService.GetPurchaseOrderByCurrentId(search, PurchaseOrdersOrderBy.DateAsc, id, page, pageSize);
					return result;
				case "datedesc":
					result = await _purchaseOrderService.GetPurchaseOrderByCurrentId(search, PurchaseOrdersOrderBy.DateDesc, id, page, pageSize);
					return result;
				case "nettotalasc":
					result = await _purchaseOrderService.GetPurchaseOrderByCurrentId(search, PurchaseOrdersOrderBy.NetTotalDesc, id, page, pageSize);
					return result;
				case "nettotaldesc":
					result = await _purchaseOrderService.GetPurchaseOrderByCurrentId(search, PurchaseOrdersOrderBy.NetTotalAsc, id, page, pageSize);
					return result;
				default:
					result.Message = "OrderBy wrong text";
					return result;
			}

		}


        [HttpGet("CurrentAndWarehouse/Id/{id:int}&{number:int}")]
        public async Task<DataResult<IEnumerable<PurchaseOrder>>> GetByCurrentIdAndWarehouseNumber(int id,int number, [FromQuery] string search = "", string orderBy = "datedesc", int page = 0, int pageSize = 20)
        {
            var result = new DataResult<IEnumerable<PurchaseOrder>>();
            switch (orderBy)
            {
                case "currentcodedesc":
                    result = await _purchaseOrderService.GetPurchaseOrderByCurrentIdAndWarehouseNumber(search, PurchaseOrdersOrderBy.CurrentCodeDesc, id, number, page, pageSize);
                    return result;
                case "currentcodeasc":
                    result = await _purchaseOrderService.GetPurchaseOrderByCurrentIdAndWarehouseNumber(search, PurchaseOrdersOrderBy.CurrentCodeAsc, id, number, page, pageSize);
                    return result;
                case "currentnamedesc":
                    result = await _purchaseOrderService.GetPurchaseOrderByCurrentIdAndWarehouseNumber(search, PurchaseOrdersOrderBy.CurrentNameDesc, id, number, page, pageSize);
                    return result;
                case "currentnameasc":
                    result = await _purchaseOrderService.GetPurchaseOrderByCurrentIdAndWarehouseNumber(search, PurchaseOrdersOrderBy.CurrentNameAsc, id, number, page, pageSize);
                    return result;
                case "dateasc":
                    result = await _purchaseOrderService.GetPurchaseOrderByCurrentIdAndWarehouseNumber(search, PurchaseOrdersOrderBy.DateAsc, id, number, page, pageSize);
                    return result;
                case "datedesc":
                    result = await _purchaseOrderService.GetPurchaseOrderByCurrentIdAndWarehouseNumber(search, PurchaseOrdersOrderBy.DateDesc, id, number, page, pageSize);
                    return result;
                case "nettotalasc":
                    result = await _purchaseOrderService.GetPurchaseOrderByCurrentIdAndWarehouseNumber(search, PurchaseOrdersOrderBy.NetTotalDesc, id, number, page, pageSize);
                    return result;
                case "nettotaldesc":
                    result = await _purchaseOrderService.GetPurchaseOrderByCurrentIdAndWarehouseNumber(search, PurchaseOrdersOrderBy.NetTotalAsc, id, number,page, pageSize);
                    return result;
                default:
                    result.Message = "OrderBy wrong text";
                    return result;
            }

        }

        [HttpGet("Current/Code/{code}")]
		public async Task<DataResult<IEnumerable<PurchaseOrder>>> GetByCurrentCode(string code, [FromQuery] string search = "", string orderBy = "datedesc", int page = 0, int pageSize = 20)
		{
			var result = new DataResult<IEnumerable<PurchaseOrder>>();
			switch (orderBy)
			{
				case "currentcodedesc":
					result = await _purchaseOrderService.GetPurchaseOrderByCurrentCode(search, PurchaseOrdersOrderBy.CurrentCodeDesc, code, page, pageSize);
					return result;
				case "currentcodeasc":
					result = await _purchaseOrderService.GetPurchaseOrderByCurrentCode(search, PurchaseOrdersOrderBy.CurrentCodeAsc, code, page, pageSize);
					return result;
				case "currentnamedesc":
					result = await _purchaseOrderService.GetPurchaseOrderByCurrentCode(search, PurchaseOrdersOrderBy.CurrentNameDesc, code, page, pageSize);
					return result;
				case "currentnameasc":
					result = await _purchaseOrderService.GetPurchaseOrderByCurrentCode(search, PurchaseOrdersOrderBy.CurrentNameAsc, code, page, pageSize);
					return result;
				case "dateasc":
					result = await _purchaseOrderService.GetPurchaseOrderByCurrentCode(search, PurchaseOrdersOrderBy.DateAsc, code, page, pageSize);
					return result;
				case "datedesc":
					result = await _purchaseOrderService.GetPurchaseOrderByCurrentCode(search, PurchaseOrdersOrderBy.DateDesc, code, page, pageSize);
					return result;
				case "nettotalasc":
					result = await _purchaseOrderService.GetPurchaseOrderByCurrentCode(search, PurchaseOrdersOrderBy.NetTotalDesc, code, page, pageSize);
					return result;
				case "nettotaldesc":
					result = await _purchaseOrderService.GetPurchaseOrderByCurrentCode(search, PurchaseOrdersOrderBy.NetTotalAsc, code, page, pageSize);
					return result;
				default:
					result.Message = "OrderBy wrong text";
					return result;
			}
		}

		[HttpPost]
		public async Task PurchaseOrderInsert([FromBody] PurchaseOrderDto purchaseOrderDto)
		{
			_eventBus.Publish(new PurchaseOrderInsertingIntegrationEvent(purchaseOrderDto.employeeOid, purchaseOrderDto.referenceId, purchaseOrderDto.code, purchaseOrderDto.salesmanCode, purchaseOrderDto.orderDate, purchaseOrderDto.description, (short?)purchaseOrderDto.warehouseNumber, purchaseOrderDto.currentCode, purchaseOrderDto.shipmentAccountCode, purchaseOrderDto.projectCode, purchaseOrderDto.lines));
		}
	}
}
