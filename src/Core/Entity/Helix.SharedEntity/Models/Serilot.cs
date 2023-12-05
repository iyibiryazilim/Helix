namespace Helix.SharedEntity.Models
{
	public class Serilot
	{
		public int ReferenceId { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Code { get; set; } = string.Empty;
		public short SerilotType { get; set; } = default;
		public string ProductCode { get; set; } = string.Empty;
		public int ProductId { get; set; }

	}
}
