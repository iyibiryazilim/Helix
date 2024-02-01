using Helix.LBSService.EventConsumer.Helper;
using Helix.LBSService.EventConsumer.Dtos;

namespace Helix.LBSService.EventConsumer.Services
{
	public class RetailSalesReturnDispatchTransactionService : IService<RetailSalesReturnDispatchTransactionDto>
	{
		public string GetApiEndpoint()
		{
			return "/api/WorkOrder/Insert"; // Replace with your actual API endpoint 
		}
	}
}
