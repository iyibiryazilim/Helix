using Helix.DemandService.Domain.Dtos;
using Helix.EventBus.Base.Events;

namespace Helix.DemandService.Domain.Events
{
	public class DemandInsertingIntegrationEvent : IntegrationEvent
	{
		public DemandInsertingIntegrationEvent(int referenceId, DateTime date, string documentNumber, string speCode, DateTime dateCreated, string projectCode,short warehouseNumber, IList<DemandLineDto> lines)
		{
			Lines = new List<DemandLineDto>();
			ReferenceId = referenceId;
			Date = date;
			DocumentNumber = documentNumber;
			SpeCode = speCode;
			DateCreated = dateCreated;
			ProjectCode = projectCode;
			WarehouseNumber = warehouseNumber;
			Lines = lines;
		}

		public int ReferenceId { get; set; } = default;
		public DateTime Date { get; set; } = DateTime.Now;
		public string DocumentNumber { get; set; } = string.Empty;
		public string SpeCode { get; set; } = string.Empty;
		public DateTime DateCreated { get; set; } = DateTime.Now;
		public string ProjectCode { get; set; } = string.Empty;
		public short WarehouseNumber { get; set; } = default;
		public IList<DemandLineDto> Lines { get; set; }
	}
}