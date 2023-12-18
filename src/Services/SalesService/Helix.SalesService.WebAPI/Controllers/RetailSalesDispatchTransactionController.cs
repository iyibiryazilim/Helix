using Helix.EventBus.Base.Abstractions;
using Helix.SalesService.Application.Repository;
using Helix.SalesService.Domain.AggregateModels;
using Helix.SalesService.Domain.Dtos;
using Helix.SalesService.Domain.Events;
using Helix.SalesService.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Helix.SalesService.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RetailSalesDispatchTransactionController : ControllerBase
	{
		IRetailSalesDispatchTransactionService _retailSalesDispatchTransactionService;
		IEventBus _eventBus;
        public RetailSalesDispatchTransactionController(IRetailSalesDispatchTransactionService retailSalesDispatchTransactionService,IEventBus eventBus)
        {
            _retailSalesDispatchTransactionService = retailSalesDispatchTransactionService;
			_eventBus = eventBus;
        }

		[HttpGet]
		public async Task<DataResult<IEnumerable<RetailSalesDispatchTransaction>>> GetAll()
		{
			var result = await _retailSalesDispatchTransactionService.GetRetailSalesDispatchTransactionsAsync();
			return result;
		}

		[HttpGet("Id/{id:int}")]
		public async Task<DataResult<RetailSalesDispatchTransaction>> GetById(int id)
		{
			var result = await _retailSalesDispatchTransactionService.GetRetailSalesDispatchTransactionByIdAsync(id);
			return result;
		}

		[HttpGet("Code/{code}")]
		public async Task<DataResult<RetailSalesDispatchTransaction>> GetByCode(string code)
		{
			var result = await _retailSalesDispatchTransactionService.GetRetailSalesDispatchTransactionByCode(code);
			return result;
		}

		[HttpGet("Current/Id/{id:int}")]
		public async Task<DataResult<IEnumerable<RetailSalesDispatchTransaction>>> GetByCurrentId(int id)
		{
			var result = await _retailSalesDispatchTransactionService.GetRetailSalesDispatchTransactionsByCurrentIdAsync(id);
			return result;
		}

		[HttpGet("Current/Code/{code}")]
		public async Task<DataResult<IEnumerable<RetailSalesDispatchTransaction>>> GetByCurrentCode(string code)
		{
			var result = await _retailSalesDispatchTransactionService.GetRetailSalesDispatchTransactionsByCurrentCodeAsync(code);
			return result;
		}

		[HttpPost]
		public async Task RetailSalesDispatchTransactionInsert([FromBody] RetailSalesDispatchTransactionDto retailSalesDispatchTransactionDto)
		{
			_eventBus.Publish(new RetailSalesDispatchTransactionInsertingIntegrationEvent(retailSalesDispatchTransactionDto.referenceId, retailSalesDispatchTransactionDto.transactionDate, retailSalesDispatchTransactionDto.transactionTime, retailSalesDispatchTransactionDto.convertedTime, retailSalesDispatchTransactionDto.orderReference, retailSalesDispatchTransactionDto.code, retailSalesDispatchTransactionDto.groupType, retailSalesDispatchTransactionDto.iOType, retailSalesDispatchTransactionDto.transactionType, retailSalesDispatchTransactionDto.transactionTypeName, retailSalesDispatchTransactionDto.warehouseNumber, retailSalesDispatchTransactionDto.currentReferenceId, retailSalesDispatchTransactionDto.currentCode, retailSalesDispatchTransactionDto.total, retailSalesDispatchTransactionDto.totalVat, retailSalesDispatchTransactionDto.netTotal, retailSalesDispatchTransactionDto.description, retailSalesDispatchTransactionDto.dispatchType, retailSalesDispatchTransactionDto.carrierReferenceId, retailSalesDispatchTransactionDto.carrierCode, retailSalesDispatchTransactionDto.driverReferenceId, retailSalesDispatchTransactionDto.driverFirstName, retailSalesDispatchTransactionDto.driverLastName, retailSalesDispatchTransactionDto.identityNumber, retailSalesDispatchTransactionDto.plaque, retailSalesDispatchTransactionDto.shipInfoReferenceId, retailSalesDispatchTransactionDto.shipInfoCode, retailSalesDispatchTransactionDto.shipInfoName, retailSalesDispatchTransactionDto.speCode, retailSalesDispatchTransactionDto.dispatchStatus, retailSalesDispatchTransactionDto.isEDispatch, retailSalesDispatchTransactionDto.doCode, retailSalesDispatchTransactionDto.docTrackingNumber, retailSalesDispatchTransactionDto.isEInvoice, retailSalesDispatchTransactionDto.eDispatchProfileId, retailSalesDispatchTransactionDto.eInvoiceProfileId));

		}
	}
}
