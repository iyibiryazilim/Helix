using Helix.LBSService.EventConsumer.Helper;
using Helix.LBSService.EventConsumer.Dtos;

namespace Helix.LBSService.EventConsumer.Services
{
	public class OutCountingTransactionService : IService<OutCountingTransactionDto>
	{
		public string GetApiEndpoint()
		{
			return "/api/OutCountingTransaction/Insert"; // Replace with your actual API endpoint
		}
	}
}
