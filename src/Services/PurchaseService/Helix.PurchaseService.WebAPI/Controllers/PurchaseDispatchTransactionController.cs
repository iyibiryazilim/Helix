using Consul;
using Helix.EventBus.Base.Abstractions;
using Helix.PurchaseService.Application.Services;
using Helix.PurchaseService.Domain.AggregateModelss;
using Helix.PurchaseService.Domain.Dtos;
using Helix.PurchaseService.Domain.Events;
using Helix.PurchaseService.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Helix.PurchaseService.Infrastructure.Helper.Queries.PurchaseDispatchTransactionQuery;

namespace Helix.PurchaseService.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class PurchaseDispatchTransactionController : ControllerBase
	{
		private readonly ILogger<PurchaseDispatchTransactionController> _logger;
		IConfiguration _configuration;
		IEventBus _eventBus;
		IPurchaseDispatchTransactionService _purchaseDispatchTransactionService;
		public PurchaseDispatchTransactionController(IConfiguration configuration, IPurchaseDispatchTransactionService purchaseDispatchTransactionService, ILogger<PurchaseDispatchTransactionController> logger,IEventBus eventBus)
		{
			_configuration = configuration;
			_purchaseDispatchTransactionService = purchaseDispatchTransactionService;
			_logger = logger;
			_eventBus = eventBus;
		}
		 
		[HttpGet]
		public async Task<DataResult<IEnumerable<PurchaseDispatchTransaction>>> GetAll([FromQuery]string search = "", string orderBy = PurchaseDispatchTransactionOrderBy.DateDesc, int page = 0, int pageSize = 20)
		{
			var result = new DataResult<IEnumerable<PurchaseDispatchTransaction>>();
			switch (orderBy)
			{
				case "codedesc":
					result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionList(search, PurchaseDispatchTransactionOrderBy.CodeDesc , page, pageSize);
					return result;
				case "codeasc":
					result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionList(search, PurchaseDispatchTransactionOrderBy.CodeAsc , page, pageSize);
					return result;
				case "dateasc":
					result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionList(search, PurchaseDispatchTransactionOrderBy.DateAsc, page, pageSize);
					return result;
				case "datedesc":
					result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionList(search, PurchaseDispatchTransactionOrderBy.DateDesc, page, pageSize);
					return result;
				default:
                    result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionList(search, PurchaseDispatchTransactionOrderBy.DateDesc, page, pageSize);
                    return result;
			}
			 
		}

		[HttpGet("Id/{id:int}")]
		public async Task<DataResult<PurchaseDispatchTransaction>> GetById(int id)
		{
			var result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionById(id);
			return result;
		}

		[HttpGet("Code/{code}")]
		public async Task<DataResult<PurchaseDispatchTransaction>> GetByCode(string code)
		{
			var result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionByCode(code);
			return result;
		}

		[HttpGet("Current/Id/{id:int}")]
		public async Task<DataResult<IEnumerable<PurchaseDispatchTransaction>>> GetByCurrentId(int id, [FromQuery] string search = "", string orderBy = PurchaseDispatchTransactionOrderBy.DateDesc, int page = 0, int pageSize = 20)
		{
			var result = new DataResult<IEnumerable<PurchaseDispatchTransaction>>();
			switch (orderBy)
			{
				case "codedesc":
					result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionByCurrentId(search, PurchaseDispatchTransactionOrderBy.CodeDesc, id, page, pageSize);
					return result;
				case "codeasc":
					result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionByCurrentId(search, PurchaseDispatchTransactionOrderBy.CodeAsc, id, page, pageSize);
					return result;
				case "dateasc":
					result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionByCurrentId(search, PurchaseDispatchTransactionOrderBy.DateAsc, id, page, pageSize);
					return result;
				case "datedesc":
					result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionByCurrentId(search, PurchaseDispatchTransactionOrderBy.DateDesc, id, page, pageSize);
					return result;
				default:
                    result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionByCurrentId(search, PurchaseDispatchTransactionOrderBy.DateDesc, id, page, pageSize);
                    return result;
			}
		 
		}

		[HttpGet("Current/Code/{code}")]
		public async Task<DataResult<IEnumerable<PurchaseDispatchTransaction>>> GetByCurrentCode(string code, [FromQuery] string search = "", string orderBy = PurchaseDispatchTransactionOrderBy.DateDesc , int page = 0, int pageSize = 20)
		{
			var result = new DataResult<IEnumerable<PurchaseDispatchTransaction>>();
			switch (orderBy)
			{ 
				case "codedesc":
					result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionByCurrentCode(search, PurchaseDispatchTransactionOrderBy.CodeDesc, code, page, pageSize);
					return result;
				case "codeasc":
					result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionByCurrentCode(search, PurchaseDispatchTransactionOrderBy.CodeAsc, code,page, pageSize);
					return result;
				case "dateasc":
					result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionByCurrentCode(search, PurchaseDispatchTransactionOrderBy.DateAsc, code ,page, pageSize);
					return result;
				case "datedesc":
					result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionByCurrentCode(search, PurchaseDispatchTransactionOrderBy.DateDesc, code, page, pageSize);
					return result;
				default:
                    result = await _purchaseDispatchTransactionService.GetPurchaseDispatchTransactionByCurrentCode(search, PurchaseDispatchTransactionOrderBy.DateDesc, code, page, pageSize);
                    return result;
            } 
		}

        [HttpPost]
        public async Task PurchaseDispatchTransactionInsert([FromBody] PurchaseDispatchTransactionDto purchaseDispatchTransactionDto)
        {
            _eventBus.Publish(new PurchaseDispatchTransactionInsertedIntegrationEvent(purchaseDispatchTransactionDto.referenceId, purchaseDispatchTransactionDto.transactionDate, purchaseDispatchTransactionDto.groupType, purchaseDispatchTransactionDto.iOType, purchaseDispatchTransactionDto.transactionType, purchaseDispatchTransactionDto.warehouseNumber, purchaseDispatchTransactionDto.currentReferenceId, purchaseDispatchTransactionDto.currentCode, purchaseDispatchTransactionDto.total, purchaseDispatchTransactionDto.totalVat, purchaseDispatchTransactionDto.netTotal, purchaseDispatchTransactionDto.description, purchaseDispatchTransactionDto.dispatchType, purchaseDispatchTransactionDto.speCode, purchaseDispatchTransactionDto.dispatchStatus, purchaseDispatchTransactionDto.isEDispatch, purchaseDispatchTransactionDto.doCode, purchaseDispatchTransactionDto.docTrackingNumber, purchaseDispatchTransactionDto.isEInvoice, purchaseDispatchTransactionDto.eDispatchProfileId, purchaseDispatchTransactionDto.eInvoiceProfileId,purchaseDispatchTransactionDto.employeeOid, purchaseDispatchTransactionDto.lines));

        }
    }
}
