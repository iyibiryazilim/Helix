using Helix.LBSService.Base.Models;
using Helix.LBSService.WebAPI.DTOs;

namespace Helix.LBSService.WebAPI.Services
{
	public interface IRetailSalesReturnDispatchTransactionService
	{
		public Task<DataResult<RetailSalesReturnDispatchTransactionDto>> Insert(RetailSalesReturnDispatchTransactionDto dto);
	}
}