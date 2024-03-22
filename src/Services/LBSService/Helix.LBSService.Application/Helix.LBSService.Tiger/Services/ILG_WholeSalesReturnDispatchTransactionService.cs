using Helix.LBSService.Base.Models;
using Helix.LBSService.Tiger.Models;

namespace Helix.LBSService.Tiger.Services
{
	public interface ILG_WholeSalesReturnDispatchTransactionService
	{
		public Task<DataResult<LG_WholeSalesReturnDispatchTransaction>> Insert(LG_WholeSalesReturnDispatchTransaction dto);
	}
}