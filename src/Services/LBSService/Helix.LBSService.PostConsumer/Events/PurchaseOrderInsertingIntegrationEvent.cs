using Helix.EventBus.Base.Events;
using Helix.LBSService.PostConsumer.Models;

namespace Helix.LBSService.PostConsumer.Events
{
	public class PurchaseOrderInsertingIntegrationEvent : IntegrationEvent
	{
        public PurchaseOrderInsertingIntegrationEvent()
        {
			Lines = new List<PurchaseOrderLineDto>();

		}
		public IList<PurchaseOrderLineDto> Lines { get; set; }

		public string? EmployeeOid { get; set; }
		public int? ReferenceId { get; set; }
		public string? Code { get; set; } = string.Empty;
		public string SalesmanCode { get; set; } = string.Empty;
		public DateTime OrderDate { get; set; } = DateTime.Now;
		public string? Description { get; set; } = string.Empty;
		public short WarehouseNumber { get; set; }
		public string CustomerCode { get; set; } = string.Empty;
		public string ShipmentAccountCode { get; set; } = string.Empty;
		public string ProjectCode { get; set; } = string.Empty;

	}

	public class PurchaseOrderLineDto : OrderLineDto
	{
 
		public PurchaseOrderLineDto()
		{
  		}
	}
}
