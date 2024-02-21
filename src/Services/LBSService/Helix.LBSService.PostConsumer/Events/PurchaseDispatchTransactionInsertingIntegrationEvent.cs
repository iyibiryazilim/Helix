using Helix.EventBus.Base.Events;
using Helix.LBSService.PostConsumer.Models;

namespace Helix.LBSService.PostConsumer.Events
{
	public class PurchaseDispatchTransactionInsertingIntegrationEvent : IntegrationEvent
	{
		public IList<PurchaseDispatchLineDto> Lines { get; set; }

		public PurchaseDispatchTransactionInsertingIntegrationEvent()
		{
			TransactionType = 1;
 			Lines = new List<PurchaseDispatchLineDto>();
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
	public class PurchaseDispatchLineDto : ProductTransactionLineDto
	{
		public IList<SeriLotTransactionDto> SeriLotTransactions { get; set; }

		public PurchaseDispatchLineDto()
		{
			TransactionType = 1;
 			SeriLotTransactions = new List<SeriLotTransactionDto>();
		}
	}
}
