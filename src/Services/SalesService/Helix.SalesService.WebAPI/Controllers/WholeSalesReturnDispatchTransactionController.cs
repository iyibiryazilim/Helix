using Helix.EventBus.Base.Abstractions;
using Helix.SalesService.Application.Repository;
using Helix.SalesService.Domain.AggregateModels;
using Helix.SalesService.Domain.Dtos;
using Helix.SalesService.Domain.Events;
using Helix.SalesService.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Helix.SalesService.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class WholeSalesReturnDispatchTransactionController : ControllerBase
	{
		IWholeSalesReturnDispatchTransactionService _wholeSalesReturnDispatchTransactionService;
		IEventBus _eventBus;
        public WholeSalesReturnDispatchTransactionController(IWholeSalesReturnDispatchTransactionService wholeSalesReturnDispatchTransactionService , IEventBus eventBus)
        {
            _wholeSalesReturnDispatchTransactionService = wholeSalesReturnDispatchTransactionService;
			_eventBus = eventBus;
        }

		[HttpGet]
		public async Task<DataResult<IEnumerable<WholeSalesReturnDispatchTransaction>>> GetAll()
		{
			var result = await _wholeSalesReturnDispatchTransactionService.GetWholeSalesReturnDispatchTransactionsAsync();
			return result;
		}

		[HttpGet("Id/{id:int}")]
		public async Task<DataResult<WholeSalesReturnDispatchTransaction>> GetById(int id)
		{
			var result = await _wholeSalesReturnDispatchTransactionService.GetWholeSalesReturnDispatchTransactionByIdAsync(id);
			return result;
		}

		[HttpGet("Code/{code}")]
		public async Task<DataResult<WholeSalesReturnDispatchTransaction>> GetByCode(string code)
		{
			var result = await _wholeSalesReturnDispatchTransactionService.GetWholeSalesReturnDispatchTransactionByCode(code);
			return result;
		}

		[HttpGet("Current/Id/{id:int}")]
		public async Task<DataResult<IEnumerable<WholeSalesReturnDispatchTransaction>>> GetByCurrentId(int id)
		{
			var result = await _wholeSalesReturnDispatchTransactionService.GetWholeSalesReturnDispatchTransactionsByCurrentIdAsync(id);
			return result;
		}

		[HttpGet("Current/Code/{code}")]
		public async Task<DataResult<IEnumerable<WholeSalesReturnDispatchTransaction>>> GetByCurrentCode(string code)
		{
			var result = await _wholeSalesReturnDispatchTransactionService.GetWholeSalesReturnDispatchTransactionsByCurrentCodeAsync(code);
			return result;
		}
		[HttpPost]
		public async Task WholeSalesReturnDispatchTransactionInsert([FromBody] WholeSalesReturnDispatchTransactionDto wholeSalesReturnDispatchTransactionDto)
		{
			_eventBus.Publish(new WholeSalesReturnDispatchTransactionInsertingIntegrationEvent(wholeSalesReturnDispatchTransactionDto.referenceId, wholeSalesReturnDispatchTransactionDto.transactionDate, wholeSalesReturnDispatchTransactionDto.transactionTime, wholeSalesReturnDispatchTransactionDto.convertedTime, wholeSalesReturnDispatchTransactionDto.orderReference, wholeSalesReturnDispatchTransactionDto.code, wholeSalesReturnDispatchTransactionDto.groupType, wholeSalesReturnDispatchTransactionDto.iOType, wholeSalesReturnDispatchTransactionDto.transactionType, wholeSalesReturnDispatchTransactionDto.transactionTypeName, wholeSalesReturnDispatchTransactionDto.warehouseNumber, wholeSalesReturnDispatchTransactionDto.currentReferenceId, wholeSalesReturnDispatchTransactionDto.currentCode, wholeSalesReturnDispatchTransactionDto.total, wholeSalesReturnDispatchTransactionDto.totalVat, wholeSalesReturnDispatchTransactionDto.netTotal, wholeSalesReturnDispatchTransactionDto.description, wholeSalesReturnDispatchTransactionDto.dispatchType, wholeSalesReturnDispatchTransactionDto.carrierReferenceId, wholeSalesReturnDispatchTransactionDto.carrierCode, wholeSalesReturnDispatchTransactionDto.driverReferenceId, wholeSalesReturnDispatchTransactionDto.driverFirstName, wholeSalesReturnDispatchTransactionDto.driverLastName, wholeSalesReturnDispatchTransactionDto.identityNumber, wholeSalesReturnDispatchTransactionDto.plaque, wholeSalesReturnDispatchTransactionDto.shipInfoReferenceId, wholeSalesReturnDispatchTransactionDto.shipInfoCode, wholeSalesReturnDispatchTransactionDto.shipInfoName, wholeSalesReturnDispatchTransactionDto.speCode, wholeSalesReturnDispatchTransactionDto.dispatchStatus, wholeSalesReturnDispatchTransactionDto.isEDispatch, wholeSalesReturnDispatchTransactionDto.doCode, wholeSalesReturnDispatchTransactionDto.docTrackingNumber, wholeSalesReturnDispatchTransactionDto.isEInvoice, wholeSalesReturnDispatchTransactionDto.eDispatchProfileId, wholeSalesReturnDispatchTransactionDto.eInvoiceProfileId));

		}
	}
}
