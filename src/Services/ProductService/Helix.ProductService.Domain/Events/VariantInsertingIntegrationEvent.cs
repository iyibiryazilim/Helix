using Helix.EventBus.Base.Events;
using Helix.ProductService.Domain.Dtos;

namespace Helix.ProductService.Domain.Events
{
	public class VariantInsertingIntegrationEvent : IntegrationEvent
	{
		public VariantInsertingIntegrationEvent(short cardType, string code, string name, string unitsetCode, string productCode, IList<VariantAssignDto> lines)
		{
			CardType = (short)cardType;
			Code = code;
			Name = name;
			UnitsetCode = unitsetCode;
			ProductCode = productCode;
			Lines = lines;
		}

		public short CardType { get; set; }
		public string Code { get; set; } = string.Empty;
		public string Name { get; set; } = string.Empty;
		public string UnitsetCode { get; set; } = string.Empty;
		public string ProductCode { get; set; } = string.Empty;

		public IList<VariantAssignDto> Lines { get; set; }
	}
}