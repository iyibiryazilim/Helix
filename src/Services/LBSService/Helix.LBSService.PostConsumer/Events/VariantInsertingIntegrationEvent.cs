using Helix.EventBus.Base.Events;

namespace Helix.LBSService.PostConsumer.Events
{
	public class VariantInsertingIntegrationEvent : IntegrationEvent
	{
		public VariantInsertingIntegrationEvent()
		{
			Lines = new List<VariantAssignDto>();
		}

		public short CardType { get; set; }
		public string Code { get; set; } = string.Empty;
		public string Name { get; set; } = string.Empty;
		public string UnitsetCode { get; set; } = string.Empty;
		public string ProductCode { get; set; } = string.Empty;

		public IList<VariantAssignDto> Lines { get; set; }
	}

	public class VariantAssignDto
	{
		public string VariantPropertyCode { get; set; } = string.Empty;
		public string VariantPropertyName { get; set; } = string.Empty;
		public string VariantPropertyValueCode { get; set; } = string.Empty;
	}
}