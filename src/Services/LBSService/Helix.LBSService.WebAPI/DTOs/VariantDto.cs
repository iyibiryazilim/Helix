namespace Helix.LBSService.WebAPI.DTOs
{
	public class VariantDto
	{
		public VariantDto()
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
}