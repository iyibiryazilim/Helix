using Helix.EventBus.Base.Events;
using Helix.LBSService.PostConsumer.Models;

namespace Helix.LBSService.PostConsumer.Events
{
	public class TransferTransactionInsertingIntegrationEvent : IntegrationEvent
	{
		public IList<TransferTransactionLineDto> Lines { get; set; }
		public string EmployeeOid { get; set; } = string.Empty;

		public TransferTransactionInsertingIntegrationEvent()
		{
			TransactionType = 25;
			IOType = 3;
			Lines = new List<TransferTransactionLineDto>();
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

	public class TransferTransactionLineDto : ProductTransactionLineDto
	{
		public IList<SeriLotTransactionDto> SeriLotTransactions { get; set; }

		public TransferTransactionLineDto()
		{
			TransactionType = 25;
			IOType = 3;
			SeriLotTransactions = new List<SeriLotTransactionDto>();
		}
	}
}