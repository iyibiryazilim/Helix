using Helix.EventBus.Base.Events;

namespace Helix.LBSService.PostConsumer.Events
{
	public class DemandInsertingIntegrationEvent : IntegrationEvent
	{
		public DemandInsertingIntegrationEvent()
		{
			Lines = new List<DemandLineDto>();
		}

		public int ReferenceId { get; set; } = default;
		public DateTime Date { get; set; } = DateTime.Now;
		public string DocumentNumber { get; set; } = string.Empty;
		public string SpeCode { get; set; } = string.Empty;
		public DateTime DateCreated { get; set; } = DateTime.Now;
		public string ProjectCode { get; set; } = string.Empty;
		public IList<DemandLineDto> Lines { get; set; }
	}

	public class DemandLineDto
	{
		public double Quantity { get; set; } = default;
		public string CurrentCode { get; set; } = string.Empty;
		public string ProductCode { get; set; } = string.Empty;
		public string Unitset { get; set; } = string.Empty;
		public string VariantCode { get; set; } = string.Empty;
		public double Price { get; set; } = default;
	}
}