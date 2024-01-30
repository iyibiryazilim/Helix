using Helix.LBSService.WebAPI.Models.BaseModel;

namespace Helix.LBSService.WebAPI.Models
{
	public class LG_WastageTransactionLine : LG_ProductTransactionLine
	{
		public int PRORD_SITE { get; set; } = default;
	}
}
