using Helix.LBSService.Base.Models;
using Helix.LBSService.WebAPI.DTOs;

namespace Helix.LBSService.WebAPI.Services
{
	public interface IRetailSalesDispatchTransactionService
	{
		public Task<DataResult<RetailSalesDispatchTransactionDto>> Insert(RetailSalesDispatchTransactionDto dto);
	}
}