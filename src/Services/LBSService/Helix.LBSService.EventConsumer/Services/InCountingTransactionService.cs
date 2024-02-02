using Helix.LBSService.EventConsumer.Helper;
using Helix.LBSService.EventConsumer.Dtos;

namespace Helix.LBSService.EventConsumer.Services
{
	public class InCountingTransactionService : IService<InCountingTransactionDto>
	{
		public string GetApiEndpoint()
		{
			return "/api/InCountingTransaction/Insert"; // Replace with your actual API endpoint
		}
	}
}
