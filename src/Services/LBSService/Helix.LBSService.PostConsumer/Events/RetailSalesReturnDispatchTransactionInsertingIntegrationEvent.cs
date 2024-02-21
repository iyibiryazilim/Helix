using Helix.EventBus.Base.Events;
using Helix.LBSService.PostConsumer.Models;

namespace Helix.LBSService.PostConsumer.Events
{
	public class RetailSalesReturnDispatchTransactionInsertingIntegrationEvent : IntegrationEvent
	{
		public IList<RetailSalesReturnDispatchTransactionLineDto> Lines { get; set; }

		public RetailSalesReturnDispatchTransactionInsertingIntegrationEvent()
		{
			TransactionType = 2;
			Lines = new List<RetailSalesReturnDispatchTransactionLineDto>();
		}
		public int? ReferenceId { get; set; }
		public DateTime TransactionDate { get; set; } = DateTime.Now;
		public string? Code { get; set; } = string.Empty;
		public short? GroupType { get; set; } = 3;
		public short? IOType { get; set; } = 0;
		public short? TransactionType { get; set; } = 0;
		public int? WarehouseNumber { get; set; }
		public string? Description { get; set; } = string.Empty;
		public string? SpeCode { get; set; } = string.Empty;
		public string? DoCode { get; set; } = string.Empty;
		public string? DocTrackingNumber { get; set; } = string.Empty;
	}
	public class RetailSalesReturnDispatchTransactionLineDto : ProductTransactionLineDto
	{
		public IList<SeriLotTransactionDto> SeriLotTransactions { get; set; }

		public RetailSalesReturnDispatchTransactionLineDto()
		{
			TransactionType = 2;
			SeriLotTransactions = new List<SeriLotTransactionDto>();
		}
	}
}
