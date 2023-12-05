using Helix.SharedEntity.DTOs.Base;

namespace Helix.SharedEntity.DTOs
{
	public class WorkOrderChangeStatusInsertDto : BaseDto
	{
		public string FicheNo { get; set; } = string.Empty;
		public int Status { get; set; } = default;
		public short DeleteFiche { get; set; } = 2;
	}
}
