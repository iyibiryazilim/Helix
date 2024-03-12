using Helix.LBSService.Base.Models;
using Helix.LBSService.Tiger.Models;

namespace Helix.LBSService.Tiger.Services
{
	public interface ILG_CurrentService
	{
		Task<DataResult<LG_Current>> Insert(LG_Current dto); 
	}
}
