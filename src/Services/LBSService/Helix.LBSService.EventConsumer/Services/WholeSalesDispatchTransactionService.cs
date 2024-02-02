using Helix.LBSService.EventConsumer.Helper;
using Helix.LBSService.EventConsumer.Dtos;

namespace Helix.LBSService.EventConsumer.Services
{
	public class WholeSalesDispatchTransactionService : IService<WholeSalesDispatchTransactionDto>
	{
		public string GetApiEndpoint()
		{
			return "/api/WholeSalesDispatchTransaction/Insert"; // Replace with your actual API endpoint

		}
	}
}
