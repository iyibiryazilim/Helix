using Helix.LBSService.EventConsumer.Dtos;
using Helix.LBSService.EventConsumer.Helper;
using Helix.LBSService.EventConsumer.Dtos;

namespace Helix.LBSService.EventConsumer.Services
{
	public class WorkOrderStatusChangeService : IService<WorkOrderChangeStatusDto>
	{
		public string GetApiEndpoint()
		{
			return "/api/WorkOrder/Status"; // Replace with your actual API endpoint
		}
	}
}
