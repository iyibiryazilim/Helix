using Helix.LBSService.EventConsumer.Helper;
using Helix.LBSService.Tiger.DTOs;

namespace Helix.LBSService.EventConsumer.Services
{
	public class TransferTransactionService : IService<TransferTransactionDto>
	{
		public string GetApiEndpoint()
		{
			return "/api/WorkOrder/Insert"; // Replace with your actual API endpoint
		}
	}
}
