using Helix.LBSService.Base.Models;
using Helix.LBSService.Tiger.Models;

namespace Helix.LBSService.Tiger.Services
{
	public interface ILG_DemandService
	{
		public Task<DataResult<LG_Demand>> Insert(LG_Demand dto);
	}
}