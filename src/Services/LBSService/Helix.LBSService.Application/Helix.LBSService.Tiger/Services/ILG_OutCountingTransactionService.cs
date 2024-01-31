using Helix.LBSService.Tiger.Models;
using Helix.LBSService.Tiger.Models.BaseModel;
namespace Helix.LBSService.Tiger.Services
{
	public interface ILG_OutCountingTransactionService
	{
		Task<DataResult<LG_OutCountingTransaction>> Insert(LG_OutCountingTransaction dto);
	}
}
