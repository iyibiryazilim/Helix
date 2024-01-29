using Helix.LBSService.EventConsumer.Helper;
using Helix.LBSService.Tiger.DTOs;

namespace Helix.LBSService.EventConsumer.Services
{
	public class StopTransactionForWorkOrderService : IService<StopTransactionForWorkOrderDto>
	{
		public string GetApiEndpoint()
		{
			return "/api/WorkOrder/Status"; // Replace with your actual API endpoint

		}
	}
}
