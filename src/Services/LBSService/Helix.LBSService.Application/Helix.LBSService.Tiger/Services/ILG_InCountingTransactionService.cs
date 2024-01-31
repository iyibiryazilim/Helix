using Helix.LBSService.Tiger.Models;
using Helix.LBSService.Tiger.Models.BaseModel;
namespace Helix.LBSService.Tiger.Services
{
	public interface ILG_InCountingTransactionService
	{
		Task<DataResult<LG_InCountingTransaction>> Insert(LG_InCountingTransaction dto);

	}
}
