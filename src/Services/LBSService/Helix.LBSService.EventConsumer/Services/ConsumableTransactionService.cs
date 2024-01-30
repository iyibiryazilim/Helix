using Helix.LBSService.EventConsumer.Helper;
using Helix.LBSService.Tiger.DTOs;

namespace Helix.LBSService.EventConsumer.Services
{
	public class ConsumableTransactionService : IService<ConsumableTransactionDto>
	{
		public string GetApiEndpoint()
		{
			return "/api/WorkOrder/Insert"; // Replace with your actual API endpoint
		}
	}
}
