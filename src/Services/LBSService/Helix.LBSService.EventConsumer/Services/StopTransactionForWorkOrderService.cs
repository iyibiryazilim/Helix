using Helix.LBSService.EventConsumer.Dtos;
using Helix.LBSService.EventConsumer.Helper;
using Helix.LBSService.EventConsumer.Dtos;

namespace Helix.LBSService.EventConsumer.Services
{
	public class StopTransactionForWorkOrderService : IService<StopTransactionForWorkOrderDto>
	{
		public string GetApiEndpoint()
		{
			return "/api/WorkOrder/StopTransaction"; // Replace with your actual API endpoint

		}
	}
}
