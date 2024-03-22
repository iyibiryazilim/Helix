using Helix.LBSService.Base.Models;
using Helix.LBSService.Tiger.Models;

namespace Helix.LBSService.Tiger.Services
{
	public interface ILG_VariantService
	{
		Task<DataResult<LG_Variant>> Insert(LG_Variant dto);
	}
}