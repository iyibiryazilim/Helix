using Helix.LBSService.EventConsumer.Helper;
using Helix.LBSService.EventConsumer.Dtos;

namespace Helix.LBSService.EventConsumer.Services
{
	public class WastageTransactionService : IService<WastageTransactionDto>
	{
		public string GetApiEndpoint()
		{
			return "/api/WastageTransaction/Insert"; // Replace with your actual API endpoint
		}
	}
}
