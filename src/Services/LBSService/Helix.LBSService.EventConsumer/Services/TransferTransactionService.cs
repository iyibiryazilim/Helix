using Helix.LBSService.EventConsumer.Helper;
using Helix.LBSService.EventConsumer.Dtos;

namespace Helix.LBSService.EventConsumer.Services
{
	public class TransferTransactionService : IService<TransferTransactionDto>
	{
		public string GetApiEndpoint()
		{
			return "/api/TransferTransaction/Insert"; // Replace with your actual API endpoint
		}
	}
}
